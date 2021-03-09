using Models._01.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ContactUpdateRepository
    {
        private EcommerceDbContext db = null;

        public ContactUpdateRepository()
        {
            db = new EcommerceDbContext();
        }

        public bool Execute(string content, bool? status, long id)
        {
            Object[] sqlpara =
            {
                new SqlParameter("@content",content),
                new SqlParameter("@status",status),
                new SqlParameter("@id",id)
            };
            var model = db.Database.ExecuteSqlCommand("EXEC sp_Contact_Update @content,@status,@id", sqlpara);
            return Convert.ToBoolean(model);
        }
    }
}
