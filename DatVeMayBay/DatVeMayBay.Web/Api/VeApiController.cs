using AutoMapper;
using DatVeMayBay.Common.ExtenstionMethod;
using DatVeMayBay.Model;
using DatVeMayBay.Service;
using DatVeMayBay.Web.Infrastructure.Extension;
using DatVeMayBay.Web.Models;
using DatVeMayBay.Web.Models.InputViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DatVeMayBay.Web.Api
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/ve")]
    public class VeApiController : ApiControllerBase
    {
        private IVeService m_objVeServ;
        private IHoaDonService m_objHDServ;
        private IChuyenBayService m_objCBServ;

        public VeApiController(IVeService x_objVeServ, IHoaDonService x_objHdServ, IChuyenBayService x_objCBServ)
        {
            this.m_objVeServ = x_objVeServ;
            this.m_objHDServ = x_objHdServ;
            this.m_objCBServ = x_objCBServ;
        }

        [HttpGet]
        [Route("get-all")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponeMsg(() =>
            {
                HttpResponseMessage objResponseMsg;
                List<VeModel> lstVModel = (List<VeModel>)m_objVeServ.GetAll();
                List<VeViewModel> lstVVM = lstVModel.Map<List<VeModel>, List<VeViewModel>>(() =>
                {
                    var configuration = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<VeModel, VeViewModel>();
                        cfg.CreateMap<HoaDonModel, HoaDonViewModel>().ForMember(d => d.KhachHang, act => act.MapFrom(s => s.KhachHang)).ForMember(d => d.Ves, act => act.Ignore());
                        cfg.CreateMap<KhachHangModel, KhachHangViewModel>().ForMember(d => d.HoaDons, act => act.Ignore());
                        cfg.CreateMap<ChuyenBayModel, ChuyenBayViewModel>().ForMember(d => d.Ves, act => act.Ignore());
                        cfg.CreateMap<SanBayModel, SanBayViewModel>();
                        cfg.CreateMap<MayBayModel, MayBayViewModel>().ForMember(d => d.ChuyenBays, act => act.Ignore());
                        cfg.CreateMap<KhachHangModel, KhachHangViewModel>().ForMember(d => d.HoaDons, act => act.Ignore());
                        cfg.CreateMap<NhanVienModel, NhanVienViewModel>().ForMember(d => d.HoaDons, act => act.Ignore());
                    });
                    IMapper mapper = configuration.CreateMapper();
                    return mapper;
                });
                try
                {
                    objResponseMsg = request.CreateResponse(HttpStatusCode.OK);
                    objResponseMsg.Content = new StringContent(JsonConvert.SerializeObject(lstVVM));
                }
                catch (System.Exception ex)
                {
                    return request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
                }

                return objResponseMsg;
            });
        }

        [HttpGet]
        [Route("get-by-id")]
        private HttpResponseMessage GetAll(HttpRequestMessage request, string mave)
        {
            return CreateHttpResponeMsg(() =>
            {
                HttpResponseMessage objResponseMsg;
                VeModel veModel = m_objVeServ.GetById(mave);
                VeViewModel veViewModel = veModel.Map<VeModel, VeViewModel>(() =>
                 {
                     var configuration = new MapperConfiguration(cfg =>
                     {
                         cfg.CreateMap<VeModel, VeViewModel>();
                         cfg.CreateMap<HoaDonModel, HoaDonViewModel>().ForMember(d => d.KhachHang, act => act.MapFrom(s => s.KhachHang)).ForMember(d => d.Ves, act => act.Ignore());
                         cfg.CreateMap<KhachHangModel, KhachHangViewModel>().ForMember(d => d.HoaDons, act => act.Ignore());
                         cfg.CreateMap<ChuyenBayModel, ChuyenBayViewModel>().ForMember(d => d.Ves, act => act.Ignore());
                         cfg.CreateMap<SanBayModel, SanBayViewModel>();
                         cfg.CreateMap<MayBayModel, MayBayViewModel>().ForMember(d => d.ChuyenBays, act => act.Ignore());
                         cfg.CreateMap<KhachHangModel, KhachHangViewModel>().ForMember(d => d.HoaDons, act => act.Ignore());
                         cfg.CreateMap<NhanVienModel, NhanVienViewModel>().ForMember(d => d.HoaDons, act => act.Ignore());
                     });
                     IMapper mapper = configuration.CreateMapper();
                     return mapper;
                 });
                objResponseMsg = request.CreateResponse(HttpStatusCode.OK);
                objResponseMsg.Content = new StringContent(JsonConvert.SerializeObject(veViewModel));
                return objResponseMsg;
            });
        }

        [HttpGet]
        [Route("look-up-ticket")]
        public HttpResponseMessage LookUpTicket(HttpRequestMessage request, string mave, string email)
        {
            return CreateHttpResponeMsg(() =>
            {
                HttpResponseMessage objResponseMsg;

                VeModel veModel = m_objVeServ.LookUpTicket(mave, email);
                if (veModel == null)
                {
                    return request.CreateResponse(HttpStatusCode.NotFound, "Không tìm thấy kết quả phù hợp");
                }

                VeViewModel veViewModel = veModel.Map<VeModel, VeViewModel>(() =>
                {
                    var configuration = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<VeModel, VeViewModel>();
                        cfg.CreateMap<HoaDonModel, HoaDonViewModel>().ForMember(d => d.KhachHang, act => act.MapFrom(s => s.KhachHang)).ForMember(d => d.Ves, act => act.Ignore());
                        cfg.CreateMap<KhachHangModel, KhachHangViewModel>().ForMember(d => d.HoaDons, act => act.Ignore());
                        cfg.CreateMap<ChuyenBayModel, ChuyenBayViewModel>().ForMember(d => d.Ves, act => act.Ignore());
                        cfg.CreateMap<SanBayModel, SanBayViewModel>();
                        cfg.CreateMap<MayBayModel, MayBayViewModel>().ForMember(d => d.ChuyenBays, act => act.Ignore());
                        cfg.CreateMap<KhachHangModel, KhachHangViewModel>().ForMember(d => d.HoaDons, act => act.Ignore());
                        cfg.CreateMap<NhanVienModel, NhanVienViewModel>().ForMember(d => d.HoaDons, act => act.Ignore());
                    });
                    IMapper mapper = configuration.CreateMapper();
                    return mapper;
                });
                objResponseMsg = request.CreateResponse(HttpStatusCode.OK);
                objResponseMsg.Content = new StringContent(JsonConvert.SerializeObject(veViewModel));
                return objResponseMsg;
            });
        }

        [HttpPost]
        [Route("insert")]
        public HttpResponseMessage Insert(HttpRequestMessage request, InputInsertVeViewModel inputVe)
        {
            return CreateHttpResponeMsg(() =>
            {
                if (inputVe.MaVe == null || inputVe.SoGhe == null || inputVe.MaChuyenBay == null)
                {
                    return request.CreateResponse(HttpStatusCode.BadRequest, "ERROR: mave, soghe, macb không được phép null");
                }

                if (ModelState.IsValid == false)
                {
                    var error = ModelState.Values.SelectMany(e => e.Errors).Select(er => er.ErrorMessage).ToArray();
                    return request.CreateResponse(HttpStatusCode.BadRequest, "ERROR: Vui lòng kiểm tra dữ liệu đầu vào. " + string.Join("; ", error));
                }

                VeModel objInputVe = new VeModel();
                objInputVe.MaVe = inputVe.MaVe;
                objInputVe.SoGhe = inputVe.SoGhe;
                objInputVe.MaChuyenBay = inputVe.MaChuyenBay;
                objInputVe.GiaVe = inputVe.GiaVe;
                objInputVe.DaDat = false;

                HttpResponseMessage objResponseMsg;
                VeModel objVeModel;
                try
                {
                    objVeModel = m_objVeServ.Insert(objInputVe);
                }
                catch (Exception)
                {
                    return request.CreateResponse(HttpStatusCode.BadRequest, "ERROR: mave đã tồn tại");
                }
                

                if (objVeModel == null)
                {
                    return request.CreateResponse(HttpStatusCode.BadRequest, "ERROR: Vui lòng kiểm tra dữ liệu đầu vào");
                }

                VeViewModel objVeVM = objVeModel.Map<VeModel, VeViewModel>(() =>
                {
                    var configuration = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<VeModel, VeViewModel>();
                        cfg.CreateMap<HoaDonModel, HoaDonViewModel>().ForMember(d => d.KhachHang, act => act.MapFrom(s => s.KhachHang)).ForMember(d => d.Ves, act => act.Ignore());
                        cfg.CreateMap<KhachHangModel, KhachHangViewModel>().ForMember(d => d.HoaDons, act => act.Ignore());
                        cfg.CreateMap<ChuyenBayModel, ChuyenBayViewModel>().ForMember(d => d.Ves, act => act.Ignore());
                        cfg.CreateMap<SanBayModel, SanBayViewModel>();
                        cfg.CreateMap<MayBayModel, MayBayViewModel>().ForMember(d => d.ChuyenBays, act => act.Ignore());
                        cfg.CreateMap<KhachHangModel, KhachHangViewModel>().ForMember(d => d.HoaDons, act => act.Ignore());
                        cfg.CreateMap<NhanVienModel, NhanVienViewModel>().ForMember(d => d.HoaDons, act => act.Ignore());
                    });
                    IMapper mapper = configuration.CreateMapper();
                    return mapper;
                });
                try
                {
                    objResponseMsg = request.CreateResponse(HttpStatusCode.OK);
                    objResponseMsg.Content = new StringContent(JsonConvert.SerializeObject(objVeVM));
                }
                catch (System.Exception ex)
                {
                    return request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
                }

                return objResponseMsg;
            });
        }

        [HttpPut]
        [Route("update")]
        public HttpResponseMessage Update(HttpRequestMessage request, InputUpdateVeViewModel objIptUpdateVe)
        {
            return CreateHttpResponeMsg(() =>
            {
                if (objIptUpdateVe.MaVe == null || objIptUpdateVe.SoGhe == null || objIptUpdateVe.MaChuyenBay == null || objIptUpdateVe.GiaVe == null)
                {
                    return request.CreateResponse(HttpStatusCode.BadRequest, "ERROR: 'mave', 'soghe', 'macb', 'gia' không được phép null");
                }

                if (ModelState.IsValid == false)
                {
                    var error = ModelState.Values.SelectMany(e => e.Errors);
                    return request.CreateResponse(HttpStatusCode.BadRequest, "ERROR: Vui lòng kiểm tra dữ liệu đầu vào");
                }

                VeModel objVe = new VeModel();
                objVe.MaVe = objIptUpdateVe.MaVe;
                objVe.SoGhe = objIptUpdateVe.SoGhe;
                objVe.MaChuyenBay = objIptUpdateVe.MaChuyenBay;
                objVe.GiaVe = objIptUpdateVe.GiaVe;
                HttpResponseMessage objResponseMsg;
                VeModel objVeModel = m_objVeServ.Update(objVe);

                if (objVeModel == null)
                {
                    return request.CreateResponse(HttpStatusCode.BadRequest, "ERROR: Vui lòng kiểm tra dữ liệu đầu vào");
                }

                VeViewModel objVeVM = objVeModel.Map<VeModel, VeViewModel>(() =>
                {
                    var configuration = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<VeModel, VeViewModel>();
                        cfg.CreateMap<HoaDonModel, HoaDonViewModel>().ForMember(d => d.KhachHang, act => act.MapFrom(s => s.KhachHang)).ForMember(d => d.Ves, act => act.Ignore());
                        cfg.CreateMap<KhachHangModel, KhachHangViewModel>().ForMember(d => d.HoaDons, act => act.Ignore());
                        cfg.CreateMap<ChuyenBayModel, ChuyenBayViewModel>().ForMember(d => d.Ves, act => act.Ignore());
                        cfg.CreateMap<SanBayModel, SanBayViewModel>();
                        cfg.CreateMap<MayBayModel, MayBayViewModel>().ForMember(d => d.ChuyenBays, act => act.Ignore());
                        cfg.CreateMap<KhachHangModel, KhachHangViewModel>().ForMember(d => d.HoaDons, act => act.Ignore());
                        cfg.CreateMap<NhanVienModel, NhanVienViewModel>().ForMember(d => d.HoaDons, act => act.Ignore());
                    });
                    IMapper mapper = configuration.CreateMapper();
                    return mapper;
                });
                try
                {
                    objResponseMsg = request.CreateResponse(HttpStatusCode.OK);
                    objResponseMsg.Content = new StringContent(JsonConvert.SerializeObject(objVeVM));
                }
                catch (System.Exception ex)
                {
                    return request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
                }

                return objResponseMsg;
            });
        }

        [HttpPut]
        [Route("update-status")]
        private HttpResponseMessage UpdateStatus(HttpRequestMessage request, VeViewModel veVM)
        {
            return CreateHttpResponeMsg(() =>
            {
                if (veVM.MaVe == null || veVM.DaDat == null || veVM.MaHoaDon == null || veVM.ThoiGianDat == null)
                {
                    return request.CreateResponse(HttpStatusCode.BadRequest, "ERROR: Vui lòng kiểm tra dữ liệu đầu vào");
                }

                if (ModelState.IsValid == false)
                {
                    var error = ModelState.Values.SelectMany(e => e.Errors);
                    return request.CreateResponse(HttpStatusCode.BadRequest, "ERROR: Vui lòng kiểm tra dữ liệu đầu vào");
                }

                HttpResponseMessage objResponseMsg;
                VeModel objVeModel = m_objVeServ.UpdateStatus(veVM.ConvertToVeModel());

                if (objVeModel == null)
                {
                    return request.CreateResponse(HttpStatusCode.BadRequest, "ERROR: Vui lòng kiểm tra dữ liệu đầu vào");
                }

                VeViewModel objVeVM = objVeModel.Map<VeModel, VeViewModel>(() =>
                {
                    var configuration = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<VeModel, VeViewModel>();
                        cfg.CreateMap<HoaDonModel, HoaDonViewModel>().ForMember(d => d.KhachHang, act => act.MapFrom(s => s.KhachHang)).ForMember(d => d.Ves, act => act.Ignore());
                        cfg.CreateMap<KhachHangModel, KhachHangViewModel>().ForMember(d => d.HoaDons, act => act.Ignore());
                        cfg.CreateMap<ChuyenBayModel, ChuyenBayViewModel>().ForMember(d => d.Ves, act => act.Ignore());
                        cfg.CreateMap<SanBayModel, SanBayViewModel>();
                        cfg.CreateMap<MayBayModel, MayBayViewModel>().ForMember(d => d.ChuyenBays, act => act.Ignore());
                        cfg.CreateMap<KhachHangModel, KhachHangViewModel>().ForMember(d => d.HoaDons, act => act.Ignore());
                        cfg.CreateMap<NhanVienModel, NhanVienViewModel>().ForMember(d => d.HoaDons, act => act.Ignore());
                    });
                    IMapper mapper = configuration.CreateMapper();
                    return mapper;
                });
                try
                {
                    objResponseMsg = request.CreateResponse(HttpStatusCode.OK);
                    objResponseMsg.Content = new StringContent(JsonConvert.SerializeObject(objVeVM));
                }
                catch (System.Exception ex)
                {
                    return request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
                }

                return objResponseMsg;
            });
        }

        [HttpPost]
        [Route("ticket-booking")]
        public HttpResponseMessage TicketBooking(HttpRequestMessage request, InputDatVeViewModel datVeVM)
        {
            return CreateHttpResponeMsg(() =>
            {
                if (datVeVM.CMND == null || datVeVM.ThanhTien == null || datVeVM.MaChuyenBay == null)
                {
                    return request.CreateResponse(HttpStatusCode.BadRequest, "ERROR: 'cmnd', 'thanhtien', 'macb' không được phép null");
                }

                if (ModelState.IsValid == false)
                {
                    var error = ModelState.Values.SelectMany(e => e.Errors);
                    return request.CreateResponse(HttpStatusCode.BadRequest, "ERROR: Vui lòng kiểm tra dữ liệu đầu vào");
                }

                HoaDonModel hoaDonVM = new HoaDonModel();
                hoaDonVM.CMND = datVeVM.CMND;
                hoaDonVM.ThanhTien = datVeVM.ThanhTien;
                hoaDonVM.NgayLap = DateTime.Now;
                hoaDonVM.DaThanhToan = true;
                hoaDonVM.MaNhanVien = "NV1";

                HttpResponseMessage objResponseMsg;

                // 1. Thêm hóa đơn
                HoaDonModel objHoadDonModel = m_objHDServ.Insert(hoaDonVM);
                if (objHoadDonModel == null)
                {
                    return request.CreateResponse(HttpStatusCode.BadRequest, "ERROR: Vui lòng kiểm tra dữ liệu đầu vào");
                }
                // 2. Update trạng thái vé
                VeModel veModel = new VeModel();
                veModel.MaHoaDon = objHoadDonModel.MaHoaDon;
                veModel.DaDat = true;
                veModel.ThoiGianDat = DateTime.Now;
                var lstVe = m_objCBServ.GetVe(datVeVM.MaChuyenBay, false).Ves;
                if (lstVe == null || lstVe.Count <= 0)
                {
                    return request.CreateResponse(HttpStatusCode.BadRequest, "ERROR: Hết vé");
                }
                veModel.MaVe = lstVe.FirstOrDefault().MaVe;
                VeModel objVeModel = m_objVeServ.UpdateStatus(veModel);

                if (objVeModel == null)
                {
                    return request.CreateResponse(HttpStatusCode.BadRequest, "ERROR: Vui lòng kiểm tra dữ liệu đầu vào");
                }

                VeViewModel objVeVM = objVeModel.Map<VeModel, VeViewModel>(() =>
                {
                    var configuration = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<VeModel, VeViewModel>();
                        cfg.CreateMap<ChuyenBayModel, ChuyenBayViewModel>().ForMember(d => d.Ves, act => act.Ignore());
                        cfg.CreateMap<SanBayModel, SanBayViewModel>();
                        cfg.CreateMap<MayBayModel, MayBayViewModel>().ForMember(d => d.ChuyenBays, act => act.Ignore());
                        cfg.CreateMap<HoaDonModel, HoaDonViewModel>().ForMember(d => d.Ves, act => act.Ignore());
                        cfg.CreateMap<KhachHangModel, KhachHangViewModel>().ForMember(d => d.HoaDons, act => act.Ignore());
                        cfg.CreateMap<NhanVienModel, NhanVienViewModel>().ForMember(d => d.HoaDons, act => act.Ignore());
                    });
                    IMapper mapper = configuration.CreateMapper();
                    return mapper;
                });
                try
                {
                    objResponseMsg = request.CreateResponse(HttpStatusCode.OK);
                    objResponseMsg.Content = new StringContent(JsonConvert.SerializeObject(objVeVM));
                }
                catch (System.Exception ex)
                {
                    return request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
                }

                return objResponseMsg;
            });
        }


        //// GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<controller>
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}