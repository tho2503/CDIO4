using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDIO4.Dao
{
    public class SanPhamDao
    {
        AuctionOnlineDbContext  db = null;
        public SanPhamDao()
        {
            db = new AuctionOnlineDbContext();
        }

        public List<SanPhamDauGia> ListSpDauGia()
        {
            return db.SanPhamDauGias.Where(x => x.TrangThai == "Đang đấu giá").OrderBy(x => x.ID_SanPham).ToList();
        }

        public void Delete(int id)
        {
            var item = db.SanPhamDauGias.Find(id);
            db.SanPhamDauGias.Remove(item);
            db.SaveChanges();
        }
    }
}