using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyKho.Models
{
    public class DonGiaHangHoa
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Phải nhập dữ liệu cho trường này!")]
        [Display(Name = "Đơn giá nhập")]
        public double DonGiaNhap { get; set; }

        [Display(Name = "Ngày áp dụng")]
        public DateTime NgayBatDau { get; set; }

        [Display(Name = "Ngày kết thúc")]
        public DateTime? NgayKetThuc { get; set; }
    }
}