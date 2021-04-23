using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DatVeMayBay.Web.Models
{
    [JsonObject("chuyenbay", IsReference = true)]
    public class ChuyenBayViewModel
    {
        [JsonProperty("macb")]
        public string MaChuyenBay { get; set; }

        [JsonIgnore]
        public string MaSanBayDi { get; set; }

        [JsonIgnore]
        public string MaSanBayDen { get; set; }

        [JsonProperty("tgdi")]
        public DateTime ThoiGianDiDuKien { get; set; }

        [JsonProperty("gioidi")]
        public int GioDiDuKien
        {
            get
            {
                return ThoiGianDiDuKien.Hour;
            }
            private set
            {

            }
        }

        [JsonProperty("phutdi")]
        public int PhutDenDiKien
        {
            get
            {
                return ThoiGianDiDuKien.Minute;
            }
            private set
            {

            }
        }

        [JsonProperty("ngaydi")]
        public int NgayDiDuKien
        {
            get
            {
                return ThoiGianDiDuKien.Day;
            }
            private set
            {

            }
        }

        [JsonProperty("thangdi")]
        public int ThangDiDuKien
        {
            get
            {
                return ThoiGianDiDuKien.Month;
            }
            private set
            {

            }
        }

        [JsonProperty("namdi")]
        public int NamDiDuKien
        {
            get
            {
                return ThoiGianDiDuKien.Year;
            }
            private set
            {

            }
        }

        [JsonProperty("tgden")]
        public DateTime ThoiGianDenDuKien { get; set; }

        [JsonProperty("gioden")]
        public int GioDenDuKien
        {
            get
            {
                return ThoiGianDenDuKien.Hour;
            }
            private set
            {

            }
        }

        [JsonProperty("phutden")]
        public int PhutDenDuKien
        {
            get
            {
                return ThoiGianDenDuKien.Minute;
            }
            private set
            {

            }
        }

        [JsonProperty("ngayden")]
        public int NgayDenDuKien
        {
            get
            {
                return ThoiGianDenDuKien.Day;
            }
            private set
            {

            }
        }

        [JsonProperty("thangden")]
        public int ThangDenDuKien
        {
            get
            {
                return ThoiGianDenDuKien.Month;
            }
            private set
            {

            }
        }

        [JsonProperty("namden")]
        public int NamDenDuKien
        {
            get
            {
                return ThoiGianDenDuKien.Year;
            }
            private set
            {

            }
        }

        [JsonProperty("sbdi")]
        public virtual SanBayViewModel SanBayDi { get; set; }

        [JsonProperty("sbden")]
        public virtual SanBayViewModel SanBayDen { get; set; }

        [JsonProperty("danghoatdong")]
        public bool DangHoatDong { get; set; }

        [JsonProperty("ghichu")]
        public string GhiChu { get; set; }

        [JsonIgnore]
        public string MaMayBay { get; set; }

        [JsonProperty("maybay")]
        public MayBayViewModel MayBay { get; set; }

        [JsonProperty("giave")]
        public float? GiaVe
        {
            get
            {
                if (Ves != null && Ves.Count > 0)
                {
                    return ((List<VeViewModel>)Ves)[0].GiaVe;
                }
                return null;
            }
            set { }
        }

        [JsonProperty("ves")]
        public ICollection<VeViewModel> Ves { get; set; }
    }
}