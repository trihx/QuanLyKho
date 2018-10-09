namespace QuanLyKho.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addKhachhang_NhanVien : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CuaHang",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenCuaHang = c.String(),
                        DiaChi = c.String(),
                        SDT = c.String(),
                        KhachHang_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.KhachHang", t => t.KhachHang_Id)
                .Index(t => t.KhachHang_Id);
            
            CreateTable(
                "dbo.DVT",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KhachHang",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HoTen = c.String(),
                        DiaChi = c.String(),
                        SDT = c.String(),
                        MaSoThue = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NhanVien",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HoTen = c.String(),
                        SDT = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.HangHoa", "DVT_Id", c => c.Byte());
            AddColumn("dbo.HangHoa", "DVT_Id1", c => c.Byte());
            CreateIndex("dbo.HangHoa", "DVT_Id1");
            AddForeignKey("dbo.HangHoa", "DVT_Id1", "dbo.DVT", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CuaHang", "KhachHang_Id", "dbo.KhachHang");
            DropForeignKey("dbo.HangHoa", "DVT_Id1", "dbo.DVT");
            DropIndex("dbo.HangHoa", new[] { "DVT_Id1" });
            DropIndex("dbo.CuaHang", new[] { "KhachHang_Id" });
            DropColumn("dbo.HangHoa", "DVT_Id1");
            DropColumn("dbo.HangHoa", "DVT_Id");
            DropTable("dbo.NhanVien");
            DropTable("dbo.KhachHang");
            DropTable("dbo.DVT");
            DropTable("dbo.CuaHang");
        }
    }
}
