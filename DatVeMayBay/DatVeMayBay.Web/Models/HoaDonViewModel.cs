using DatVeMayBay.Web.Infrastructure.Extension;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DatVeMayBay.Web.Models
{
    [JsonObject("hoadon", IsReference = true)]
    public class HoaDonViewModel
    {
        [JsonProperty("mahd")]
        public int MaHoaDon { get; set; }

        [JsonProperty("tglap")]
        [JsonConverter(typeof(CustomDatetimeConverter))]
        public DateTime? NgayLap { get; set; }

        [JsonProperty("thanhtien")]
        public float ThanhTien { get; set; }

        [JsonProperty("dathanhtoan")]
        public bool DaThanhToan { get; set; }

        [JsonProperty("ghichu")]
        public string GhiChu { get; set; }

        [JsonIgnore]
        [JsonProperty("manv")]
        public string MaNhanVien { get; set; }

        [JsonIgnore]
        [JsonProperty("cmnd")]
        public string CMND { get; set; }

        [JsonProperty("nhanvien")]
        public NhanVienViewModel NhanVien { get; set; }

        [JsonProperty("khachhang")]
        public KhachHangViewModel KhachHang { get; set; }

        [JsonProperty("ves")]
        public ICollection<VeViewModel> Ves { get; set; }
    }
}