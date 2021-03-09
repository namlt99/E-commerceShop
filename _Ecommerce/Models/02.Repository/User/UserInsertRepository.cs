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
    public class UserInsertRepository
    {
        private EcommerceDbContext db = null;

        public UserInsertRepository()
        {
            db = new EcommerceDbContext();
        }

        public bool Execute(string firstName, string middleName, string lastName, string email, string password, long? codeConfirm, DateTime? dateOfBirth, string address, string avatar, int? status, int? gender, string numberPhone)
        {
            Object[] sqlpara =
            {
                new SqlParameter("@firstName",firstName),
                new SqlParameter("@middleName",middleName),
                new SqlParameter("@lastName",lastName),
                new SqlParameter("@email",email),
                new SqlParameter("@password",password),
                new SqlParameter("@codeConfirm",codeConfirm),
                new SqlParameter("@dateOfBirth",dateOfBirth),
                new SqlParameter("@address",address),
                new SqlParameter("@avatar",avatar),
                new SqlParameter("@status",false),
                new SqlParameter("@gender",gender),
                new SqlParameter("@numberPhone",numberPhone)
            };
            var model = db.Database.ExecuteSqlCommand("EXEC sp_User_Insert @firstName,@middleName,@lastName,@email,@password,@codeConfirm,@dateOfBirth,@address,@avatar,@status,@gender,@numberPhone", sqlpara);
            return Convert.ToBoolean(model);
        }

    }
}
