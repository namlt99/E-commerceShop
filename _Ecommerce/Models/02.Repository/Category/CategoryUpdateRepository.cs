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
    public class CategoryUpdateRepository
    {
        private EcommerceDbContext db = null;

        public CategoryUpdateRepository()
        {
            db = new EcommerceDbContext();
        }

        public bool Execute(string categoryName,string seoTitle, bool? status,long id,long? productGroupId)
        {
            Object[] sqlpara =
            {
                new SqlParameter("@categoryName",categoryName),
                new SqlParameter("@categoryMetaTitle",Function.cutSpaceAndConvert(categoryName)),
                new SqlParameter("@seoTitle",seoTitle),
                new SqlParameter("@modifiedBy","Admin"),
                new SqlParameter("@modifiedDate",DateTime.Now),
                new SqlParameter("@status",status),
                new SqlParameter("@id",id),
                new SqlParameter("@productGroupId",productGroupId)
            };
            var model = db.Database.ExecuteSqlCommand("EXEC sp_Category_Update @categoryName,@categoryMetaTitle,@seoTitle,@modifiedBy,@modifiedDate,@status,@id,@productGroupId", sqlpara);
            return Convert.ToBoolean(model);
        }
    }
}
