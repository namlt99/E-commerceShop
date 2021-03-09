using Models._01.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class UserCheckRepository
    {
        private EcommerceDbContext db = null;

        public UserCheckRepository()
        {
            db = new EcommerceDbContext();
        }

        public int Execute(string email)
        {
            object[] sqlpara =
            {
                new SqlParameter("@email",email)
            };
            var cmd = db.Database.SqlQuery<int>("EXEC sp_User_CheckUser @email", sqlpara).SingleOrDefault();
            return cmd;
        }

        
    }
}
