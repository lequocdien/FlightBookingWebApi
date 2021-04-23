using DatVeMayBay.Web.Infrastructure.Extension;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatVeMayBay.Web.Models.InputViewModel
{
    public class InputInsertChuyenBayViewModel
    {
        [JsonProperty("macb")]
        public string MaChuyenBay { get; set; }

        [JsonProperty("masbdi")]
        public string MaSanBayDi { get; set; }

        [JsonProperty("masbden")]
        public string MaSanBayDen { get; set; }

        [JsonProperty("tgdi")]
        [JsonConverter(typeof(CustomDatetimeConverter))]
        public DateTime ThoiGianDi { get; set; }

        [JsonProperty("tgden")]
        [JsonConverter(typeof(CustomDatetimeConverter))]
        public DateTime ThoiGianDen { get; set; }

        [JsonProperty("dadat")]
        public bool DaDat { get; set; }

        [JsonProperty("mamb")]
        public string MaMayBay { get; set; }

        [JsonProperty("ghichu")]
        public string GhiChu { get; set; }
    }
}