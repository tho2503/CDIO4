namespace Model.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhienDauGia")]
    public partial class PhienDauGia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhienDauGia()
        {
            HoaDons = new HashSet<HoaDon>();
            SanPhamDauGias = new HashSet<SanPhamDauGia>();
        }

        [Key]
        public int ID_PhienDauGia { get; set; }

        [Column(TypeName = "money")]
        public decimal? GiaKhoiDiem { get; set; }

        [Column(TypeName = "money")]
        public decimal? GiaCaoNhat { get; set; }

        public int? ID_SanPham { get; set; }

        [StringLength(50)]
        public string TenDN_Daugia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SanPhamDauGia> SanPhamDauGias { get; set; }
    }
}
