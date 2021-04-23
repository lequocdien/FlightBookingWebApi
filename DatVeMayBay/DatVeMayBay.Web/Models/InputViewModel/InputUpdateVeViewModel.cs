using DatVeMayBay.Web.Infrastructure.Extension;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatVeMayBay.Web.Models
{
    public class InputUpdateVeViewModel
    {
        [JsonProperty("mave")]
        public string MaVe { get; set; }

        [JsonProperty("soghe")]
        public string SoGhe { get; set; }

        [JsonProperty("macb")]
        public string MaChuyenBay { get; set; }

        [JsonProperty("gia")]
        public float? GiaVe { get; set; }

        //[JsonProperty("tgdat")]
        //[JsonConverter(typeof(CustomDatetimeConverter))]
        //public DateTime? ThoiGianDat { get; set; }

        //[JsonProperty("mahd")]
        //public int? MaHoaDon { get; set; }

        //[JsonProperty("dadat")]
        //public bool DaDat { get; set; }
    }
}