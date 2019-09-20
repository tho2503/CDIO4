using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDIO4.Models
{
    public class HoaDonChiTietDao
    {
        AuctionOnlineDbContext db = null;

        public HoaDonChiTietDao()
        {
            db = new AuctionOnlineDbContext();
        }

        public bool Insert(HoaDon_ChiTiet hd)
        {
            try
            {
                db.HoaDon_ChiTiet.Add(hd);
                db.SaveChanges();

                return true;
            } catch
            {
                return false;
            }
        }
    }
}