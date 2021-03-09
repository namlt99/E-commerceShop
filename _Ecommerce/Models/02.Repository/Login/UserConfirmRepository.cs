using Models._01.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class UserConfirmRepository
    {
        private EcommerceDbContext db = null;

        public UserConfirmRepository()
        {
            db = new EcommerceDbContext();
        }

        public bool Execute(long? code,int? status,long id)
        {
            object[] sqlpara =
            {
                new SqlParameter("@codeConfirm",code),
                new SqlParameter("@status",status),
                new SqlParameter("@id",id)
            };
            var cmd = db.Database.ExecuteSqlCommand("EXEC sp_User_Confirm @codeConfirm,@status,@id", sqlpara);
            return Convert.ToBoolean(cmd);
        }
    }
}
