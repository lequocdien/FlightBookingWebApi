using AutoMapper;
using DatVeMayBay.Common.ExtenstionMethod;
using DatVeMayBay.Model;
using DatVeMayBay.Service;
using DatVeMayBay.Web.Models;
using DatVeMayBay.Web.Models.InputViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Routing;

namespace DatVeMayBay.Web.Api
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/chuyen-bay")]
    public class ChuyenBayApiController : ApiControllerBase
    {
        private IChuyenBayService m_objCBService;

        public ChuyenBayApiController(IChuyenBayService x_objCBServ)
        {
            this.m_objCBService = x_objCBServ;
        }

        [Route("get-all")]
        public HttpResponseMessage GetAll(HttpRequestMessage request, bool isactive = true)
        {
            return CreateHttpResponeMsg(() => {
                HttpResponseMessage objResponse = null;
                List<ChuyenBayModel> lstCBModel = (List<ChuyenBayModel>)m_objCBService.GetAll(isactive);
                List<ChuyenBayViewModel> lstCBVM = lstCBModel.Map<List<ChuyenBayModel>, List<ChuyenBayViewModel>>(() =>
                {
                    var configuration = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<MayBayModel, MayBayViewModel>().ForMember(d => d.ChuyenBays, act => act.Ignore());
                        cfg.CreateMap<SanBayModel, SanBayViewModel>();
                        cfg.CreateMap<VeModel, VeViewModel>();
                        cfg.CreateMap<ChuyenBayModel, ChuyenBayViewModel>();
                    });
                    IMapper mapper = configuration.CreateMapper();
                    return mapper;
                });
                objResponse = request.CreateResponse(HttpStatusCode.OK);
                objResponse.Content = new StringContent(JsonConvert.SerializeObject(lstCBVM));
                return objResponse;
            });
        }

        [HttpGet]
        [Route("get-by")]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string ngayDi, string diemDi = "", string diemDen = "", bool danghoatdong = true)
        {
            return CreateHttpResponeMsg(() => {
                HttpResponseMessage objResponse = null;
                List<ChuyenBayModel> lstCBModel = (List<ChuyenBayModel>)m_objCBService.GetAll(diemDi, diemDen, DateTime.ParseExact(ngayDi, "ddMMyyyy", CultureInfo.InvariantCulture), danghoatdong);
                List<ChuyenBayViewModel> lstCBVM = lstCBModel.Map<List<ChuyenBayModel>, List<ChuyenBayViewModel>>(() =>
                {
                    var configuration = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<MayBayModel, MayBayViewModel>().ForMember(d => d.ChuyenBays, act => act.Ignore());
                        cfg.CreateMap<SanBayModel, SanBayViewModel>();
                        cfg.CreateMap<VeModel, VeViewModel>();
                        cfg.CreateMap<ChuyenBayModel, ChuyenBayViewModel>();
                    });
                    IMapper mapper = configuration.CreateMapper();
                    return mapper;
                });
                objResponse = request.CreateResponse(HttpStatusCode.OK);
                objResponse.Content = new StringContent(JsonConvert.SerializeObject(lstCBVM));
                return objResponse;
            });
        }

        [HttpGet]
        [Route("get-by-mcb")]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string macb, bool dadat = false)
        {
            return CreateHttpResponeMsg(() =>
            {
                HttpResponseMessage objResponse = null;
                ChuyenBayModel CbModel = m_objCBService.GetVe(macb, dadat);
                if (CbModel == null)
                {
                    return request.CreateResponse(HttpStatusCode.NotFound, "Mã chuyến bay không tồn tại hoặc không còn hoạt động");
                }
                ChuyenBayViewModel cbVM = CbModel.Map<ChuyenBayModel, ChuyenBayViewModel>(() =>
                {
                    var configuration = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<MayBayModel, MayBayViewModel>().ForMember(d => d.ChuyenBays, act => act.Ignore());
                        cfg.CreateMap<SanBayModel, SanBayViewModel>();
                        cfg.CreateMap<VeModel, VeViewModel>();
                        cfg.CreateMap<ChuyenBayModel, ChuyenBayViewModel>();
                    });
                    IMapper mapper = configuration.CreateMapper();
                    return mapper;
                });
                objResponse = request.CreateResponse(HttpStatusCode.OK);
                objResponse.Content = new StringContent(JsonConvert.SerializeObject(cbVM));
                return objResponse;
            });
        }

        [HttpPost]
        [Route("insert")]
        public HttpResponseMessage Insert(HttpRequestMessage request, InputInsertChuyenBayViewModel inputCB)
        {
            return CreateHttpResponeMsg(() =>
            {
                if (inputCB.MaChuyenBay == null || inputCB.MaSanBayDi == null || inputCB.MaSanBayDen == null|| inputCB.ThoiGianDi == null || inputCB.ThoiGianDen == null || inputCB.MaMayBay == null)
                {
                    return request.CreateResponse(HttpStatusCode.BadRequest, "ERROR: mcb, masbdi, masbden, tgdi, tgden, mamb không được phép null");
                }

                if (ModelState.IsValid == false)
                {
                    var error = ModelState.Values.SelectMany(e => e.Errors).Select(er => er.ErrorMessage).ToArray();
                    return request.CreateResponse(HttpStatusCode.BadRequest, "ERROR: Vui lòng kiểm tra dữ liệu đầu vào. " + string.Join("; ", error));
                }

                ChuyenBayModel objCb = new ChuyenBayModel();
                objCb.MaChuyenBay = inputCB.MaChuyenBay;
                objCb.MaSanBayDi = inputCB.MaSanBayDi;
                objCb.MaSanBayDen = inputCB.MaSanBayDen;
                objCb.ThoiGianDiDuKien = inputCB.ThoiGianDi;
                objCb.ThoiGianDenDuKien = inputCB.ThoiGianDen;
                objCb.MaMayBay = inputCB.MaMayBay;
                objCb.GhiChu = inputCB.GhiChu;
                objCb.DangHoatDong = true;

                HttpResponseMessage objResponseMsg;
                try
                {
                    objCb = m_objCBService.Insert(objCb);
                }
                catch (Exception)
                {
                    return request.CreateResponse(HttpStatusCode.BadRequest, "ERROR: Bạn vui lòng kiểm tra truong mcb, masbdi, masbden");
                }


                if (objCb == null)
                {
                    return request.CreateResponse(HttpStatusCode.BadRequest, "ERROR: Vui lòng kiểm tra dữ liệu đầu vào");
                }

                ChuyenBayViewModel objCbVM = objCb.Map<ChuyenBayModel, ChuyenBayViewModel>(() =>
                {
                    var configuration = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<MayBayModel, MayBayViewModel>().ForMember(d => d.ChuyenBays, act => act.Ignore());
                        cfg.CreateMap<SanBayModel, SanBayViewModel>();
                        cfg.CreateMap<VeModel, VeViewModel>();
                        cfg.CreateMap<ChuyenBayModel, ChuyenBayViewModel>();
                    });
                    IMapper mapper = configuration.CreateMapper();
                    return mapper;
                });
                try
                {
                    objResponseMsg = request.CreateResponse(HttpStatusCode.OK);
                    objResponseMsg.Content = new StringContent(JsonConvert.SerializeObject(objCbVM));
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
        public HttpResponseMessage Update(HttpRequestMessage request, InputInsertChuyenBayViewModel inputCB)
        {
            return CreateHttpResponeMsg(() =>
            {
                if (inputCB.MaChuyenBay == null || inputCB.MaSanBayDi == null || inputCB.MaSanBayDen == null || inputCB.ThoiGianDi == null || inputCB.ThoiGianDen == null || inputCB.MaMayBay == null)
                {
                    return request.CreateResponse(HttpStatusCode.BadRequest, "ERROR: mcb, masbdi, masbden, tgdi, tgden, mamb không được phép null");
                }

                if (ModelState.IsValid == false)
                {
                    var error = ModelState.Values.SelectMany(e => e.Errors).Select(er => er.ErrorMessage).ToArray();
                    return request.CreateResponse(HttpStatusCode.BadRequest, "ERROR: Vui lòng kiểm tra dữ liệu đầu vào. " + string.Join("; ", error));
                }

                ChuyenBayModel objCb = new ChuyenBayModel();
                objCb.MaChuyenBay = inputCB.MaChuyenBay;
                objCb.MaSanBayDi = inputCB.MaSanBayDi;
                objCb.MaSanBayDen = inputCB.MaSanBayDen;
                objCb.ThoiGianDiDuKien = inputCB.ThoiGianDi;
                objCb.ThoiGianDenDuKien = inputCB.ThoiGianDen;
                objCb.MaMayBay = inputCB.MaMayBay;
                objCb.GhiChu = inputCB.GhiChu;
                objCb.DangHoatDong = true;

                HttpResponseMessage objResponseMsg;
                try
                {
                    objCb = m_objCBService.Update(objCb);
                }
                catch (Exception)
                {
                    return request.CreateResponse(HttpStatusCode.BadRequest, "ERROR: Bạn vui lòng kiểm tra truong mcb, masbdi, masbden");
                }


                if (objCb == null)
                {
                    return request.CreateResponse(HttpStatusCode.BadRequest, "ERROR: Vui lòng kiểm tra dữ liệu đầu vào");
                }

                ChuyenBayViewModel objCbVM = objCb.Map<ChuyenBayModel, ChuyenBayViewModel>(() =>
                {
                    var configuration = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<MayBayModel, MayBayViewModel>().ForMember(d => d.ChuyenBays, act => act.Ignore());
                        cfg.CreateMap<SanBayModel, SanBayViewModel>();
                        cfg.CreateMap<VeModel, VeViewModel>();
                        cfg.CreateMap<ChuyenBayModel, ChuyenBayViewModel>();
                    });
                    IMapper mapper = configuration.CreateMapper();
                    return mapper;
                });
                try
                {
                    objResponseMsg = request.CreateResponse(HttpStatusCode.OK);
                    objResponseMsg.Content = new StringContent(JsonConvert.SerializeObject(objCbVM));
                }
                catch (System.Exception ex)
                {
                    return request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
                }

                return objResponseMsg;
            });
        }

        [HttpPut]
        [Route("delete")]
        public HttpResponseMessage Delete(HttpRequestMessage request, InputInsertChuyenBayViewModel inputCB)
        {
            return CreateHttpResponeMsg(() =>
            {
                if (inputCB.MaChuyenBay == null || inputCB.MaSanBayDi == null || inputCB.MaSanBayDen == null || inputCB.ThoiGianDi == null || inputCB.ThoiGianDen == null || inputCB.MaMayBay == null)
                {
                    return request.CreateResponse(HttpStatusCode.BadRequest, "ERROR: mcb, masbdi, masbden, tgdi, tgden, mamb không được phép null");
                }

                if (ModelState.IsValid == false)
                {
                    var error = ModelState.Values.SelectMany(e => e.Errors).Select(er => er.ErrorMessage).ToArray();
                    return request.CreateResponse(HttpStatusCode.BadRequest, "ERROR: Vui lòng kiểm tra dữ liệu đầu vào. " + string.Join("; ", error));
                }

                ChuyenBayModel objCb = new ChuyenBayModel();
                objCb.MaChuyenBay = inputCB.MaChuyenBay;
                objCb.MaSanBayDi = inputCB.MaSanBayDi;
                objCb.MaSanBayDen = inputCB.MaSanBayDen;
                objCb.ThoiGianDiDuKien = inputCB.ThoiGianDi;
                objCb.ThoiGianDenDuKien = inputCB.ThoiGianDen;
                objCb.MaMayBay = inputCB.MaMayBay;
                objCb.GhiChu = inputCB.GhiChu;
                objCb.DangHoatDong = false;

                HttpResponseMessage objResponseMsg;
                try
                {
                    objCb = m_objCBService.Update(objCb);
                }
                catch (Exception)
                {
                    return request.CreateResponse(HttpStatusCode.BadRequest, "ERROR: Bạn vui lòng kiểm tra truong mcb, masbdi, masbden");
                }


                if (objCb == null)
                {
                    return request.CreateResponse(HttpStatusCode.BadRequest, "ERROR: Vui lòng kiểm tra dữ liệu đầu vào");
                }

                ChuyenBayViewModel objCbVM = objCb.Map<ChuyenBayModel, ChuyenBayViewModel>(() =>
                {
                    var configuration = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<MayBayModel, MayBayViewModel>().ForMember(d => d.ChuyenBays, act => act.Ignore());
                        cfg.CreateMap<SanBayModel, SanBayViewModel>();
                        cfg.CreateMap<VeModel, VeViewModel>();
                        cfg.CreateMap<ChuyenBayModel, ChuyenBayViewModel>();
                    });
                    IMapper mapper = configuration.CreateMapper();
                    return mapper;
                });
                try
                {
                    objResponseMsg = request.CreateResponse(HttpStatusCode.OK);
                    objResponseMsg.Content = new StringContent(JsonConvert.SerializeObject(objCbVM));
                }
                catch (System.Exception ex)
                {
                    return request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
                }

                return objResponseMsg;
            });
        }

        //[Route("insert")]
        //[HttpPut]
        //public HttpResponseMessage Insert(HttpRequestMessage requestMessage, ChuyenBayViewModel x_objChuyenBay)
        //{
        //    return CreateHttpResponeMsg(() =>
        //    {

        //    });
        //}

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