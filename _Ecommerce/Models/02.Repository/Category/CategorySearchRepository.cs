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
    public class CategorySearchRepository
    {
        private EcommerceDbContext db = null;

        public CategorySearchRepository()
        {
            db = new EcommerceDbContext();
        }

        public IEnumerable<Category> Execute(string searchString,int page,int pageSize)
        {
            object[] sqlpara =
            {
                new SqlParameter("@searchString",searchString)
            };
            var model = db.Database.SqlQuery<Category>("EXEC sp_Category_Search @searchString", sqlpara).ToList();
            return model.OrderByDescending(x => x.ID).ToPagedList(page,pageSize);
        }

        public List<Category> getListAll()
        {
            return db.Categories.ToList();
        }

        public List<Category> getCategoryByProductGroupId(long id)
        {
            return db.Categories.Where(x => x.ProductGroupId == id && x.Status==true).ToList();
        }
    }
}
