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
    public class CategoryInsertRepository
    {
        private EcommerceDbContext db = null;

        public CategoryInsertRepository()
        {
            db = new EcommerceDbContext();
        }

        public bool Execute(string categoryName, bool? status,long? productGroupId)
        {
            Object[] sqlpara =
            {
                new SqlParameter("@categoryName",categoryName),
                new SqlParameter("@categoryMetaTitle",Function.cutSpaceAndConvert(categoryName)),
                new SqlParameter("@seoTitle",categoryName),
                new SqlParameter("@createdBy","Admin"),
                new SqlParameter("@status",status),
                new SqlParameter("@productGroupId",productGroupId),
            };
            var model = db.Database.ExecuteSqlCommand("EXEC sp_Category_Insert @categoryName,@categoryMetaTitle,@seoTitle,@createdBy,@status,@productGroupId", sqlpara);
            return Convert.ToBoolean(model);
        }

    }
}
