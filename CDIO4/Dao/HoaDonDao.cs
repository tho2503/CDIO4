using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.EF;

namespace CDIO4.Dao
{
    public class HoaDonDao
    {
        AuctionOnlineDbContext db = null;

        public HoaDonDao()
        {
            db = new AuctionOnlineDbContext();
        }

        public int Insert(HoaDon hd)
        {
            db.HoaDons.Add(hd);
            db.SaveChanges();

            return hd.ID_HoaDon;
        }
    }
}