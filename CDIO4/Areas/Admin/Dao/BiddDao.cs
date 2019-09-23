using Model.EF;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDIO4.Areas.Admin.Dao
{
    public class BiddDao
    {
        AuctionOnlineDbContext db = null;

        public BiddDao()
        {
            db = new AuctionOnlineDbContext();
        }

        public List<PhienDauGiaViewModel> DsPhienDauGia()
        {
            var bidd = from a in db.PhienDauGias
                        join b in db.SanPhamDauGias
                        on a.ID_SanPham equals b.ID_SanPham
                       where a.TenDN_Daugia != null
                        select new PhienDauGiaViewModel()
                        {
                            ID_PhienDauGia = a.ID_PhienDauGia,
                            TenSP = b.TenSP,
                            GiaHienTai = a.GiaCaoNhat,
                            TenNguoiDauGia = a.TenDN_Daugia,
                            ThoiGian = a.Thoigian
                        };
            bidd.OrderByDescending(x => x.ThoiGian);
            return bidd.ToList();
        }

        public bool Delete(int id)
        {
            try
            {
                var bidd = db.PhienDauGias.Find(id);
                db.PhienDauGias.Remove(bidd);
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