namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GioHang")]
    public partial class GioHang
    {
        [Key]
        public int ID_GioHang { get; set; }

        [StringLength(50)]
        public string TenDN_GioHang { get; set; }

        public int? ID_SanPham { get; set; }

        public virtual SanPhamDauGia SanPhamDauGia { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
