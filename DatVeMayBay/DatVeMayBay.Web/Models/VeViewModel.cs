using DatVeMayBay.Web.Infrastructure.Extension;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace DatVeMayBay.Web.Models
{
    [JsonObject("ve", IsReference = true)]
    public class VeViewModel
    {
        [JsonProperty("mave")]
        public string MaVe { get; set; }

        [JsonProperty("tgdat")]
        [JsonConverter(typeof(CustomDatetimeConverter))]
        public DateTime? ThoiGianDat { get; set; }

        [JsonProperty("namdat")]
        public int? NamDat
        {
            get
            {
                if(ThoiGianDat != null)
                {
                    return ThoiGianDat.Value.Year;
                }
                return null;
            }
            set { }
        }

        [JsonProperty("thangdat")]
        public int? ThangDat
        {
            get
            {
                if (ThoiGianDat != null)
                {
                    return ThoiGianDat.Value.Month;
                }
                return null;
            }
        }

        [JsonProperty("ngaydat")]
        public int? NgayDat
        {
            get
            {
                if (ThoiGianDat != null)
                {
                    return ThoiGianDat.Value.Day;
                }
                return null;
            }
        }

        [JsonProperty("giodat")]
        public int? GioDat
        {
            get
            {
                if (ThoiGianDat != null)
                {
                    return ThoiGianDat.Value.Hour;
                }
                return null;
            }
        }

        [JsonProperty("phutdat")]
        public int? PhutDat
        {
            get
            {
                if (ThoiGianDat != null)
                {
                    return ThoiGianDat.Value.Minute;
                }
                return null;
            }
        }

        [JsonProperty("soghe")]
        public string SoGhe { get; set; }

        [JsonProperty("gia")]
        public float? GiaVe { get; set; }

        [JsonProperty("dadat")]
        public bool DaDat { get; set; }

        [JsonIgnore]
        [JsonProperty("macb")]
        public string MaChuyenBay { get; set; }

        [JsonIgnore]
        [JsonProperty("mahd")]
        public int? MaHoaDon { get; set; }

        [JsonIgnore]
        [JsonProperty("cmnd")]
        public string CMND { get; set; }

        [JsonProperty("chuyenbay")]
        public ChuyenBayViewModel ChuyenBay { get; set; }

        [JsonProperty("hoadon")]
        public HoaDonViewModel HoaDon { get; set; }
    }
}