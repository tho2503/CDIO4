using Model.EF;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TaiKhoanModel
    {
        private AuctionOnlineDbContext context = null;

        public TaiKhoanModel()
        {
            context = new AuctionOnlineDbContext();
        }

        public string Insert(TaiKhoan entity)
        {
            context.TaiKhoans.Add(entity);
            context.SaveChanges();
            return entity.TenDangNhap;
        }

        public TaiKhoan GetByName(string tenDangNhap)
        {
            return context.TaiKhoans.SingleOrDefault(x => x.TenDangNhap == tenDangNhap);
        }

        public bool Login(string userName, string passWord)
        {
            object[] sqlParams =
            {
                new SqlParameter("@TenDangNhap", userName),
                new SqlParameter("@MatKhau", passWord)
            };
            var result = context.Database.SqlQuery<bool>("Account_Login @TenDangNhap,@MatKhau", sqlParams).SingleOrDefault();

            return result;
        }
    }
}
