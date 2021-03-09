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
    public class UserSearchRepository
    {
        private EcommerceDbContext db = null;

        public UserSearchRepository()
        {
            db = new EcommerceDbContext();
        }

        public IEnumerable<User> Execute(string searchString,int page,int pageSize)
        {
            object[] sqlpara =
            {
                new SqlParameter("@searchString",searchString)
            };
            var model = db.Database.SqlQuery<User>("EXEC sp_User_Search @searchString", sqlpara).ToList();
            return model.OrderByDescending(x => x.ID).ToPagedList(page,pageSize);
        }

        public List<User> getListAll()
        {
            return db.Users.ToList();
        }
    }
}
