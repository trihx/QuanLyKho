namespace QuanLyKho.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateofHangHoa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DonGiaHangHoa",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DonGiaNhap = c.Double(nullable: false),
                        NgayBatDau = c.DateTime(nullable: false),
                        NgayKetThuc = c.DateTime(),
                        HangHoa_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HangHoa", t => t.HangHoa_Id)
                .Index(t => t.HangHoa_Id);
            
            CreateTable(
                "dbo.HangHoa",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaHangHoa = c.String(nullable: false, maxLength: 10),
                        TenHangHoa = c.String(nullable: false, maxLength: 255),
                        NgayTao = c.DateTime(nullable: false),
                        NgayCapNhatCuoi = c.DateTime(),
                        _isLocked = c.Boolean(nullable: false),
                        NhomHangHoa_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NhomHangHoa", t => t.NhomHangHoa_Id)
                .Index(t => t.NhomHangHoa_Id);
            
            CreateTable(
                "dbo.NhomHangHoa",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaNhomHangHoa = c.String(nullable: false, maxLength: 10),
                        TenNhomHangHoa = c.String(nullable: false, maxLength: 255),
                        _isLocked = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HangHoa", "NhomHangHoa_Id", "dbo.NhomHangHoa");
            DropForeignKey("dbo.DonGiaHangHoa", "HangHoa_Id", "dbo.HangHoa");
            DropIndex("dbo.HangHoa", new[] { "NhomHangHoa_Id" });
            DropIndex("dbo.DonGiaHangHoa", new[] { "HangHoa_Id" });
            DropTable("dbo.NhomHangHoa");
            DropTable("dbo.HangHoa");
            DropTable("dbo.DonGiaHangHoa");
        }
    }
}
