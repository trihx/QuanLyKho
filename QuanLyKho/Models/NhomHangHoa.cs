using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyKho.Models
{
   
        public class NhomHangHoa
        {
            public int Id { get; set; }

            [Required(ErrorMessage = "Phải nhập dữ liệu cho trường này!")]
            [MaxLength(10)]
            [Display(Name = "Mã nhóm")]
            public string MaNhomHangHoa { get; set; }

            [MaxLength(255)]
            [Display(Name = "Tên nhóm")]
            [Required]
            public string TenNhomHangHoa { get; set; }

            public List<HangHoa> HangHoas { get; set; }

            [Display(Name ="Khóa")]
            public bool _isLocked { get; set; }

        }
    
}