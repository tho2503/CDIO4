namespace Model.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [Key]
        public int ID_HoaDon { get; set; }

        public int? ID_SanPham { get; set; }

        public int? ID_PhiendauGia { get; set; }

        [StringLength(50)]
        public string TenDN_HoaDon { get; set; }

        public virtual PhienDauGia PhienDauGia { get; set; }

        public virtual SanPhamDauGia SanPhamDauGia { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
