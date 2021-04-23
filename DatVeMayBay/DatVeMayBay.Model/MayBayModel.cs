using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatVeMayBay.Model
{
    [Table("MAYBAY")]
    public class MayBayModel
    {
        [Key]
        [MaxLength(10)]
        public string MaMayBay { get; set; }

        [Required]
        [Index("UK_TenMayBay", IsUnique = true)]
        [MaxLength(50)]
        public string TenMayBay { get; set; }

        public int? TongSoGhe { get; set; }

        public int? SoGheHang1 { get; set; }

        public int? SoGheHang2 { get; set; }

        [InverseProperty("MayBay")]
        public ICollection<ChuyenBayModel> ChuyenBays { get; set; }

        public MayBayModel()
        {

        }

        public MayBayModel(string x_strMMB, string x_strTenMayBay, int x_nTongSoGhe, int x_nSoGheHag1, int x_nSoGheHag2)
        {
            MaMayBay = x_strMMB;
            TenMayBay = x_strTenMayBay;
            TongSoGhe = x_nTongSoGhe;
            SoGheHang1 = x_nSoGheHag1;
            SoGheHang2 = x_nSoGheHag2;
        }
    }
}
