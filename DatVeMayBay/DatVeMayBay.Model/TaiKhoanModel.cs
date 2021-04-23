using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatVeMayBay.Model
{
    [Table("TAIKHOAN")]
    public class TaiKhoanModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; } 

        [Required]
        [MaxLength(20)]
        public string TaiKhoan { get; set; }

        [Required]
        [MaxLength(20)]
        public string MatKhau { get; set; }

        [Required]
        [MaxLength(10)]
        public string QuyenHan { get; set; }

        public TaiKhoanModel()
        {

        }

        public TaiKhoanModel(string x_strTaiKhoan, string x_strMatKhau, string x_strQuyenHan)
        {
            TaiKhoan = x_strTaiKhoan;
            MatKhau = x_strMatKhau;
            QuyenHan = x_strQuyenHan;
        }
    }
}
