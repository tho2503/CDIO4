namespace Model.EF
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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_PhienDauGia { get; set; }

        public int? GiaCaoNhat { get; set; }

        public int? ID_SanPham { get; set; }

        [StringLength(50)]
        public string TenDN_Daugia { get; set; }

        public DateTime? Thoigian { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SanPhamDauGia> SanPhamDauGias { get; set; }
    }
}
