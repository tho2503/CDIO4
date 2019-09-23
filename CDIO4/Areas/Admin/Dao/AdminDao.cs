using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDIO4.Areas.Admin.Dao
{
    public class AdminDao
    {
        AuctionOnlineDbContext db = null;

        public AdminDao()
        {
            db = new AuctionOnlineDbContext();
        }

        public List<PhienDauGia> DsBidd()
        {
            return db.PhienDauGias.Where(x => x.TenDN_Daugia != null).OrderBy(x => x.ID_PhienDauGia).ToList();
        }
        public List<SanPhamDauGia> DsSP()
        {
            return db.SanPhamDauGias.OrderBy(x => x.ID_SanPham).ToList();
        }
        public List<HoaDon> DsHD()
        {
            return db.HoaDons.OrderBy(x => x.ID_HoaDon).ToList();
        }
        public List<TaiKhoan> DsTaiKhoan()
        {
            return db.TaiKhoans.Where(x => x.TrangThai == true).OrderBy(x => x.TenDangNhap).ToList();
        }

        //Thống kê Bidd tháng
        public List<PhienDauGia> DsBiddT1()
        {            
            return db.PhienDauGias.ToList().Where(x => Convert.ToDateTime(x.Thoigian).Month == 1).ToList();
        }
        public List<PhienDauGia> DsBiddT2()
        {
            return db.PhienDauGias.ToList().Where(x => Convert.ToDateTime(x.Thoigian).Month == 2).ToList();
        }
        public List<PhienDauGia> DsBiddT3()
        {
            return db.PhienDauGias.ToList().Where(x => Convert.ToDateTime(x.Thoigian).Month == 3).ToList();
        }
        public List<PhienDauGia> DsBiddT4()
        {
            return db.PhienDauGias.ToList().Where(x => Convert.ToDateTime(x.Thoigian).Month == 4).ToList();
        }
        public List<PhienDauGia> DsBiddT5()
        {
            return db.PhienDauGias.ToList().Where(x => Convert.ToDateTime(x.Thoigian).Month == 5).ToList();
        }
        public List<PhienDauGia> DsBiddT6()
        {
            return db.PhienDauGias.ToList().Where(x => Convert.ToDateTime(x.Thoigian).Month == 6).ToList();
        }
        public List<PhienDauGia> DsBiddT7()
        {
            return db.PhienDauGias.ToList().Where(x => Convert.ToDateTime(x.Thoigian).Month == 7).ToList();
        }
        public List<PhienDauGia> DsBiddT8()
        {
            return db.PhienDauGias.ToList().Where(x => Convert.ToDateTime(x.Thoigian).Month == 8).ToList();
        }
        public List<PhienDauGia> DsBiddT9()
        {
            return db.PhienDauGias.ToList().Where(x => Convert.ToDateTime(x.Thoigian).Month == 9).ToList();
        }
        public List<PhienDauGia> DsBiddT10()
        {
            return db.PhienDauGias.ToList().Where(x => Convert.ToDateTime(x.Thoigian).Month == 10).ToList();
        }
        public List<PhienDauGia> DsBiddT11()
        {
            return db.PhienDauGias.ToList().Where(x => Convert.ToDateTime(x.Thoigian).Month == 11).ToList();
        }
        public List<PhienDauGia> DsBiddT12()
        {
            return db.PhienDauGias.ToList().Where(x => Convert.ToDateTime(x.Thoigian).Month == 12).ToList();
        }
   
        //Doanh thu
        public int DoanhThuT1()
        {
            return (int)db.HoaDon_ChiTiet.ToList().Where(x => Convert.ToDateTime(x.NgayTao).Month == 1).Sum(x => x.Gia);
        }
        public int DoanhThuT2()
        {
            return (int)db.HoaDon_ChiTiet.ToList().Where(x => Convert.ToDateTime(x.NgayTao).Month == 2).Sum(x => x.Gia);
        }
        public int DoanhThuT3()
        {
            return (int)db.HoaDon_ChiTiet.ToList().Where(x => Convert.ToDateTime(x.NgayTao).Month == 3).Sum(x => x.Gia);
        }
        public int DoanhThuT4()
        {
            return (int)db.HoaDon_ChiTiet.ToList().Where(x => Convert.ToDateTime(x.NgayTao).Month == 4).Sum(x => x.Gia);
        }
        public int DoanhThuT5()
        {
            return (int)db.HoaDon_ChiTiet.ToList().Where(x => Convert.ToDateTime(x.NgayTao).Month == 5).Sum(x => x.Gia);
        }
        public int DoanhThuT6()
        {
            return (int)db.HoaDon_ChiTiet.ToList().Where(x => Convert.ToDateTime(x.NgayTao).Month == 6).Sum(x => x.Gia);
        }
        public int DoanhThuT7()
        {
            return (int)db.HoaDon_ChiTiet.ToList().Where(x => Convert.ToDateTime(x.NgayTao).Month == 7).Sum(x => x.Gia);
        }
        public int DoanhThuT8()
        {
            return (int)db.HoaDon_ChiTiet.ToList().Where(x => Convert.ToDateTime(x.NgayTao).Month == 8).Sum(x => x.Gia);
        }
        public int DoanhThuT9()
        {
            return (int)db.HoaDon_ChiTiet.ToList().Where(x => Convert.ToDateTime(x.NgayTao).Month == 9).Sum(x => x.Gia);
        }
        public int DoanhThuT10()
        {
            return (int)db.HoaDon_ChiTiet.ToList().Where(x => Convert.ToDateTime(x.NgayTao).Month == 10).Sum(x => x.Gia);
        }
        public int DoanhThuT11()
        {
            return (int)db.HoaDon_ChiTiet.ToList().Where(x => Convert.ToDateTime(x.NgayTao).Month == 11).Sum(x => x.Gia);
        }
        public int DoanhThuT12()
        {
            return (int)db.HoaDon_ChiTiet.ToList().Where(x => Convert.ToDateTime(x.NgayTao).Month == 12).Sum(x => x.Gia);
        }

        //Thống kê sản phẩm theo doanh mục
        public List<SanPhamDauGia> SpMuc1()
        {
            return db.SanPhamDauGias.Where(x => x.ID_DanhMuc == 1).ToList();
        }
        public List<SanPhamDauGia> SpMuc2()
        {
            return db.SanPhamDauGias.Where(x => x.ID_DanhMuc == 2).ToList();
        }
        public List<SanPhamDauGia> SpMuc3()
        {
            return db.SanPhamDauGias.Where(x => x.ID_DanhMuc == 3).ToList();
        }
        public List<SanPhamDauGia> SpMuc4()
        {
            return db.SanPhamDauGias.Where(x => x.ID_DanhMuc == 4).ToList();
        }
        public List<SanPhamDauGia> SpMuc5()
        {
            return db.SanPhamDauGias.Where(x => x.ID_DanhMuc == 5).ToList();
        }
        public List<SanPhamDauGia> SpMuc6()
        {
            return db.SanPhamDauGias.Where(x => x.ID_DanhMuc == 6).ToList();
        }
        public List<SanPhamDauGia> SpMuc7()
        {
            return db.SanPhamDauGias.Where(x => x.ID_DanhMuc == 7).ToList();
        }
        public List<SanPhamDauGia> SpMuc8()
        {
            return db.SanPhamDauGias.Where(x => x.ID_DanhMuc == 8).ToList();
        }
        public List<SanPhamDauGia> SpMuc9()
        {
            return db.SanPhamDauGias.Where(x => x.ID_DanhMuc == 9).ToList();
        }
        public List<SanPhamDauGia> SpMuc10()
        {
            return db.SanPhamDauGias.Where(x => x.ID_DanhMuc == 10).ToList();
        }
    }
}