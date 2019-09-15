using Model.EF;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UpdateStatus
    {
        private AuctionOnlineDbContext context = null;

        public UpdateStatus()
        {
            context = new AuctionOnlineDbContext();
        }

        public SanPhamDauGia GetByID(int id)
        {
            return context.SanPhamDauGias.SingleOrDefault(x => x.ID_SanPham == id);
        }

        public int Update (int id) 
        {
            object[] sqlParams =
            {
                new SqlParameter("@ID", id)        
            };
            int result = context.Database.ExecuteSqlCommand("UP_UpdateStatus @ID", sqlParams);

            return result;
            
        }
    }
}
