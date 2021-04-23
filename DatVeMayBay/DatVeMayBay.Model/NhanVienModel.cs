using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatVeMayBay.Model
{
    [Table("NHANVIEN")]
    public class NhanVienModel
    {
        [Key]
        [MaxLength(10)]
        public string MaNhanVien { get; set; }

        [MaxLength(10)]
        [Index("UK_CMND", IsUnique = true)]
        public string CMND { get; set; }

        public string Ho { get; set; }

        public string Ten { get; set; }

        public string DiaChi { get; set; }

        public string GhiChu { get; set; }

        [InverseProperty("NhanVien")]
        public ICollection<HoaDonModel> HoaDons { get; set; }

        public NhanVienModel()
        {

        }

        public NhanVienModel(string x_strMNV, string x_strCMND, string x_strHo, string x_strTen, string x_strDiaChi, string x_strGhiChu)
        {
            MaNhanVien = x_strMNV;
            CMND = x_strCMND;
            Ho = x_strHo;
            Ten = x_strTen;
            DiaChi = x_strDiaChi;
            GhiChu = x_strGhiChu;
        }
    }
}
