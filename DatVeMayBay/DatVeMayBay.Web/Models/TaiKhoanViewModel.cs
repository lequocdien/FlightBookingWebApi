using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatVeMayBay.Web.Models
{
    [JsonObject("taikhoan")]
    public class TaiKhoanViewModel
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("username")]
        public string TaiKhoan { get; set; }

        [JsonProperty("password")]
        public string MatKhau { get; set; }

        [JsonProperty("role")]
        public string QuyenHan { get; set; }
    }
}