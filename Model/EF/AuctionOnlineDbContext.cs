namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AuctionOnlineDbContext : DbContext
    {
        public AuctionOnlineDbContext()
            : base("name=AutionOnlineDbContext4")
        {
        }

        public virtual DbSet<DanhMuc> DanhMucs { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<HoaDon_ChiTiet> HoaDon_ChiTiet { get; set; }
        public virtual DbSet<PhienDauGia> PhienDauGias { get; set; }
        public virtual DbSet<SanPhamDauGia> SanPhamDauGias { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Table> Tables { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HoaDon>()
                .Property(e => e.TenDN)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<PhienDauGia>()
                .Property(e => e.TenDN_Daugia)
                .IsUnicode(false);

            modelBuilder.Entity<SanPhamDauGia>()
                .Property(e => e.TenDN_NguoiBan)
                .IsUnicode(false);

            modelBuilder.Entity<SanPhamDauGia>()
                .Property(e => e.HinhAnh)
                .IsUnicode(false);

            modelBuilder.Entity<Table>()
                .Property(e => e.Gia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.TenDangNhap)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .HasMany(e => e.PhienDauGias)
                .WithOptional(e => e.TaiKhoan)
                .HasForeignKey(e => e.TenDN_Daugia);

            modelBuilder.Entity<TaiKhoan>()
                .HasMany(e => e.SanPhamDauGias)
                .WithOptional(e => e.TaiKhoan)
                .HasForeignKey(e => e.TenDN_NguoiBan);
        }
    }
}
