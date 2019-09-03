using Model.Framework;
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
