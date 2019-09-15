using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDIO4.Dao
{
    public class BiddingDao
    {
        AuctionOnlineDbContext db = null;
        public BiddingDao()
        {
            db = new AuctionOnlineDbContext();
        }

        public List<PhienDauGia> ListBidding(long id)
        {
            return db.PhienDauGias.Where(x => x.ID_SanPham == id).ToList();
        }

        public PhienDauGia ViewDetail(long id)
        {
            return db.PhienDauGias.Find(id);
        }
    }
}