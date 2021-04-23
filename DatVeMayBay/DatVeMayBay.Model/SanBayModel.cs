using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatVeMayBay.Model
{
    [Table("SANBAY")]
    public class SanBayModel
    {
        [Key]
        [MaxLength(10)]
        public string MaSanBay { get; set; }

        [Required]
        [MaxLength(50)]
        [Index("UK_TenSanBay", IsUnique = true)]
        public string TenSanBay { get; set; }

        [Required]
        [MaxLength(50)]
        public string ThanhPho { get; set; }

        [Required]
        [MaxLength(50)]
        public string QuocGia { get; set; }

        [MaxLength(250)]
        public string GhiChu { get; set; }

        public SanBayModel(string x_strMaSanBay, string x_strTenSanBay, string x_strThanhPho, string x_strQuocGia, string x_strGhiChu)
        {
            MaSanBay = x_strMaSanBay;
            TenSanBay = x_strTenSanBay;
            ThanhPho = x_strThanhPho;
            QuocGia = x_strQuocGia;
            GhiChu = x_strGhiChu;
        }

        public SanBayModel()
        {

        }
    }
}
