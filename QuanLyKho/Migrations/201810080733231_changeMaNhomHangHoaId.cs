namespace QuanLyKho.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeMaNhomHangHoaId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HangHoa", "NhomHangHoaId", "dbo.NhomHangHoa");
            DropIndex("dbo.HangHoa", new[] { "NhomHangHoaId" });
            AlterColumn("dbo.HangHoa", "NhomHangHoaId", c => c.Int());
            CreateIndex("dbo.HangHoa", "NhomHangHoaId");
            AddForeignKey("dbo.HangHoa", "NhomHangHoaId", "dbo.NhomHangHoa", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HangHoa", "NhomHangHoaId", "dbo.NhomHangHoa");
            DropIndex("dbo.HangHoa", new[] { "NhomHangHoaId" });
            AlterColumn("dbo.HangHoa", "NhomHangHoaId", c => c.Int(nullable: false));
            CreateIndex("dbo.HangHoa", "NhomHangHoaId");
            AddForeignKey("dbo.HangHoa", "NhomHangHoaId", "dbo.NhomHangHoa", "Id", cascadeDelete: true);
        }
    }
}
