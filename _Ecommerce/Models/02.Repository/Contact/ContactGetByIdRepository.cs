using Models._01.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ContactGetByIdRepository
    {
        private EcommerceDbContext db = null;

        public ContactGetByIdRepository()
        {
            db = new EcommerceDbContext();
        }

        public Contact Execute(long id)
        {
            Object[]  sqlpara = 
            {
                new SqlParameter("@id", id)
            };
            var model = db.Database.SqlQuery<Contact>("EXEC sp_Contact_GetById @id", sqlpara);
            return model.FirstOrDefault();
        }
    }
}
