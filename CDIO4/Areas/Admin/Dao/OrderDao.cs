using Model.EF;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDIO4.Areas.Admin.Dao
{
    public class OrderDao
    {
        AuctionOnlineDbContext db = null;

        public OrderDao()
        {
            db = new AuctionOnlineDbContext();
        }

        public List<HoaDon> DsOrder()
        {
            return db.HoaDons.OrderByDescending(x => x.NgayTao).ToList();
        }

        public HoaDon ViewDetail(int id)
        {
            return db.HoaDons.Find(id);
        }

        public List<HoaDonViewModel> DsDetail(int id)
        {
            var order = from a in db.HoaDon_ChiTiet
                        join b in db.SanPhamDauGias
                        on a.ID_SanPham equals b.ID_SanPham
                        where a.ID_HoaDon == id
                        select new HoaDonViewModel()
                        {
                            ID_HoaDon = a.ID_HoaDon,
                            TenSP = b.TenSP,
                            SoLuong = a.SoLuong,
                            Gia = a.Gia
                        };
            order.OrderBy(x => x.ID_HoaDon == id);
            return order.ToList();
        }

        public int Sum(int id)
        {
            return (int)db.HoaDon_ChiTiet.Where(x=>x.ID_HoaDon == id).Sum(x => x.Gia);
        }
    }
}