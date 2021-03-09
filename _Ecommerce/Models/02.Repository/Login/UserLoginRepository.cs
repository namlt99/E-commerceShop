using Models._01.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class UserLoginRepository
    {
        private EcommerceDbContext db = null;

        public UserLoginRepository()
        {
            db = new EcommerceDbContext();
        }

        public bool Execute(string email, string password)
        {
            object[] sqlpara =
            {
                new SqlParameter("@email",email),
                new SqlParameter("@password",password)
            };
            var cmd = db.Database.SqlQuery<bool>("EXEC sp_User_Login @email,@password", sqlpara).SingleOrDefault();
            return cmd;
        }
    }
}
