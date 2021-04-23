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
    [RoutePrefix("api/may-bay")]
    public class MayBayApiController : ApiControllerBase
    {
        private IMayBayService m_objMBServ;

        public MayBayApiController(IMayBayService x_objMBServ)
        {
            this.m_objMBServ = x_objMBServ;
        }

        [HttpGet]
        [Route("get-all")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponeMsg(() => {
                HttpResponseMessage response = null;
                List<MayBayModel> lstMBModel = (List<MayBayModel>)m_objMBServ.GetAll();
                List<MayBayViewModel> lstMBVM = lstMBModel.Map<List<MayBayModel>, List<MayBayViewModel>>(() =>
                {
                    var configuration = new MapperConfiguration(cfg => {
                        cfg.CreateMap<MayBayModel, MayBayViewModel>();
                    });
                    IMapper mapper = configuration.CreateMapper();
                    return mapper;
                });
                response = request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(JsonConvert.SerializeObject(lstMBVM));
                return response;
            });
        }

        [HttpPost]
        [Route("insert")]
        public HttpResponseMessage Insert(HttpRequestMessage request, MayBayViewModel x_objMayBay)
        {
            return CreateHttpResponeMsg(() => {
                HttpResponseMessage response = null;
                MayBayModel MBModel = m_objMBServ.Insert(x_objMayBay.ConvertToMayBayModel());
                MayBayViewModel objMbVM = MBModel.Map<MayBayModel, MayBayViewModel>(() =>
                {
                    var configuration = new MapperConfiguration(cfg => {
                        cfg.CreateMap<MayBayModel, MayBayViewModel>();
                    });
                    IMapper mapper = configuration.CreateMapper();
                    return mapper;
                });
                response = request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(JsonConvert.SerializeObject(objMbVM));
                return response;
            });
        }

        [HttpPut]
        [Route("update")]
        public HttpResponseMessage Update(HttpRequestMessage request, MayBayViewModel x_objMayBay)
        {
            return CreateHttpResponeMsg(() => {
                HttpResponseMessage response = null;
                MayBayModel MBModel = m_objMBServ.Update(x_objMayBay.ConvertToMayBayModel());
                MayBayViewModel objMbVM = MBModel.Map<MayBayModel, MayBayViewModel>(() =>
                {
                    var configuration = new MapperConfiguration(cfg => {
                        cfg.CreateMap<MayBayModel, MayBayViewModel>();
                    });
                    IMapper mapper = configuration.CreateMapper();
                    return mapper;
                });
                response = request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(JsonConvert.SerializeObject(objMbVM));
                return response;
            });
        }

        [HttpDelete]
        [Route("delete")]
        public HttpResponseMessage Delete(HttpRequestMessage request, MayBayViewModel x_objMayBay)
        {
            return CreateHttpResponeMsg(() => {
                HttpResponseMessage response = null;
                MayBayModel MBModel = m_objMBServ.Delete(x_objMayBay.ConvertToMayBayModel());
                MayBayViewModel objMbVM = MBModel.Map<MayBayModel, MayBayViewModel>(() =>
                {
                    var configuration = new MapperConfiguration(cfg => {
                        cfg.CreateMap<MayBayModel, MayBayViewModel>();
                    });
                    IMapper mapper = configuration.CreateMapper();
                    return mapper;
                });
                response = request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(JsonConvert.SerializeObject(objMbVM));
                return response;
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