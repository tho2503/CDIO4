using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CDIO4.Models
{
    public class UpdateModel
    {
        [Required]
        public int IDSanPham { set; get; }
    }
}