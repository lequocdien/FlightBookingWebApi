using AutoMapper;
using DatVeMayBay.Common.ExtenstionMethod;
using DatVeMayBay.Model;
using DatVeMayBay.Service;
using DatVeMayBay.Web.Infrastructure.Extension;
using DatVeMayBay.Web.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DatVeMayBay.Web.Api
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/hoa-don")]
    public class HoaDonApiController : ApiControllerBase
    {
        private IHoaDonService m_objHDServ;

        public HoaDonApiController(IHoaDonService x_objHDServ)
        {
            this.m_objHDServ = x_objHDServ;
        }

        [Route("get-all")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponeMsg(() =>
            {
                HttpResponseMessage response = null;
                List<HoaDonModel> lstHDModel = (List<HoaDonModel>)m_objHDServ.GetAll();
                List<HoaDonViewModel> lstHDVM = lstHDModel.Map<List<HoaDonModel>, List<HoaDonViewModel>>(() =>
                {
                    var configuration = new MapperConfiguration(cfg => {
                        cfg.CreateMap<VeModel, VeViewModel>();
                        cfg.CreateMap<HoaDonModel, HoaDonViewModel>();
                    });
                    IMapper mapper = configuration.CreateMapper();
                    return mapper;
                });
                response = request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(JsonConvert.SerializeObject(lstHDVM));
                return response;
            });
        }

        [HttpPost]
        [Route("insert")]
        private HttpResponseMessage Insert(HttpRequestMessage request, HoaDonViewModel hoaDonVM)
        {
            return CreateHttpResponeMsg(() =>
            {
                if (hoaDonVM.NgayLap == null || hoaDonVM.ThanhTien == null || hoaDonVM.DaThanhToan == null || hoaDonVM.MaNhanVien == null || hoaDonVM.CMND == null)
                {
                    return request.CreateResponse(HttpStatusCode.BadRequest, "ERROR: Vui lòng kiểm tra dữ liệu đầu vào");
                }

                if ( ModelState.IsValid == false)
                {
                    var error = ModelState.Values.SelectMany(e => e.Errors).Select(er => er.ErrorMessage).ToArray();
                    return request.CreateResponse(HttpStatusCode.BadRequest, "ERROR: Vui lòng kiểm tra dữ liệu đầu vào. " + string.Join("; ", error));
                }

                HttpResponseMessage objResponseMsg;
                HoaDonModel objHoadDonModel = m_objHDServ.Insert(hoaDonVM.ConvertToHoaDonModel());

                if (objHoadDonModel == null)
                {
                    return request.CreateResponse(HttpStatusCode.BadRequest, "ERROR: Vui lòng kiểm tra dữ liệu đầu vào");
                }

                HoaDonViewModel objVeVM = objHoadDonModel.Map<HoaDonModel, HoaDonViewModel>(() =>
                {
                    var configuration = new MapperConfiguration(cfg => {
                        cfg.CreateMap<VeModel, VeViewModel>();
                        cfg.CreateMap<HoaDonModel, HoaDonViewModel>();
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