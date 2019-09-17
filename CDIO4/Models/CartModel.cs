using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDIO4.Models
{
    [Serializable]
    public class CartModel
    {       
        public SanPhamDauGia Product { set; get; }
        public int SoLuong { set; get; }
    }
}