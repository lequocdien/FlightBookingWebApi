using AutoMapper;
using DatVeMayBay.Common.ExtenstionMethod;
using DatVeMayBay.Model;
using DatVeMayBay.Service;
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
    [RoutePrefix("api/tai-khoan")]
    public class TaiKhoanApiController : ApiControllerBase
    {
        private ITaiKhoanService m_objTKService;

        public TaiKhoanApiController(ITaiKhoanService x_objTKServ)
        {
            this.m_objTKService = x_objTKServ;
        }

        [Route("get-all")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponeMsg(() => {
                HttpResponseMessage response = null;
                List<TaiKhoanModel> lstTKModel = (List<TaiKhoanModel>)m_objTKService.GetAll();
                List<TaiKhoanViewModel> lstTKVM = lstTKModel.Map<List<TaiKhoanModel>, List<TaiKhoanViewModel>>(() =>
                {
                    var configuration = new MapperConfiguration(cfg => {
                        cfg.CreateMap<TaiKhoanModel, TaiKhoanViewModel>();
                    });
                    IMapper mapper = configuration.CreateMapper();
                    return mapper;
                });
                response = request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(JsonConvert.SerializeObject(lstTKVM));
                return response;
            });
        }

        [Route("get-by-username")]
        [HttpPost]
        public HttpResponseMessage GetAll(HttpRequestMessage request, InputTaiKhoanViewModel input)
        {
            return CreateHttpResponeMsg(() => {
                HttpResponseMessage response = null;
                List<TaiKhoanModel> lstTKModel = (List<TaiKhoanModel>)m_objTKService.GetAll();
                List<TaiKhoanViewModel> lstTKVM = lstTKModel.Map<List<TaiKhoanModel>, List<TaiKhoanViewModel>>(() =>
                {
                    var configuration = new MapperConfiguration(cfg => {
                        cfg.CreateMap<TaiKhoanModel, TaiKhoanViewModel>();
                    });
                    IMapper mapper = configuration.CreateMapper();
                    return mapper;
                });
                response = request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(JsonConvert.SerializeObject(lstTKVM));
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