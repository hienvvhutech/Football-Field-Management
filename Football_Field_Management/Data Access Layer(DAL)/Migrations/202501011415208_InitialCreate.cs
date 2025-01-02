namespace Data_Access_Layer_DAL_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cas",
                c => new
                    {
                        MaCa = c.Int(nullable: false, identity: true),
                        GioBD = c.Time(nullable: false, precision: 7),
                        GioKT = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.MaCa);
            
            CreateTable(
                "dbo.ChiTietDatSans",
                c => new
                    {
                        MaChiTiet = c.Int(nullable: false, identity: true),
                        MaPhieu = c.Int(nullable: false),
                        MaSan = c.Int(nullable: false),
                        MaCa = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaChiTiet)
                .ForeignKey("dbo.Cas", t => t.MaCa, cascadeDelete: true)
                .ForeignKey("dbo.PhieuDatSans", t => t.MaPhieu, cascadeDelete: true)
                .ForeignKey("dbo.Sans", t => t.MaSan, cascadeDelete: true)
                .Index(t => t.MaPhieu)
                .Index(t => t.MaSan)
                .Index(t => t.MaCa);
            
            CreateTable(
                "dbo.PhieuDatSans",
                c => new
                    {
                        MaPhieu = c.Int(nullable: false, identity: true),
                        MaKH = c.Int(nullable: false),
                        NgayDat = c.DateTime(nullable: false),
                        TienCoc = c.Single(nullable: false),
                        GhiChu = c.String(),
                    })
                .PrimaryKey(t => t.MaPhieu)
                .ForeignKey("dbo.KhachHangs", t => t.MaKH, cascadeDelete: true)
                .Index(t => t.MaKH);
            
            CreateTable(
                "dbo.HoaDons",
                c => new
                    {
                        MaHD = c.Int(nullable: false, identity: true),
                        MaPhieu = c.Int(nullable: false),
                        NgayThanhToan = c.DateTime(nullable: false),
                        TongTien = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.MaHD)
                .ForeignKey("dbo.PhieuDatSans", t => t.MaPhieu, cascadeDelete: true)
                .Index(t => t.MaPhieu);
            
            CreateTable(
                "dbo.ChiTietHoaDons",
                c => new
                    {
                        MaChiTietHD = c.Int(nullable: false, identity: true),
                        MaHD = c.Int(nullable: false),
                        MaSan = c.Int(nullable: false),
                        MaCa = c.Int(nullable: false),
                        SoGio = c.Int(nullable: false),
                        DonGia = c.Single(nullable: false),
                        ThanhTien = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.MaChiTietHD)
                .ForeignKey("dbo.Cas", t => t.MaCa, cascadeDelete: true)
                .ForeignKey("dbo.HoaDons", t => t.MaHD, cascadeDelete: true)
                .ForeignKey("dbo.Sans", t => t.MaSan, cascadeDelete: true)
                .Index(t => t.MaHD)
                .Index(t => t.MaSan)
                .Index(t => t.MaCa);
            
            CreateTable(
                "dbo.Sans",
                c => new
                    {
                        MaSan = c.Int(nullable: false, identity: true),
                        TenSan = c.String(),
                        MaLoaiSan = c.Int(nullable: false),
                        TrangThai = c.String(),
                    })
                .PrimaryKey(t => t.MaSan)
                .ForeignKey("dbo.LoaiSans", t => t.MaLoaiSan, cascadeDelete: true)
                .Index(t => t.MaLoaiSan);
            
            CreateTable(
                "dbo.LoaiSans",
                c => new
                    {
                        MaLoaiSan = c.Int(nullable: false, identity: true),
                        TenLoaiSan = c.String(),
                        SoNguoiToiDa = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaLoaiSan);
            
            CreateTable(
                "dbo.KhachHangs",
                c => new
                    {
                        MaKH = c.Int(nullable: false, identity: true),
                        HoTen = c.String(),
                        SDT = c.String(),
                        DiaChi = c.String(),
                    })
                .PrimaryKey(t => t.MaKH);
            
            CreateTable(
                "dbo.GiaCas",
                c => new
                    {
                        MaGia = c.Int(nullable: false, identity: true),
                        MaLoaiSan = c.Int(nullable: false),
                        MaCa = c.Int(nullable: false),
                        Gia = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.MaGia)
                .ForeignKey("dbo.Cas", t => t.MaCa, cascadeDelete: true)
                .ForeignKey("dbo.LoaiSans", t => t.MaLoaiSan, cascadeDelete: true)
                .Index(t => t.MaLoaiSan)
                .Index(t => t.MaCa);
            
            CreateTable(
                "dbo.DangNhaps",
                c => new
                    {
                        TenDangNhap = c.String(nullable: false, maxLength: 128),
                        MatKhau = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TenDangNhap);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GiaCas", "MaLoaiSan", "dbo.LoaiSans");
            DropForeignKey("dbo.GiaCas", "MaCa", "dbo.Cas");
            DropForeignKey("dbo.PhieuDatSans", "MaKH", "dbo.KhachHangs");
            DropForeignKey("dbo.HoaDons", "MaPhieu", "dbo.PhieuDatSans");
            DropForeignKey("dbo.Sans", "MaLoaiSan", "dbo.LoaiSans");
            DropForeignKey("dbo.ChiTietHoaDons", "MaSan", "dbo.Sans");
            DropForeignKey("dbo.ChiTietDatSans", "MaSan", "dbo.Sans");
            DropForeignKey("dbo.ChiTietHoaDons", "MaHD", "dbo.HoaDons");
            DropForeignKey("dbo.ChiTietHoaDons", "MaCa", "dbo.Cas");
            DropForeignKey("dbo.ChiTietDatSans", "MaPhieu", "dbo.PhieuDatSans");
            DropForeignKey("dbo.ChiTietDatSans", "MaCa", "dbo.Cas");
            DropIndex("dbo.GiaCas", new[] { "MaCa" });
            DropIndex("dbo.GiaCas", new[] { "MaLoaiSan" });
            DropIndex("dbo.Sans", new[] { "MaLoaiSan" });
            DropIndex("dbo.ChiTietHoaDons", new[] { "MaCa" });
            DropIndex("dbo.ChiTietHoaDons", new[] { "MaSan" });
            DropIndex("dbo.ChiTietHoaDons", new[] { "MaHD" });
            DropIndex("dbo.HoaDons", new[] { "MaPhieu" });
            DropIndex("dbo.PhieuDatSans", new[] { "MaKH" });
            DropIndex("dbo.ChiTietDatSans", new[] { "MaCa" });
            DropIndex("dbo.ChiTietDatSans", new[] { "MaSan" });
            DropIndex("dbo.ChiTietDatSans", new[] { "MaPhieu" });
            DropTable("dbo.DangNhaps");
            DropTable("dbo.GiaCas");
            DropTable("dbo.KhachHangs");
            DropTable("dbo.LoaiSans");
            DropTable("dbo.Sans");
            DropTable("dbo.ChiTietHoaDons");
            DropTable("dbo.HoaDons");
            DropTable("dbo.PhieuDatSans");
            DropTable("dbo.ChiTietDatSans");
            DropTable("dbo.Cas");
        }
    }
}
