using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyKho.Models
{
    public class HangHoa
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Phải nhập dữ liệu cho trường này!")]
        [MaxLength(10)]
        [Display(Name ="Mã hàng hóa")]
        public string MaHangHoa { get; set; }

        [Required(ErrorMessage ="Phải nhập dữ liệu cho trường này!")]
        [MaxLength(255)]
        [Display(Name ="Tên hàng hóa")]
        public string TenHangHoa { get; set; }

        public DVT DVT { get; set; }

        public byte? DVT_Id { get; set; }

        public DateTime NgayTao { get; set; }

        public DateTime? NgayCapNhatCuoi { get; set; }

        public List<DonGiaHangHoa> DonGiaHangHoas { get; set; }

        public NhomHangHoa NhomHangHoa { get; set; }

        public int? NhomHangHoaId { get; set; }

        public bool _isLocked { get; set; }
    }
}