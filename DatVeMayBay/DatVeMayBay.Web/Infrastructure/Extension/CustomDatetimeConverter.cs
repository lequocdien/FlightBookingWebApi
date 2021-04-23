using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatVeMayBay.Web.Infrastructure.Extension
{
    public class CustomDatetimeConverter : IsoDateTimeConverter
    {
        public CustomDatetimeConverter()
        {
            base.DateTimeFormat = "dd-MM-yyyyTHH:mm:ss";
        }
    }
}