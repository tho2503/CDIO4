﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CDIO4.Models
{
    public class BiddingModel
    {
        [Required]
        public int Tien { set; get; }
        public int IDSanPham { set; get; }
        public string Ten { set; get; }
        
    }
}