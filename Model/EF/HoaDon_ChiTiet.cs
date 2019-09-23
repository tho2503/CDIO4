namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HoaDon_ChiTiet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_SanPham { get; set; }

        public int? ID_HoaDon { get; set; }

        public int? SoLuong { get; set; }

        public int? Gia { get; set; }

        public DateTime? NgayTao { get; set; }
    }
}
