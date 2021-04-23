using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace DatVeMayBay.Web.Api
{
    public class ApiControllerBase : ApiController
    {
        public ApiControllerBase()
        {

        }

        protected HttpResponseMessage CreateHttpResponeMsg(Func<HttpResponseMessage> func)
        {
            try
            {
                return func.Invoke();
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            }
        }
    }
}