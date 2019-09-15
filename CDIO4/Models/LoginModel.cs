using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CDIO4.Models
{
    public class LoginModel
    {
        public string TenDangNhap { set; get; }
        public string MatKhau { set; get; }
        public bool NhoMatKhau { set; get; }
    }
}