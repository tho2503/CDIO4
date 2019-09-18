namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPhamDauGia")]
    public partial class SanPhamDauGia
    {
        [Key]
        public int ID_SanPham { get; set; }

        [StringLength(255)]
        public string TenSP { get; set; }

        [StringLength(255)]
        public string MoTa { get; set; }

        public DateTime? HanDauGia { get; set; }

        public int? GiaDuKien { get; set; }

        [StringLength(50)]
        public string TrangThai { get; set; }

        [StringLength(255)]
        public string DanhGia { get; set; }

        [StringLength(50)]
        public string TenDN_NguoiBan { get; set; }

        public int? ID_DanhMuc { get; set; }

        [StringLength(50)]
        public string HinhAnh { get; set; }

        public DateTime? NgayTao { get; set; }

        public int? GiaBanRa { get; set; }

        public virtual DanhMuc DanhMuc { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
