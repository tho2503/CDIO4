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
            return db.PhienDauGias.Where(x => x.ID_SanPham == id & x.TenDN_Daugia != null).OrderByDescending(x => x.Thoigian).ToList();
        }

        public PhienDauGia ViewDetail(long id)
        {
            return db.PhienDauGias.Find(id);
        }

        public PhienDauGia BiddTop(long id)
        {
            return db.PhienDauGias.Where(x => x.ID_SanPham == id).OrderByDescending(x => x.GiaCaoNhat).FirstOrDefault();
        }

        public List<PhienDauGia> DsDangDauGiaThang(string ten)
        {
            return db.PhienDauGias.Where(x => x.TenDN_Daugia == ten).OrderByDescending(x => x.Thoigian).ToList();
        }
    }
}