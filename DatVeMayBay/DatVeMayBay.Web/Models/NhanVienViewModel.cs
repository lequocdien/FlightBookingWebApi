using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatVeMayBay.Web.Models
{
    [JsonObject("nhanvien")]
    public class NhanVienViewModel
    {
        [JsonProperty("manv")]
        public string MaNhanVien { get; set; }

        [JsonProperty("cmnd")]
        public string CMND { get; set; }

        [JsonProperty("ho")]
        public string Ho { get; set; }

        [JsonProperty("ten")]
        public string Ten { get; set; }

        [JsonProperty("diachi")]
        public string DiaChi { get; set; }

        [JsonProperty("ghichu")]
        public string GhiChu { get; set; }

        [JsonProperty("hoadons")]
        public IEnumerable<HoaDonViewModel> HoaDons { get; set; }
    }
}