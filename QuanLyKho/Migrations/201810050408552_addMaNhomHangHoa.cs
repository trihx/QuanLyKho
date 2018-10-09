namespace QuanLyKho.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMaNhomHangHoa : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HangHoa", "NhomHangHoa_Id", "dbo.NhomHangHoa");
            DropIndex("dbo.HangHoa", new[] { "NhomHangHoa_Id" });
            RenameColumn(table: "dbo.HangHoa", name: "NhomHangHoa_Id", newName: "NhomHangHoaId");
            AlterColumn("dbo.HangHoa", "NhomHangHoaId", c => c.Int(nullable: true));
            CreateIndex("dbo.HangHoa", "NhomHangHoaId");
            AddForeignKey("dbo.HangHoa", "NhomHangHoaId", "dbo.NhomHangHoa", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HangHoa", "NhomHangHoaId", "dbo.NhomHangHoa");
            DropIndex("dbo.HangHoa", new[] { "NhomHangHoaId" });
            AlterColumn("dbo.HangHoa", "NhomHangHoaId", c => c.Int());
            RenameColumn(table: "dbo.HangHoa", name: "NhomHangHoaId", newName: "NhomHangHoa_Id");
            CreateIndex("dbo.HangHoa", "NhomHangHoa_Id");
            AddForeignKey("dbo.HangHoa", "NhomHangHoa_Id", "dbo.NhomHangHoa", "Id");
        }
    }
}
