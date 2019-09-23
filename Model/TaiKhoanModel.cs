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

        public bool Login(string userName, string passWord)
        {
            object[] sqlParams =
            {
                new SqlParameter("@TenDangNhap", userName),
                new SqlParameter("@MatKhau", passWord)
            };
            if (userName != null && passWord != null)
            {
                var result = context.Database.SqlQuery<bool>("Account_Login @TenDangNhap,@MatKhau", sqlParams).SingleOrDefault();
                return result;
            }
            
            return false;
        }

        public int Registry(string TenDn, string MatKhau, string HoTen, string DiaChi, string Email, int Sdt)
        {
            object[] sqlParams =
            {
                new SqlParameter("@TenDn", TenDn),
                new SqlParameter("@MatKhau", MatKhau),
                new SqlParameter("@HoTen", HoTen),
                new SqlParameter("@DiaChi", DiaChi),
                new SqlParameter("@Email", Email),
                new SqlParameter("@Sdt", Sdt)
            };
            int result = context.Database.ExecuteSqlCommand("Registry @TenDn,@MatKhau,@HoTen,@DiaChi,@Email,@Sdt", sqlParams);

            return result;
        }
    }
}
