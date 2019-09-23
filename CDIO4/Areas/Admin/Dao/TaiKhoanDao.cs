using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDIO4.Areas.Admin.Dao
{
    public class TaiKhoanDao
    {
        AuctionOnlineDbContext db = null;

        public TaiKhoanDao()
        {
            db = new AuctionOnlineDbContext();
        }

        public List<TaiKhoan> DsTaiKhoan()
        {
            return db.TaiKhoans.OrderBy(x => x.TenDangNhap).ToList();
        }

        public string Insert(TaiKhoan acc)
        {
            db.TaiKhoans.Add(acc);
            db.SaveChanges();
            return acc.TenDangNhap;
        }

        public bool Update(TaiKhoan entity)
        {
            try
            {
                var acc = db.TaiKhoans.Find(entity.TenDangNhap);
                acc.TenDangNhap = entity.TenDangNhap;
                acc.MatKhau = entity.MatKhau;
                acc.HoTen = entity.HoTen;
                acc.Diachi = entity.Diachi;
                acc.Email = entity.Email;
                acc.SDT = entity.SDT;
                acc.TrangThai = entity.TrangThai;
                db.SaveChanges();              
                return true;
            } catch(Exception)
            {
                return false;
            }
        }

        public TaiKhoan GetByUserName(string tendn)
        {
            return db.TaiKhoans.Find(tendn);
        }

        public bool Delete (string tendn)
        {
            try
            {
                var acc = db.TaiKhoans.Find(tendn);
                db.TaiKhoans.Remove(acc);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}