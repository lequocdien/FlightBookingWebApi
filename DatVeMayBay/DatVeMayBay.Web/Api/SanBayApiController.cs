using AutoMapper;
using DatVeMayBay.Common.ExtenstionMethod;
using DatVeMayBay.Model;
using DatVeMayBay.Service;
using DatVeMayBay.Web.Infrastructure.Extension;
using DatVeMayBay.Web.Models;
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
    [RoutePrefix("api/san-bay")]
    public class SanBayApiController : ApiControllerBase
    {
        private ISanBayService m_objSanBayServ;

        public SanBayApiController(ISanBayService x_objSanBayServ)
        {
            this.m_objSanBayServ = x_objSanBayServ;
        }

        [Route("get-all")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponeMsg(() =>
            {
                HttpResponseMessage response = null;
                List<SanBayModel> lstSanBayModel = (List<SanBayModel>)m_objSanBayServ.GetAll();
                List<SanBayViewModel> lstSanBayVM = lstSanBayModel.Map<List<SanBayModel>, List<SanBayViewModel>>(() =>
                {
                    var configuration = new MapperConfiguration(cfg => {
                        cfg.CreateMap<SanBayModel, SanBayViewModel>();
                    });
                    IMapper mapper = configuration.CreateMapper();
                    return mapper;
                });
                response = request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(JsonConvert.SerializeObject(lstSanBayVM));
                return response;
            });
        }

        [HttpPost]
        [Route("insert")]
        public HttpResponseMessage Insert(HttpRequestMessage request, SanBayViewModel x_objSanBay)
        {
            return CreateHttpResponeMsg(() =>
            {
                if (x_objSanBay.MaSanBay == null || x_objSanBay.TenSanBay == null || x_objSanBay.ThanhPho == null || x_objSanBay.QuocGia == null)
                {
                    return request.CreateResponse(HttpStatusCode.BadRequest, "ERROR: masb, tensb, tp, quocgia không được phép null");
                }

                if (ModelState.IsValid == false)
                {
                    var error = ModelState.Values.SelectMany(e => e.Errors).Select(er => er.ErrorMessage).ToArray();
                    return request.CreateResponse(HttpStatusCode.BadRequest, "ERROR: Vui lòng kiểm tra dữ liệu đầu vào. " + string.Join("; ", error));
                }

                SanBayModel objSanBay;
                HttpResponseMessage objResponseMsg;
                try
                {
                    objSanBay = m_objSanBayServ.Insert(x_objSanBay.ConvertToSanBayModel());
                }
                catch (Exception)
                {
                    return request.CreateResponse(HttpStatusCode.BadRequest, "ERROR: Bạn vui lòng kiểm tra truong mcb, masbdi, masbden");
                }


                if (objSanBay == null)
                {
                    return request.CreateResponse(HttpStatusCode.BadRequest, "ERROR: Vui lòng kiểm tra dữ liệu đầu vào");
                }

                SanBayViewModel objSanBayVM = objSanBay.Map<SanBayModel, SanBayViewModel>(() =>
                {
                    var configuration = new MapperConfiguration(cfg => {
                        cfg.CreateMap<SanBayModel, SanBayViewModel>();
                    });
                    IMapper mapper = configuration.CreateMapper();
                    return mapper;
                });

                try
                {
                    objResponseMsg = request.CreateResponse(HttpStatusCode.OK);
                    objResponseMsg.Content = new StringContent(JsonConvert.SerializeObject(objSanBayVM));
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
        public HttpResponseMessage Update(HttpRequestMessage request, SanBayViewModel x_objSanBay)
        {
            return CreateHttpResponeMsg(() =>
            {
                if (x_objSanBay.MaSanBay == null || x_objSanBay.TenSanBay == null || x_objSanBay.ThanhPho == null || x_objSanBay.QuocGia == null)
                {
                    return request.CreateResponse(HttpStatusCode.BadRequest, "ERROR: masb, tensb, tp, quocgia không được phép null");
                }

                if (ModelState.IsValid == false)
                {
                    var error = ModelState.Values.SelectMany(e => e.Errors).Select(er => er.ErrorMessage).ToArray();
                    return request.CreateResponse(HttpStatusCode.BadRequest, "ERROR: Vui lòng kiểm tra dữ liệu đầu vào. " + string.Join("; ", error));
                }

                SanBayModel objSanBay;
                HttpResponseMessage objResponseMsg;
                try
                {
                    objSanBay = m_objSanBayServ.Update(x_objSanBay.ConvertToSanBayModel());
                }
                catch (Exception)
                {
                    return request.CreateResponse(HttpStatusCode.BadRequest, "ERROR: Bạn vui lòng kiểm tra truong mcb, masbdi, masbden");
                }


                if (objSanBay == null)
                {
                    return request.CreateResponse(HttpStatusCode.BadRequest, "ERROR: Vui lòng kiểm tra dữ liệu đầu vào");
                }

                SanBayViewModel objSanBayVM = objSanBay.Map<SanBayModel, SanBayViewModel>(() =>
                {
                    var configuration = new MapperConfiguration(cfg => {
                        cfg.CreateMap<SanBayModel, SanBayViewModel>();
                    });
                    IMapper mapper = configuration.CreateMapper();
                    return mapper;
                });

                try
                {
                    objResponseMsg = request.CreateResponse(HttpStatusCode.OK);
                    objResponseMsg.Content = new StringContent(JsonConvert.SerializeObject(objSanBayVM));
                }
                catch (System.Exception ex)
                {
                    return request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
                }

                return objResponseMsg;
            });
        }

        [HttpDelete]
        [Route("delete")]
        public HttpResponseMessage Delete(HttpRequestMessage request, SanBayViewModel x_objSanBay)
        {
            return CreateHttpResponeMsg(() =>
            {
                if (x_objSanBay.MaSanBay == null || x_objSanBay.TenSanBay == null || x_objSanBay.ThanhPho == null || x_objSanBay.QuocGia == null)
                {
                    return request.CreateResponse(HttpStatusCode.BadRequest, "ERROR: masb, tensb, tp, quocgia không được phép null");
                }

                if (ModelState.IsValid == false)
                {
                    var error = ModelState.Values.SelectMany(e => e.Errors).Select(er => er.ErrorMessage).ToArray();
                    return request.CreateResponse(HttpStatusCode.BadRequest, "ERROR: Vui lòng kiểm tra dữ liệu đầu vào. " + string.Join("; ", error));
                }

                SanBayModel objSanBay;
                HttpResponseMessage objResponseMsg;
                try
                {
                    objSanBay = m_objSanBayServ.Delete(x_objSanBay.ConvertToSanBayModel());
                }
                catch (Exception)
                {
                    return request.CreateResponse(HttpStatusCode.BadRequest, "ERROR: Bạn vui lòng kiểm tra truong mcb, masbdi, masbden");
                }


                if (objSanBay == null)
                {
                    return request.CreateResponse(HttpStatusCode.BadRequest, "ERROR: Vui lòng kiểm tra dữ liệu đầu vào");
                }

                SanBayViewModel objSanBayVM = objSanBay.Map<SanBayModel, SanBayViewModel>(() =>
                {
                    var configuration = new MapperConfiguration(cfg => {
                        cfg.CreateMap<SanBayModel, SanBayViewModel>();
                    });
                    IMapper mapper = configuration.CreateMapper();
                    return mapper;
                });

                try
                {
                    objResponseMsg = request.CreateResponse(HttpStatusCode.OK);
                    objResponseMsg.Content = new StringContent(JsonConvert.SerializeObject(objSanBayVM));
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