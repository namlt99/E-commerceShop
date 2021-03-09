using Models._01.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class UserGetByIdRepository
    {
        private EcommerceDbContext db = null;

        public UserGetByIdRepository()
        {
            db = new EcommerceDbContext();
        }

        public User Execute(long id)
        {
            Object[]  sqlpara = 
            {
                new SqlParameter("@id", id)
            };
            var model = db.Database.SqlQuery<User>("EXEC sp_User_GetById @id", sqlpara);
            return model.FirstOrDefault();
        }

        public User GetUserByEmail(string email)
        {
            return db.Users.SingleOrDefault(x=> x.Email == email);
        }
    }
}
