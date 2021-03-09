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
    public class ProductImageSearchRepository
    {
        private EcommerceDbContext db = null;

        public ProductImageSearchRepository()
        {
            db = new EcommerceDbContext();
        }

        public List<ProductImage> Execute(string searchString)
        {
            object[] sqlpara =
            {
                new SqlParameter("@searchString",searchString)
            };
            var model = db.Database.SqlQuery<ProductImage>("EXEC sp_ProductImage_Search @searchString", sqlpara).ToList();
            return model;
        }

        public List<ProductImage> getListAll(string ProCode)
        {
            return db.ProductImages.Where(x => x.ProductCode==ProCode).ToList();
        }
    }
}
