using Models._01.Entity;
using Models._03.Function;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class UserUpdateRepository
    {
        private EcommerceDbContext db = null;

        public UserUpdateRepository()
        {
            db = new EcommerceDbContext();
        }

        public bool Execute(string firstName, string middleName, string lastName, string password, DateTime? dateOfBirth, string address, string avatar, long? status, int? level, int? gender, string numberPhone, long id)
        {
            Object[] sqlpara =
            {
                new SqlParameter("@firstName",firstName),
                new SqlParameter("@middleName",middleName),
                new SqlParameter("@lastName",lastName),
                new SqlParameter("@password",password),
                new SqlParameter("@dateOfBirth",dateOfBirth),
                new SqlParameter("@address",address),
                new SqlParameter("@avatar",avatar),
                new SqlParameter("@status",status),
                new SqlParameter("@level",level),
                new SqlParameter("@gender",gender),
                new SqlParameter("@numberPhone",numberPhone),
                new SqlParameter("@id",id)
            };
            var model = db.Database.ExecuteSqlCommand("EXEC sp_User_Update @firstName,@middleName,@lastName,@password,@dateOfBirth,@address,@avatar,@status,@level,@gender,@numberPhone,@id", sqlpara);
            return Convert.ToBoolean(model);
        }

        public bool UpdateShipping(string firstName, string middleName, string lastName, string address, string numberPhone, long id)
        {
            var user = db.Users.Find(id);
            user.FirstName = firstName;
            user.MiddleName = middleName;
            user.LastName= lastName;
            user.Address = address;
            user.NumberPhone = numberPhone;
            db.SaveChanges();
            return true;
        }
    }
}
