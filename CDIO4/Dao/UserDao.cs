using Common;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDIO4.Dao
{
    public class UserDao
    {
        AuctionOnlineDbContext db = null;

        public UserDao()
        {
            db = new AuctionOnlineDbContext();
        }

        
        public bool CheckTenDn(string tendn)
        {
            return db.TaiKhoans.Count(x => x.TenDangNhap == tendn) > 0;
        }
        public bool CheckEmail(string email)
        {
            return db.TaiKhoans.Count(x => x.Email == email) > 0;
        }

        public int Login(string userName, string passWord, bool isLoginAdmin = false)
        {
            var result = db.TaiKhoans.SingleOrDefault(x => x.TenDangNhap == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (isLoginAdmin == true)
                {
                    if (result.Quyen == CommonContant.ADMIN_GROUP)
                    {
                        if (result.TrangThai == false)
                        {
                            return -1;
                        }
                        else
                        {
                            if (result.MatKhau == passWord)
                                return 2;
                            else
                                return -2;
                        }
                    }
                    else
                    {
                        return 1;
                    }
                }
                else
                {
                    if (result.MatKhau == passWord)
                        return 1;
                    else
                        return -2;
                }
            }
        }
        public TaiKhoan GetbyUserName (string tendn)
        {
            return db.TaiKhoans.SingleOrDefault(x => x.TenDangNhap == tendn);
        }

        public bool Update(string tendn, string matkhau, string hoten, string diachi, string email, int sdt)
        {
            try
            {
                var acc = db.TaiKhoans.Find(tendn);
                acc.MatKhau = matkhau;
                acc.HoTen = hoten;
                acc.Diachi = diachi;
                acc.Email = email;
                acc.SDT = sdt;

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