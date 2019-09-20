using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDIO4.Dao
{
    public class DanhMucSanPhamDao
    {
        AuctionOnlineDbContext db = null;
        public DanhMucSanPhamDao()
        {
            db = new AuctionOnlineDbContext();
        }

        public List<DanhMuc> ListSpDauGia()
        {
            return db.DanhMucs.OrderBy(x => x.TenDanhMuc).ToList();
        }

        public DanhMuc ViewDetail(string tendanhmuc)
        {
            return db.DanhMucs.Find(tendanhmuc);
        }

    }
}