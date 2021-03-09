using Models._01.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class OrderDeleteById
    {
        private EcommerceDbContext db = null;

        public OrderDeleteById()
        {
            db = new EcommerceDbContext();
        }

        public bool Execute(long id)
        {
            object[] sqlpara =
            {
                new SqlParameter("@id",id)
            };
            var cmd = db.Database.ExecuteSqlCommand("EXEC sp_ProductGroup_Delete_ById  @id", sqlpara);
            return Convert.ToBoolean(cmd);
        }
    }
}
