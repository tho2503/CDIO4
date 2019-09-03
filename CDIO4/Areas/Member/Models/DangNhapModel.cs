using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CDIO4.Areas.Member.Models
{
    public class DangNhapModel
    {
        [Required]
        public string TenDangNhap { set; get; }
        public string MatKhau { set; get; }
        public bool NhoMatKhau { set; get; }
    }
}