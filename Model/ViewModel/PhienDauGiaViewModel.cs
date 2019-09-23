using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class PhienDauGiaViewModel
    {
        public int? ID_PhienDauGia { set; get; }
        public string TenSP { set; get; }
        public int? GiaHienTai { set; get; }
        public string TenNguoiDauGia { set; get; }
        public DateTime? ThoiGian { set; get; }
    }
}
