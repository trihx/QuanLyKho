using QuanLyKho.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyKho.ModelDTO
{
    public class HangHoaDTO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string MaHangHoa { get; set; }
        
        [StringLength(255)]
        [Required]
        public string TenHangHoa { get; set; }

        public byte DVT_Id { get; set; }

        public DateTime NgayTao { get; set; }

        public DateTime? NgayCapNhatCuoi { get; set; }

        public NhomHangHoaDTO NhomHangHoa { get; set; }

        public int? NhomHangHoaId { get; set; }

        public bool _isLocked { get; set; }
    }
}