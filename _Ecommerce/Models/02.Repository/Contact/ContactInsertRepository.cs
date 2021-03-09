using Models._01.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ContactInsertRepository
    {
        private EcommerceDbContext db = null;

        public ContactInsertRepository()
        {
            db = new EcommerceDbContext();
        }

        public bool Execute(string content, bool? status)
        {
            Object[] sqlpara =
            {
                new SqlParameter("@content",content),
                new SqlParameter("@status",status)
            };
            var model = db.Database.ExecuteSqlCommand("EXEC sp_Contact_Insert @content,@status", sqlpara);
            return Convert.ToBoolean(model);
        }

    }
}
