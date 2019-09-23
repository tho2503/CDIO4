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

        public int Update_Bidding(long tien, long id_sanpham, string ten)
        {
            object[] sqlParams =
            {
                new SqlParameter("@Tien", tien),
                new SqlParameter("@Id_Sanpham", id_sanpham),
                new SqlParameter("@Ten", ten)
            };
            int res = context.Database.ExecuteSqlCommand("Update_Bidding @Tien, @Id_Sanpham, @Ten", sqlParams);
            if (res > 0)
                return res;
            else
                return 0;
        }

        public List<PhienDauGia> ListForBidd()
        {
            var list = context.Database.SqlQuery<PhienDauGia>("List_bidd").ToList();
            return list;

        }      
    }
}
