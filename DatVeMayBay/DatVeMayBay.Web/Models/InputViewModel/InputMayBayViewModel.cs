using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatVeMayBay.Web.Models.InputViewModel
{
    public class InputMayBayViewModel
    {
        [JsonProperty("mamb")]
        public string MaMayBay { get; set; }

        [JsonProperty("tenmb")]
        public string TenMayBay { get; set; }

        [JsonProperty("tongsoghe")]
        public int TongSoGhe { get; set; }

        [JsonProperty("soghehang1")]
        public int SoGheHang1 { get; set; }

        [JsonProperty("soghehang2")]
        public int SoGheHang2 { get; set; }
    }
}