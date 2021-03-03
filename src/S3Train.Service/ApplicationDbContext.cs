using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace S3Train.Domain
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Ward> Wards { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<NgonNgu> NgonNgus { get; set; }
        public DbSet<LoaiSanPham> LoaiSanPhams { get; set; }
        public DbSet<PhanLoai> PhanLoais { get; set; }
        public DbSet<ManHinhTrangChu> ManHinhTrangChus { get; set; }
        public DbSet<ChucVu> ChucVus { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<ChucNang> ChucNangs { get; set; }
        public DbSet<CapQuyen> CapQuyens { get; set; }
        public DbSet<NhomNguoiDung> NhomNguoiDungs { get; set; }
        public DbSet<NhaSanXuat> NhaSanXuats { get; set; }
        public DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public DbSet<KhuyenMai> KhuyenMais { get; set; }
        public DbSet<CT_KhuyenMai> CT_KhuyenMais { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<PhuongThucThanhToan> PhuongThucThanhToans { get; set; }
        public DbSet<CT_HoaDon> CT_HoaDons { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>().ToTable("Country");
            modelBuilder.Entity<Country>().HasMany(c => c.Provinces).WithRequired(p => p.Country);

            modelBuilder.Entity<Province>().ToTable("Province");
            modelBuilder.Entity<Province>().HasMany(c => c.Districts).WithRequired(p => p.Province);

            modelBuilder.Entity<District>().ToTable("District");
            modelBuilder.Entity<District>().HasMany(c => c.Wards).WithRequired(p => p.District);

            modelBuilder.Entity<Ward>().ToTable("Ward");

            modelBuilder.Entity<NhaSanXuat>().ToTable("NhaSanXuat");
            modelBuilder.Entity<NhaSanXuat>().HasMany(c => c.SanPhams).WithRequired(p => p.NhaSanXuat);
            modelBuilder.Entity<NhaSanXuat>().Property(x => x.TenNSX).HasMaxLength(200).IsRequired();
            modelBuilder.Entity<NhaSanXuat>().Property(x => x.ThongTinThem).HasMaxLength(500);

            modelBuilder.Entity<NhaCungCap>().ToTable("NhaCungCap");
            modelBuilder.Entity<NhaCungCap>().HasMany(c => c.SanPhams).WithRequired(p => p.NhaCungCap);
            modelBuilder.Entity<NhaCungCap>().Property(x => x.TenNCC).HasMaxLength(200).IsRequired();
            modelBuilder.Entity<NhaCungCap>().Property(x => x.DiaChi).HasMaxLength(500).IsRequired();
            modelBuilder.Entity<NhaCungCap>().Property(x => x.Email).HasMaxLength(200);
            modelBuilder.Entity<NhaCungCap>().Property(x => x.SDT).HasMaxLength(200).IsRequired();
            modelBuilder.Entity<NhaCungCap>().Property(x => x.ThongTinThem).HasMaxLength(200);

            modelBuilder.Entity<NgonNgu>().ToTable("NgonNgu");
            modelBuilder.Entity<NgonNgu>().HasMany(c => c.SanPhams).WithRequired(p => p.NgonNgu);
            modelBuilder.Entity<NgonNgu>().Property(x => x.TenNN).HasMaxLength(50).IsRequired();

            modelBuilder.Entity<PhanLoai>().ToTable("PhanLoai");
            modelBuilder.Entity<PhanLoai>().HasMany(c => c.LoaiSanPhams).WithRequired(p => p.PhanLoai);
            modelBuilder.Entity<PhanLoai>().Property(x => x.TenPhanLoai).HasMaxLength(50).IsRequired();

            modelBuilder.Entity<LoaiSanPham>().ToTable("LoaiSanPham");
            modelBuilder.Entity<LoaiSanPham>().HasMany(c => c.SanPhams).WithRequired(p => p.LoaiSanPham);
            modelBuilder.Entity<LoaiSanPham>().Property(x => x.TenLoai).HasMaxLength(50).IsRequired();

            modelBuilder.Entity<KhuyenMai>().ToTable("KhuyenMai");
            modelBuilder.Entity<KhuyenMai>().HasMany(c => c.CT_KhuyenMais).WithRequired(p => p.KhuyenMai);
            modelBuilder.Entity<KhuyenMai>().Property(x => x.TenKM).HasMaxLength(300).IsRequired();
            modelBuilder.Entity<KhuyenMai>().Property(x => x.ThoiGianBD).IsRequired();
            modelBuilder.Entity<KhuyenMai>().Property(x => x.ThoiGianKT).IsRequired();

            modelBuilder.Entity<CT_KhuyenMai>().ToTable("CT_KhuyenMai");
            modelBuilder.Entity<CT_KhuyenMai>().Property(x => x.PhanTramKM).IsRequired();
            modelBuilder.Entity<CT_KhuyenMai>().Property(x => x.SoLuong).IsRequired();

            modelBuilder.Entity<HoaDon>().ToTable("HoaDon");
            modelBuilder.Entity<HoaDon>().HasMany(c => c.CT_HoaDons).WithRequired(p => p.HoaDon);
            modelBuilder.Entity<HoaDon>().Property(x => x.NgayLap);
            modelBuilder.Entity<HoaDon>().Property(x => x.TrangThai).HasMaxLength(100);
            modelBuilder.Entity<HoaDon>().Property(x => x.GhiChu).HasMaxLength(300);
            modelBuilder.Entity<HoaDon>().Property(x => x.TongTien).IsRequired();
            modelBuilder.Entity<HoaDon>().Property(x => x.NgayCapNhat);

            modelBuilder.Entity<CT_HoaDon>().ToTable("CT_HoaDon");
            modelBuilder.Entity<CT_HoaDon>().Property(x => x.SoLuong).IsRequired();
            modelBuilder.Entity<CT_HoaDon>().Property(x => x.ThanhTien).IsRequired();
            modelBuilder.Entity<CT_HoaDon>().Property(x => x.Gia).IsRequired();

            modelBuilder.Entity<PhuongThucThanhToan>().ToTable("PhuongThucThanhToan");
            modelBuilder.Entity<PhuongThucThanhToan>().HasMany(c => c.HoaDons).WithRequired(p => p.PhuongThucThanhToan);
            modelBuilder.Entity<PhuongThucThanhToan>().Property(x => x.TenPhuongThuc).HasMaxLength(100).IsRequired();

            modelBuilder.Entity<SanPham>().ToTable("SanPham");
            modelBuilder.Entity<SanPham>().HasMany(c => c.CT_KhuyenMais).WithRequired(p => p.SanPham);
            modelBuilder.Entity<SanPham>().HasMany(c => c.CT_HoaDons).WithRequired(p => p.SanPham);
            modelBuilder.Entity<SanPham>().Property(x => x.TenSP).HasMaxLength(300).IsRequired();
            modelBuilder.Entity<SanPham>().Property(x => x.GhiChu).HasMaxLength(500).IsRequired();
            modelBuilder.Entity<SanPham>().Property(x => x.Gia).IsRequired();
            modelBuilder.Entity<SanPham>().Property(x => x.KichThuoc).HasMaxLength(100);
            modelBuilder.Entity<SanPham>().Property(x => x.SoTrang);
            modelBuilder.Entity<SanPham>().Property(x => x.SoLuong).IsRequired();
            modelBuilder.Entity<SanPham>().Property(x => x.TacGia).HasMaxLength(100);
            modelBuilder.Entity<SanPham>().Property(x => x.HinhAnh).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<SanPham>().Property(x => x.TrongLuong).IsRequired();
            modelBuilder.Entity<SanPham>().Property(x => x.ChatLuong).HasMaxLength(100);
            modelBuilder.Entity<SanPham>().Property(x => x.MauSac).HasMaxLength(100);
            modelBuilder.Entity<SanPham>().Property(x => x.NgayTao).IsRequired();
            modelBuilder.Entity<SanPham>().Property(x => x.NgayCapNhat);
            modelBuilder.Entity<SanPham>().Property(x => x.TrangThai).IsRequired();
            modelBuilder.Entity<SanPham>().Property(x => x.LuotXem).IsRequired();

            modelBuilder.Entity<ManHinhTrangChu>().ToTable("ManHinhTrangChu");
            modelBuilder.Entity<ManHinhTrangChu>().Property(x => x.ImagePath).HasMaxLength(200).IsRequired();
            modelBuilder.Entity<ManHinhTrangChu>().Property(x => x.EventUrl).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<ManHinhTrangChu>().Property(x => x.Title).HasMaxLength(100).IsOptional();
            modelBuilder.Entity<ManHinhTrangChu>().Property(x => x.Description).HasMaxLength(500).IsOptional();

            modelBuilder.Entity<NhanVien>().ToTable("NhanVien");
            modelBuilder.Entity<NhanVien>().Property(x => x.TenNV).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<NhanVien>().Property(x => x.HinhAnh).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<NhanVien>().Property(x => x.DiaChi).HasMaxLength(200).IsRequired();
            modelBuilder.Entity<NhanVien>().Property(x => x.GioiTinh).HasMaxLength(10).IsRequired();
            modelBuilder.Entity<NhanVien>().Property(x => x.NgaySinh).IsRequired();
            modelBuilder.Entity<NhanVien>().Property(x => x.SDT).HasMaxLength(10).IsRequired();
            modelBuilder.Entity<NhanVien>().Property(x => x.Email).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<NhanVien>().Property(x => x.Password).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<NhanVien>().Property(x => x.TenDN).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<NhanVien>().Property(x => x.CMND).HasMaxLength(9).IsRequired();
            modelBuilder.Entity<NhanVien>().Property(x => x.TrangThai).IsRequired();

            modelBuilder.Entity<ChucVu>().ToTable("ChucVu");
            modelBuilder.Entity<ChucVu>().HasMany(c => c.NhanViens).WithRequired(p => p.ChucVu);
            modelBuilder.Entity<ChucVu>().Property(x => x.TenCV).HasMaxLength(100).IsRequired();

            modelBuilder.Entity<ChucNang>().ToTable("ChucNang");
            modelBuilder.Entity<ChucNang>().HasMany(c => c.CapQuyens).WithRequired(p => p.ChucNang);
            modelBuilder.Entity<ChucNang>().Property(x => x.TenCN).HasMaxLength(100).IsRequired();

            modelBuilder.Entity<CapQuyen>().ToTable("CapQuyen");

            modelBuilder.Entity<NhomNguoiDung>().ToTable("NhomNguoiDung");
            modelBuilder.Entity<NhomNguoiDung>().HasMany(c => c.CapQuyens).WithRequired(p => p.NhomNguoiDung);
            modelBuilder.Entity<NhomNguoiDung>().HasMany(c => c.NhanViens).WithRequired(p => p.NhomNguoiDung);
            modelBuilder.Entity<NhomNguoiDung>().Property(x => x.TenNhom).HasMaxLength(100);
        }

        //public System.Data.Entity.DbSet<S3Train.Domain.ApplicationUser> ApplicationUsers { get; set; }
    }
}