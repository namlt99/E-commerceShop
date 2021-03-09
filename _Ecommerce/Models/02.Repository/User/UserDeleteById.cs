using Models._01.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class UserDeleteById
    {
        private EcommerceDbContext db = null;

        public UserDeleteById()
        {
            db = new EcommerceDbContext();
        }

        public bool Execute(long id)
        {
            object[] sqlpara =
            {
                new SqlParameter("@id",id)
            };
            var cmd = db.Database.ExecuteSqlCommand("EXEC sp_User_Delete_ById @id", sqlpara);
            return Convert.ToBoolean(cmd);
        }
    }
}
