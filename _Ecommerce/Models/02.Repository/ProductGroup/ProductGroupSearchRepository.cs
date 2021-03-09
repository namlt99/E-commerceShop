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
    public class ProductGroupSearchRepository
    {
        private EcommerceDbContext db = null;

        public ProductGroupSearchRepository()
        {
            db = new EcommerceDbContext();
        }

        public IEnumerable<ProductGroup> Execute(string searchString,int page,int pageSize)
        {
            object[] sqlpara =
            {
                new SqlParameter("@searchString",searchString)
            };
            var model = db.Database.SqlQuery<ProductGroup>("EXEC sp_ProductGroup_Search @searchString", sqlpara).ToList();
            return model.OrderByDescending(x => x.ID).ToPagedList(page,pageSize);
        }

        public List<ProductGroup> getListAll()
        {
            return db.ProductGroups.Where(x =>x.Status == true).ToList();
        }
    }
}
