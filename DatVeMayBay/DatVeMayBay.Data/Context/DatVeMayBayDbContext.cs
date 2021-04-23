using DatVeMayBay.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatVeMayBay.Data.Context
{
    public class DatVeMayBayDbContext : DbContext
    {
        public DatVeMayBayDbContext() : base("DatVeMayBayDbContext")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<TaiKhoanModel> TaiKhoans { get; set; }
        public DbSet<SanBayModel> SanBays { get; set; }
        public DbSet<MayBayModel> MayBays { get; set; }
        public DbSet<ChuyenBayModel> ChuyenBays { get; set; }
        public DbSet<KhachHangModel> KhachHangs { get; set; }
        public DbSet<VeModel> Ves { get; set; }
        public DbSet<NhanVienModel> NhanViens { get; set; }
        public DbSet<HoaDonModel> HoaDons { get; set; }
    }
}
