using Model.EF;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PhienDauGiaModel
    {
        private AuctionOnlineDbContext context = null;

        public PhienDauGiaModel()
        {
            context = new AuctionOnlineDbContext();
        }

        public int Update_Bidding(int id_sanpham, int id_Phiendaugia, string ten, int tien)
        {
            object[] sqlParams =
            {
                new SqlParameter("@Id_Sanpham", id_sanpham),
                new SqlParameter("@Id_Phiendaugia", id_Phiendaugia),
                new SqlParameter("@Ten", ten),
                new SqlParameter("@tien", tien)
            };
            int res = context.Database.ExecuteSqlCommand("Update_Bidding @Id_Sanpham, @Id_Phiendaugia, @Ten, @tien", sqlParams);
            return res;
        }

        public List<PhienDauGia> ListForBidd()
        {
            var list = context.Database.SqlQuery<PhienDauGia>("List_bidd").ToList();
            return list;
        }
    }
}
