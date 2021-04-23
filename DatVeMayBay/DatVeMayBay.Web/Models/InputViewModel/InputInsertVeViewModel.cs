using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatVeMayBay.Web.Models.InputViewModel
{
    public class InputInsertVeViewModel
    {
        [JsonProperty("mave")]
        public string MaVe { get; set; }

        [JsonProperty("soghe")]
        public string SoGhe { get; set; }

        //[JsonProperty("dadat")]
        //public bool DaDat { get; set; }

        [JsonProperty("macb")]
        public string MaChuyenBay { get; set; }

        [JsonProperty("gia")]
        public float? GiaVe { get; set; }
    }
}