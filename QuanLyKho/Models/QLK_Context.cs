using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace QuanLyKho.Models
{
    public class QLK_Context : DbContext
    {
        public QLK_Context() : base("DefaultConnection")
        {

        }
        // add DbSet
        public DbSet<NhomHangHoa> NhomHangHoa { get; set; }
        public DbSet<HangHoa> HangHoa { get; set; }
        public DbSet<DonGiaHangHoa> DonGiaHangHoa { get; set; }
        public DbSet<CuaHang> CuaHang { get; set; }
        public DbSet<NhanVien> NhanVien { get; set; }
        public DbSet<KhachHang> KhachHang { get; set; }
        public DbSet<DVT> DVT { get; set; }


        public static QLK_Context Create()
        {
            return new QLK_Context();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

    }
}