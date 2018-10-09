using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyKho.Models
{
    public class KhachHang
    {
        public int Id { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public string MaSoThue { get; set; }
        public List<CuaHang> CuaHangs { get; set; }
    }
}