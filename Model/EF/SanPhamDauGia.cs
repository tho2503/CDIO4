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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPhamDauGia()
        {
            GioHangs = new HashSet<GioHang>();
            HoaDons = new HashSet<HoaDon>();
        }

        [Key]
        public int ID_SanPham { get; set; }

        [StringLength(255)]
        public string TenSP { get; set; }

        [StringLength(255)]
        public string MoTa { get; set; }

        public DateTime? HanDauGia { get; set; }

        [Column(TypeName = "money")]
        public decimal? GiaDuKien { get; set; }

        [StringLength(50)]
        public string TrangThai { get; set; }

        [Required]
        [StringLength(255)]
        public string DanhGia { get; set; }

        [StringLength(50)]
        public string TenDN_NguoiBan { get; set; }

        public int? ID_DanhMuc { get; set; }

        public int? ID_PhienDauGia { get; set; }

        [StringLength(50)]
        public string HinhAnh { get; set; }

        public DateTime? NgayTao { get; set; }

        public virtual DanhMuc DanhMuc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GioHang> GioHangs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }

        public virtual PhienDauGia PhienDauGia { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
