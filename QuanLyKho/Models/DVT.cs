using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace QuanLyKho.Models
{
    public class DVT
    {
        public byte Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}