namespace Model.EF
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

        public DateTime? NgayTao { get; set; }

        [StringLength(50)]
        public string TenDN { get; set; }

        [StringLength(50)]
        public string Ten_Ship { get; set; }

        [StringLength(50)]
        public string SDT { get; set; }

        [StringLength(255)]
        public string DiaChi { get; set; }

        [StringLength(50)]
        public string Email { get; set; }
    }
}
