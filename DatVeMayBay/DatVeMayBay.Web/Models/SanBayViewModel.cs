using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DatVeMayBay.Web.Models
{
    [JsonObject("sanbay")]
    public class SanBayViewModel
    {
        [JsonProperty("masb")]
        public string MaSanBay { get; set; }

        [JsonProperty("tensb")]
        public string TenSanBay { get; set; }

        [JsonProperty("tp")]
        public string ThanhPho { get; set; }

        [JsonProperty("quocgia")]
        public string QuocGia { get; set; }

        [JsonProperty("ghichu")]
        public string GhiChu { get; set; }
    }
}