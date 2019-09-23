using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDIO4.Areas.Admin.Dao
{
    public class ProductDao
    {
        AuctionOnlineDbContext db = null;

        public ProductDao()
        {
            db = new AuctionOnlineDbContext();
        }
        
        public int AddItem (string tensp, string mota, DateTime handaugia, int giadukien, int danhmuc, string hinhanh)
        {
            SanPhamDauGia item = new SanPhamDauGia();
            item.TenSP = tensp;
            item.MoTa = mota;
            item.HanDauGia = handaugia;
            item.GiaDuKien = giadukien;
            item.ID_DanhMuc = danhmuc;
            item.HinhAnh = hinhanh;

            db.SanPhamDauGias.Add(item);
            db.SaveChanges();
            return item.ID_SanPham;
        }

        public bool Update(int id, string tensp, string mota, DateTime handaugia, int giadukien, int danhmuc, string hinhanh)
        {
            try
            {
                var item = db.SanPhamDauGias.Find(id);
                item.TenSP = tensp;
                item.MoTa = mota;
                item.HanDauGia = handaugia;
                item.GiaDuKien = giadukien;
                item.ID_DanhMuc = danhmuc;
                item.HinhAnh = hinhanh;
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var item = db.SanPhamDauGias.Find(id);
                db.SanPhamDauGias.Remove(item);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<SanPhamDauGia> ListProduct()
        {
            return db.SanPhamDauGias.OrderByDescending(x => x.NgayTao).ToList();
        }

        public SanPhamDauGia GetByID(int id)
        {
            return db.SanPhamDauGias.Find(id);
        }
    }
}