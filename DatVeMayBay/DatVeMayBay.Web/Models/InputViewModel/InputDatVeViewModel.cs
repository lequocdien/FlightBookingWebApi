using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatVeMayBay.Web.Models
{
    [JsonObject("datve")]
    public class InputDatVeViewModel
    {
        [JsonProperty("cmnd")]
        public string CMND { get; set; }

        [JsonProperty("thanhtien")]
        public float ThanhTien { get; set; }

        [JsonProperty("macb")]
        public string MaChuyenBay { get; set; }
    }
}