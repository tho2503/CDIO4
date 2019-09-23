using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDIO4.Areas.Admin.Dao
{
    public class CategoryDao
    {
        AuctionOnlineDbContext db = null;

        public CategoryDao()
        {
            db = new AuctionOnlineDbContext();
        }

        public List<DanhMuc> DsDanhMuc()
        {
            return db.DanhMucs.OrderBy(x => x.ID).ToList();
        }

        public int Insert(DanhMuc cate)
        {
            db.DanhMucs.Add(cate);
            db.SaveChanges();
            return cate.ID;
        }

        public bool Update(DanhMuc entity)
        {
            try
            {
                var cate = db.DanhMucs.Find(entity.ID);
                cate.TenDanhMuc = entity.TenDanhMuc;      
                
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public DanhMuc GetByID(int id)
        {
            return db.DanhMucs.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var cate = db.DanhMucs.Find(id);
                db.DanhMucs.Remove(cate);
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