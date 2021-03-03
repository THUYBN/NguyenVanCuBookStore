namespace S3Train.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addncc : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HinhAnh", "MaSP", "dbo.SanPham");
            DropIndex("dbo.HinhAnh", new[] { "MaSP" });
            CreateTable(
                "dbo.NhaCungCap",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenNCC = c.String(nullable: false, maxLength: 200),
                        DiaChi = c.String(nullable: false, maxLength: 500),
                        Email = c.String(maxLength: 200),
                        SDT = c.String(nullable: false, maxLength: 200),
                        ThongTinThem = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.SanPham", "HinhAnh", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.SanPham", "MaNCC", c => c.Guid(nullable: false));
            CreateIndex("dbo.SanPham", "MaNCC");
            AddForeignKey("dbo.SanPham", "MaNCC", "dbo.NhaCungCap", "Id", cascadeDelete: true);
            DropTable("dbo.HinhAnh");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.HinhAnh",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        MaSP = c.Guid(nullable: false),
                        TenLuuTepTin = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.SanPham", "MaNCC", "dbo.NhaCungCap");
            DropIndex("dbo.SanPham", new[] { "MaNCC" });
            DropColumn("dbo.SanPham", "MaNCC");
            DropColumn("dbo.SanPham", "HinhAnh");
            DropTable("dbo.NhaCungCap");
            CreateIndex("dbo.HinhAnh", "MaSP");
            AddForeignKey("dbo.HinhAnh", "MaSP", "dbo.SanPham", "Id", cascadeDelete: true);
        }
    }
}
