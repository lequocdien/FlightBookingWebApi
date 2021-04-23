using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatVeMayBay.Model
{
    [Table("VE")]
    public class VeModel
    {
        [Key]
        [MaxLength(10)]
        public string MaVe { get; set; }

        public DateTime? ThoiGianDat { get; set; }

        [Required]
        [MaxLength(10)]
        public string SoGhe { get; set; }

        public float? GiaVe { get; set; }

        [Required]
        public bool DaDat { get; set; }

        [Required]
        [MaxLength(10)]
        public string MaChuyenBay { get; set; }

        public int? MaHoaDon { get; set; }

        [ForeignKey("MaChuyenBay")]
        public ChuyenBayModel ChuyenBay { get; set; }

        [ForeignKey("MaHoaDon")]
        public HoaDonModel HoaDon { get; set; }

        public VeModel()
        {

        }

        //public VeModel(string x_strMV, DateTime x_dtNgayDat, string x_strSoGhe, float x_fGiaVe, int x_nTrangThai, string x_strMaChuyenBay, string x_strCMND, string x_strMaHoaDon)
        //{
        //    MaVe = x_strMV;
        //    NgayDat = x_dtNgayDat;
        //    SoGhe = x_strSoGhe;
        //    GiaVe = x_fGiaVe;
        //    TrangThai = x_nTrangThai;
        //    MaChuyenBay = x_strMaChuyenBay;
        //    CMND = x_strCMND;
        //    MaHoaDon = x_strMaHoaDon;
        //}
    }
}
