namespace S3Train.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delncc : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SanPham", "MaNCC", "dbo.NhaCungCap");
            DropIndex("dbo.SanPham", new[] { "MaNCC" });
           
            DropColumn("dbo.SanPham", "MaNCC");
            DropTable("dbo.NhaCungCap");
        }
        
        public override void Down()
        {
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

            AddColumn("dbo.SanPham", "MaNCC", c => c.Guid(nullable: false));
           
            CreateIndex("dbo.SanPham", "MaNCC");
            AddForeignKey("dbo.SanPham", "MaNCC", "dbo.NhaCungCap", "Id", cascadeDelete: true);
        }
    }
}
