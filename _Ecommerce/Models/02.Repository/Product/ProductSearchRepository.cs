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
    public class ProductSearchRepository
    {
        private EcommerceDbContext db = null;

        public ProductSearchRepository()
        {
            db = new EcommerceDbContext();
        }

        public IEnumerable<Product> Execute(string searchString,int page,int pageSize)
        {
            object[] sqlpara =
            {
                new SqlParameter("@searchString",searchString)
            };
            var model = db.Database.SqlQuery<Product>("EXEC sp_Product_Search @searchString", sqlpara).ToList();
            return model.OrderByDescending(x => x.ID).ToPagedList(page,pageSize);
        }

        public List<Product> getListAll()
        {
            return db.Products.ToList();
        }

        public List<Product> getProductByCategory(long cateId)
        {
            return db.Products.Where(x => x.CategoryId == cateId && x.Status ==true).ToList();
        }
    }
}
