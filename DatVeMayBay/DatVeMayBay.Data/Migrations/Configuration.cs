namespace DatVeMayBay.Data.Migrations
{
    using DatVeMayBay.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DatVeMayBay.Data.Context.DatVeMayBayDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DatVeMayBay.Data.Context.DatVeMayBayDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.SanBays.AddOrUpdate(
                new SanBayModel()
                {
                    MaSanBay = "SGN",
                    TenSanBay = "Sân bay Tân Sơn Nhất - SGN",
                    QuocGia = "Việt Nam",
                    ThanhPho = "Tp. Hồ Chí Minh"
                },
                 new SanBayModel()
                 {
                     MaSanBay = "HAN",
                     TenSanBay = "Sân bay Nội Bài - HAN",
                     QuocGia = "Việt Nam",
                     ThanhPho = "Hà Nội"
                 }
           );
        }
    }
}
