using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatVeMayBay.Model
{
    [Table("CHUYENBAY")]
    public class ChuyenBayModel
    {
        [Key]
        [MaxLength(10)]
        public string MaChuyenBay { get; set; }

        public string MaSanBayDi { get; set; }

        public string MaSanBayDen { get; set; }

        [Required]
        public DateTime ThoiGianDiDuKien { get; set; }

        [Required]
        public DateTime ThoiGianDenDuKien { get; set; }

        [Required]
        public bool DangHoatDong { get; set; }

        [MaxLength(250)]
        public string GhiChu { get; set; }

        [MaxLength(10)]
        public string MaMayBay { get; set; }

        [ForeignKey("MaSanBayDi")]
        public SanBayModel SanBayDi { get; set; }

        [ForeignKey("MaSanBayDen")]
        public SanBayModel SanBayDen { get; set; }

        [ForeignKey("MaMayBay")]
        public MayBayModel MayBay {get; set;}

        [InverseProperty("ChuyenBay")]
        public ICollection<VeModel> Ves { get; set; }

        public int Test { get; set; }

        public ChuyenBayModel()
        {

        }

        //public ChuyenBayModel(string x_strMCB, DateTime x_dtGioDiDK, DateTime x_dtGioDenDk, string x_strSBDi, string x_strSBDen, int x_nTrangThai, string x_strGhiChu, string x_strMaMayBay)
        //{
        //    MaChuyenBay = x_strMCB;
        //    ThoiGianDiDuKien = x_dtGioDiDK;
        //    ThoiGianDenDuKien = x_dtGioDenDk;
        //    SanBayDi = x_strSBDi;
        //    SanBayDen = x_strSBDen;
        //    TrangThai = x_nTrangThai;
        //    GhiChu = x_strGhiChu;
        //    MaMayBay = x_strMaMayBay;
        //    VeModels = new HashSet<VeModel>();
        //}

    }
}
