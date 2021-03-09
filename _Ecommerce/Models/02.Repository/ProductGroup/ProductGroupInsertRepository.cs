using Models._01.Entity;
using Models._03.Function;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ProductGroupInsertRepository
    {
        private EcommerceDbContext db = null;

        public ProductGroupInsertRepository()
        {
            db = new EcommerceDbContext();
        }

        public bool Execute(string productGroupName, bool? status)
        {
            Object[] sqlpara =
            {
                new SqlParameter("@productGroupName",productGroupName),
                new SqlParameter("@productGroupMetaTitle",Function.cutSpaceAndConvert(productGroupName)),
                new SqlParameter("@seoTitle",productGroupName),
                new SqlParameter("@createdBy","Admin"),
                new SqlParameter("@status",status)
            };
            var model = db.Database.ExecuteSqlCommand("EXEC sp_ProductGroup_Insert @productGroupName,@productGroupMetaTitle,@seoTitle,@createdBy,@status", sqlpara);
            return Convert.ToBoolean(model);
        }

    }
}
