using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatVeMayBay.Model
{
    [Table("KHACHHANG")]
    public class KhachHangModel
    {
        [Key]
        [MaxLength(10)]
        public string CMND { get; set; }

        [MaxLength(50)]
        public string Ho { get; set; }

        [MaxLength(50)]
        public string Ten { get; set; }

        [MaxLength(10)]
        public string SDT { get; set; }

        public bool? GioiTinh { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(250)]
        public string GhiChu { get; set; }

        public IEnumerable<HoaDonModel> HoaDons { get; set; }

        public KhachHangModel()
        {

        }

        public KhachHangModel(string x_strCMND, string x_strHo, string x_strTen, string x_strSDT, bool x_bGioiTinh, string x_strEmail, string x_strGhiChu)
        {
            CMND = x_strCMND;
            Ho = x_strHo;
            Ten = x_strTen;
            SDT = x_strSDT;
            GioiTinh = x_bGioiTinh;
            Email = x_strEmail;
            GhiChu = x_strGhiChu;
        }
    }
}
