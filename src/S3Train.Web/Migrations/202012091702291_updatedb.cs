namespace S3Train.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CapQuyen",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        MaNhom = c.Guid(nullable: false),
                        MaCN = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ChucNang", t => t.MaCN, cascadeDelete: true)
                .ForeignKey("dbo.NhomNguoiDung", t => t.MaNhom, cascadeDelete: true)
                .Index(t => t.MaCN)
                .Index(t => t.MaNhom);
            
            CreateTable(
                "dbo.ChucNang",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenCN = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NhomNguoiDung",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenNhom = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NhanVien",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        MaCV = c.Guid(nullable: false),
                        TenNV = c.String(nullable: false, maxLength: 100),
                        HinhAnh = c.String(nullable: false, maxLength: 50),
                        DiaChi = c.String(nullable: false, maxLength: 200),
                        GioiTinh = c.String(nullable: false, maxLength: 10),
                        NgaySinh = c.DateTime(nullable: false),
                        SDT = c.String(nullable: false, maxLength: 10),
                        Email = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 100),
                        MaNhom = c.Guid(nullable: false),
                        CMND = c.String(nullable: false, maxLength: 9),
                        TrangThai = c.Boolean(nullable: false),
                        TenDN = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ChucVu", t => t.MaCV, cascadeDelete: true)
                .ForeignKey("dbo.NhomNguoiDung", t => t.MaNhom, cascadeDelete: true)
                .Index(t => t.MaCV)
                .Index(t => t.MaNhom);
            
            CreateTable(
                "dbo.ChucVu",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenCV = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CT_HoaDon",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        MaSP = c.Guid(nullable: false),
                        MaHD = c.Guid(nullable: false),
                        SoLuong = c.Int(nullable: false),
                        ThanhTien = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Gia = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HoaDon", t => t.MaHD, cascadeDelete: true)
                .ForeignKey("dbo.SanPham", t => t.MaSP, cascadeDelete: true)
                .Index(t => t.MaHD)
                .Index(t => t.MaSP);
            
            CreateTable(
                "dbo.HoaDon",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        MaPhuongThuc = c.Guid(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                        NgayLap = c.DateTime(nullable: false),
                        GhiChu = c.String(maxLength: 300),
                        NgayCapNhat = c.DateTime(nullable: false),
                        TrangThai = c.String(maxLength: 100),
                        TongTien = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.PhuongThucThanhToan", t => t.MaPhuongThuc, cascadeDelete: true)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.MaPhuongThuc);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        HoTen = c.String(),
                        QuocGia = c.String(),
                        ThanhPho = c.String(),
                        Quan = c.String(),
                        Phuong = c.String(),
                        DiaChi = c.String(),
                        NgaySinh = c.DateTime(nullable: false),
                        GioiTinh = c.String(),
                        TrangThai = c.Boolean(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.PhuongThucThanhToan",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenPhuongThuc = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SanPham",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenSP = c.String(nullable: false, maxLength: 300),
                        TacGia = c.String(nullable: false, maxLength: 100),
                        Gia = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TrongLuong = c.Single(nullable: false),
                        SoLuong = c.Int(nullable: false),
                        SoTrang = c.Int(nullable: false),
                        KichThuoc = c.String(nullable: false, maxLength: 100),
                        GhiChu = c.String(nullable: false, maxLength: 500),
                        ChatLuong = c.String(nullable: false, maxLength: 100),
                        MauSac = c.String(nullable: false, maxLength: 100),
                        NgayTao = c.DateTime(nullable: false),
                        NgayCapNhat = c.DateTime(nullable: false),
                        TrangThai = c.Boolean(nullable: false),
                        MaNN = c.Guid(nullable: false),
                        MaNSX = c.Guid(nullable: false),
                        MaLoai = c.Guid(nullable: false),
                        MaNCC = c.Guid(nullable: false),
                        LuotXem = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LoaiSanPham", t => t.MaLoai, cascadeDelete: true)
                .ForeignKey("dbo.NgonNgu", t => t.MaNN, cascadeDelete: true)
                .ForeignKey("dbo.NhaCungCap", t => t.MaNCC, cascadeDelete: true)
                .ForeignKey("dbo.NhaSanXuat", t => t.MaNSX, cascadeDelete: true)
                .Index(t => t.MaLoai)
                .Index(t => t.MaNN)
                .Index(t => t.MaNCC)
                .Index(t => t.MaNSX);
            
            CreateTable(
                "dbo.CT_KhuyenMai",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        MaSP = c.Guid(nullable: false),
                        MaKM = c.Guid(nullable: false),
                        SoLuong = c.Int(nullable: false),
                        PhanTramKM = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.KhuyenMai", t => t.MaKM, cascadeDelete: true)
                .ForeignKey("dbo.SanPham", t => t.MaSP, cascadeDelete: true)
                .Index(t => t.MaKM)
                .Index(t => t.MaSP);
            
            CreateTable(
                "dbo.KhuyenMai",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenKM = c.String(nullable: false, maxLength: 300),
                        ThoiGianBD = c.DateTime(nullable: false),
                        ThoiGianKT = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HinhAnh",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        MaSP = c.Guid(nullable: false),
                        TenLuuTepTin = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SanPham", t => t.MaSP, cascadeDelete: true)
                .Index(t => t.MaSP);
            
            CreateTable(
                "dbo.LoaiSanPham",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenLoai = c.String(nullable: false, maxLength: 50),
                        MaPhanLoai = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PhanLoai", t => t.MaPhanLoai, cascadeDelete: true)
                .Index(t => t.MaPhanLoai);
            
            CreateTable(
                "dbo.PhanLoai",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenPhanLoai = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NgonNgu",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenNN = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NhaCungCap",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenNCC = c.String(nullable: false, maxLength: 50),
                        DiaChiNCC = c.String(nullable: false, maxLength: 200),
                        SDTNCC = c.String(nullable: false, maxLength: 15),
                        MailNCC = c.String(nullable: false, maxLength: 100),
                        TTThemNCC = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NhaSanXuat",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenNSX = c.String(nullable: false, maxLength: 200),
                        ThongTinThem = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ManHinhTrangChu",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        MaSP = c.Guid(nullable: false),
                        Title = c.String(maxLength: 100),
                        Description = c.String(maxLength: 500),
                        EventUrl = c.String(nullable: false, maxLength: 50),
                        ImagePath = c.String(nullable: false, maxLength: 200),
                        AdType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SanPham", t => t.MaSP)
                .Index(t => t.MaSP);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ManHinhTrangChu", "MaSP", "dbo.SanPham");
            DropForeignKey("dbo.SanPham", "MaNSX", "dbo.NhaSanXuat");
            DropForeignKey("dbo.SanPham", "MaNCC", "dbo.NhaCungCap");
            DropForeignKey("dbo.SanPham", "MaNN", "dbo.NgonNgu");
            DropForeignKey("dbo.SanPham", "MaLoai", "dbo.LoaiSanPham");
            DropForeignKey("dbo.LoaiSanPham", "MaPhanLoai", "dbo.PhanLoai");
            DropForeignKey("dbo.HinhAnh", "MaSP", "dbo.SanPham");
            DropForeignKey("dbo.CT_KhuyenMai", "MaSP", "dbo.SanPham");
            DropForeignKey("dbo.CT_KhuyenMai", "MaKM", "dbo.KhuyenMai");
            DropForeignKey("dbo.CT_HoaDon", "MaSP", "dbo.SanPham");
            DropForeignKey("dbo.HoaDon", "MaPhuongThuc", "dbo.PhuongThucThanhToan");
            DropForeignKey("dbo.CT_HoaDon", "MaHD", "dbo.HoaDon");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.HoaDon", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.NhanVien", "MaNhom", "dbo.NhomNguoiDung");
            DropForeignKey("dbo.NhanVien", "MaCV", "dbo.ChucVu");
            DropForeignKey("dbo.CapQuyen", "MaNhom", "dbo.Order");
            DropForeignKey("dbo.CapQuyen", "MaCN", "dbo.ChucNang");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.ManHinhTrangChu", new[] { "MaSP" });
            DropIndex("dbo.LoaiSanPham", new[] { "MaPhanLoai" });
            DropIndex("dbo.HinhAnh", new[] { "MaSP" });
            DropIndex("dbo.CT_KhuyenMai", new[] { "MaSP" });
            DropIndex("dbo.CT_KhuyenMai", new[] { "MaKM" });
            DropIndex("dbo.SanPham", new[] { "MaNSX" });
            DropIndex("dbo.SanPham", new[] { "MaNCC" });
            DropIndex("dbo.SanPham", new[] { "MaNN" });
            DropIndex("dbo.SanPham", new[] { "MaLoai" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.HoaDon", new[] { "MaPhuongThuc" });
            DropIndex("dbo.HoaDon", new[] { "ApplicationUserId" });
            DropIndex("dbo.CT_HoaDon", new[] { "MaSP" });
            DropIndex("dbo.CT_HoaDon", new[] { "MaHD" });
            DropIndex("dbo.NhanVien", new[] { "MaNhom" });
            DropIndex("dbo.NhanVien", new[] { "MaCV" });
            DropIndex("dbo.CapQuyen", new[] { "MaNhom" });
            DropIndex("dbo.CapQuyen", new[] { "MaCN" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.ManHinhTrangChu");
            DropTable("dbo.NhaSanXuat");
            DropTable("dbo.NhaCungCap");
            DropTable("dbo.NgonNgu");
            DropTable("dbo.PhanLoai");
            DropTable("dbo.LoaiSanPham");
            DropTable("dbo.HinhAnh");
            DropTable("dbo.KhuyenMai");
            DropTable("dbo.CT_KhuyenMai");
            DropTable("dbo.SanPham");
            DropTable("dbo.PhuongThucThanhToan");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.HoaDon");
            DropTable("dbo.CT_HoaDon");
            DropTable("dbo.ChucVu");
            DropTable("dbo.NhanVien");
            DropTable("dbo.NhomNguoiDung");
            DropTable("dbo.ChucNang");
            DropTable("dbo.CapQuyen");
        }
    }
}
