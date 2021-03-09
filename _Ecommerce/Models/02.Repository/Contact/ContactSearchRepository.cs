using Models._01.Entity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ContactSearchRepository
    {
        private EcommerceDbContext db = null;

        public ContactSearchRepository()
        {
            db = new EcommerceDbContext();
        }

        public IEnumerable<Contact> Execute(string searchString,int page,int pageSize)
        {
            object[] sqlpara =
            {
                new SqlParameter("@searchString",searchString)
            };
            var model = db.Database.SqlQuery<Contact>("EXEC sp_Contact_Search @searchString", sqlpara).ToList();
            return model.OrderByDescending(x => x.ID).ToPagedList(page,pageSize);
        }
    }
}
