namespace DatVeMayBay.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBFinal : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CHUYENBAY",
                c => new
                    {
                        MaChuyenBay = c.String(nullable: false, maxLength: 10),
                        MaSanBayDi = c.String(maxLength: 10),
                        MaSanBayDen = c.String(maxLength: 10),
                        ThoiGianDiDuKien = c.DateTime(nullable: false),
                        ThoiGianDenDuKien = c.DateTime(nullable: false),
                        DangHoatDong = c.Boolean(nullable: false),
                        GhiChu = c.String(maxLength: 250),
                        MaMayBay = c.String(maxLength: 10),
                        Test = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaChuyenBay)
                .ForeignKey("dbo.MAYBAY", t => t.MaMayBay)
                .ForeignKey("dbo.SANBAY", t => t.MaSanBayDen)
                .ForeignKey("dbo.SANBAY", t => t.MaSanBayDi)
                .Index(t => t.MaSanBayDi)
                .Index(t => t.MaSanBayDen)
                .Index(t => t.MaMayBay);
            
            CreateTable(
                "dbo.MAYBAY",
                c => new
                    {
                        MaMayBay = c.String(nullable: false, maxLength: 10),
                        TenMayBay = c.String(nullable: false, maxLength: 50),
                        TongSoGhe = c.Int(),
                        SoGheHang1 = c.Int(),
                        SoGheHang2 = c.Int(),
                    })
                .PrimaryKey(t => t.MaMayBay)
                .Index(t => t.TenMayBay, unique: true, name: "UK_TenMayBay");
            
            CreateTable(
                "dbo.SANBAY",
                c => new
                    {
                        MaSanBay = c.String(nullable: false, maxLength: 10),
                        TenSanBay = c.String(nullable: false, maxLength: 50),
                        ThanhPho = c.String(nullable: false, maxLength: 50),
                        QuocGia = c.String(nullable: false, maxLength: 50),
                        GhiChu = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.MaSanBay)
                .Index(t => t.TenSanBay, unique: true, name: "UK_TenSanBay");
            
            CreateTable(
                "dbo.VE",
                c => new
                    {
                        MaVe = c.String(nullable: false, maxLength: 10),
                        ThoiGianDat = c.DateTime(),
                        SoGhe = c.String(nullable: false, maxLength: 10),
                        GiaVe = c.Single(),
                        DaDat = c.Boolean(nullable: false),
                        MaChuyenBay = c.String(nullable: false, maxLength: 10),
                        MaHoaDon = c.Int(),
                    })
                .PrimaryKey(t => t.MaVe)
                .ForeignKey("dbo.HOADON", t => t.MaHoaDon)
                .ForeignKey("dbo.CHUYENBAY", t => t.MaChuyenBay, cascadeDelete: true)
                .Index(t => t.MaChuyenBay)
                .Index(t => t.MaHoaDon);
            
            CreateTable(
                "dbo.HOADON",
                c => new
                    {
                        MaHoaDon = c.Int(nullable: false, identity: true),
                        NgayLap = c.DateTime(nullable: false),
                        ThanhTien = c.Single(nullable: false),
                        DaThanhToan = c.Boolean(nullable: false),
                        GhiChu = c.String(maxLength: 250),
                        MaNhanVien = c.String(maxLength: 10),
                        CMND = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.MaHoaDon)
                .ForeignKey("dbo.KHACHHANG", t => t.CMND)
                .ForeignKey("dbo.NHANVIEN", t => t.MaNhanVien)
                .Index(t => t.MaNhanVien)
                .Index(t => t.CMND);
            
            CreateTable(
                "dbo.KHACHHANG",
                c => new
                    {
                        CMND = c.String(nullable: false, maxLength: 10),
                        Ho = c.String(maxLength: 50),
                        Ten = c.String(maxLength: 50),
                        SDT = c.String(maxLength: 10),
                        GioiTinh = c.Boolean(),
                        Email = c.String(maxLength: 50),
                        GhiChu = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.CMND);
            
            CreateTable(
                "dbo.NHANVIEN",
                c => new
                    {
                        MaNhanVien = c.String(nullable: false, maxLength: 10),
                        CMND = c.String(maxLength: 10),
                        Ho = c.String(),
                        Ten = c.String(),
                        DiaChi = c.String(),
                        GhiChu = c.String(),
                    })
                .PrimaryKey(t => t.MaNhanVien)
                .Index(t => t.CMND, unique: true, name: "UK_CMND");
            
            CreateTable(
                "dbo.TAIKHOAN",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TaiKhoan = c.String(nullable: false, maxLength: 20),
                        MatKhau = c.String(nullable: false, maxLength: 20),
                        QuyenHan = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VE", "MaChuyenBay", "dbo.CHUYENBAY");
            DropForeignKey("dbo.VE", "MaHoaDon", "dbo.HOADON");
            DropForeignKey("dbo.HOADON", "MaNhanVien", "dbo.NHANVIEN");
            DropForeignKey("dbo.HOADON", "CMND", "dbo.KHACHHANG");
            DropForeignKey("dbo.CHUYENBAY", "MaSanBayDi", "dbo.SANBAY");
            DropForeignKey("dbo.CHUYENBAY", "MaSanBayDen", "dbo.SANBAY");
            DropForeignKey("dbo.CHUYENBAY", "MaMayBay", "dbo.MAYBAY");
            DropIndex("dbo.NHANVIEN", "UK_CMND");
            DropIndex("dbo.HOADON", new[] { "CMND" });
            DropIndex("dbo.HOADON", new[] { "MaNhanVien" });
            DropIndex("dbo.VE", new[] { "MaHoaDon" });
            DropIndex("dbo.VE", new[] { "MaChuyenBay" });
            DropIndex("dbo.SANBAY", "UK_TenSanBay");
            DropIndex("dbo.MAYBAY", "UK_TenMayBay");
            DropIndex("dbo.CHUYENBAY", new[] { "MaMayBay" });
            DropIndex("dbo.CHUYENBAY", new[] { "MaSanBayDen" });
            DropIndex("dbo.CHUYENBAY", new[] { "MaSanBayDi" });
            DropTable("dbo.TAIKHOAN");
            DropTable("dbo.NHANVIEN");
            DropTable("dbo.KHACHHANG");
            DropTable("dbo.HOADON");
            DropTable("dbo.VE");
            DropTable("dbo.SANBAY");
            DropTable("dbo.MAYBAY");
            DropTable("dbo.CHUYENBAY");
        }
    }
}
