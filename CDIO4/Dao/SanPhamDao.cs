using Model.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        internal object ViewDetail(object id)
        {
            throw new NotImplementedException();
        }

        public List<SanPhamDauGia> ListSpLienquan (long producId)
        {
            var product = db.SanPhamDauGias.Find(producId);
            return db.SanPhamDauGias.Where(x => x.ID_SanPham != producId && x.ID_DanhMuc == product.ID_DanhMuc && x.TrangThai == "Đang đấu giá").ToList();
        }

        public SanPhamDauGia ViewDetail(long id)
        {
            return db.SanPhamDauGias.Find(id);
        }

        public List<SanPhamDauGia> DsDangDauGia (string ten)
        {
            return db.SanPhamDauGias.Where(x => x.NguoiThang == ten && x.TrangThai == "Đang đấu giá").OrderByDescending(x => x.NgayTao).ToList();
        }

        public List<SanPhamDauGia> DsDauGiaThang(string ten)
        {
            return db.SanPhamDauGias.Where(x => x.NguoiThang == ten && x.TrangThai == "Hết hạn").OrderByDescending(x => x.NgayTao).ToList();
        }

        public List<SanPhamDauGia> DsTheoDanhMuc (int id)
        {
            return db.SanPhamDauGias.Where(x => x.ID_DanhMuc == id && x.TrangThai == "Đang đấu giá").OrderByDescending(x=>x.GiaBanRa).ToList();
        }
    }
}