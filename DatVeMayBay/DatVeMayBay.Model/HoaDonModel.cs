using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatVeMayBay.Model
{
    [Table("HOADON")]
    public class HoaDonModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaHoaDon { get; set; }

        public DateTime NgayLap { get; set; }

        public float ThanhTien { get; set; }

        [Required]
        public bool DaThanhToan { get; set; }

        [MaxLength(250)]
        public string GhiChu { get; set; }

        [MaxLength(10)]
        public string MaNhanVien { get; set; }

        [MaxLength(10)]
        public string CMND { get; set; }

        [ForeignKey("MaNhanVien")]
        public NhanVienModel NhanVien { get; set; }

        [ForeignKey("CMND")]
        public KhachHangModel KhachHang { get; set; }

        [InverseProperty("HoaDon")]
        public ICollection<VeModel> Ves { get; set; }

        public HoaDonModel()
        {

        }

        public HoaDonModel(int x_nMaHoaDon, DateTime x_dtNgayLap, float x_fThanhTien, bool x_bDaThanhToan, string x_strGhiChu, string x_strMaNV)
        {
            MaHoaDon = x_nMaHoaDon;
            NgayLap = x_dtNgayLap;
            ThanhTien = x_fThanhTien;
            DaThanhToan = x_bDaThanhToan;
            GhiChu = x_strGhiChu;
            MaNhanVien = x_strMaNV;
        }
    }
}
