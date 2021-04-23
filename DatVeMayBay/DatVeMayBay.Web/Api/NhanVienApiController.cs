using AutoMapper;
using DatVeMayBay.Common.ExtenstionMethod;
using DatVeMayBay.Model;
using DatVeMayBay.Service;
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
    [RoutePrefix("api/nhan-vien")]
    public class NhanVienApiController : ApiControllerBase
    {
        private INhanVienService m_objNVServ;

        public NhanVienApiController(INhanVienService x_objNVServ)
        {
            this.m_objNVServ = x_objNVServ;
        }

        [Route("get-all")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponeMsg(() => {
                HttpResponseMessage response = null;
                List<NhanVienModel> lstNVModel = (List<NhanVienModel>)m_objNVServ.GetAll();
                List<NhanVienViewModel> lstNVVM = lstNVModel.Map<List<NhanVienModel>, List<NhanVienViewModel>>(() =>
                {
                    var configuration = new MapperConfiguration(cfg => {
                        cfg.CreateMap<NhanVienModel, NhanVienViewModel>();
                    });
                    IMapper mapper = configuration.CreateMapper();
                    return mapper;
                });
                response = request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(JsonConvert.SerializeObject(lstNVVM));
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