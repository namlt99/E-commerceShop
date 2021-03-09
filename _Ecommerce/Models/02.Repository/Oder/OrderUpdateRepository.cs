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
    public class OrderUpdateRepository
    {
        private EcommerceDbContext db = null;

        public OrderUpdateRepository()
        {
            db = new EcommerceDbContext();
        }

        public bool Execute(string productGroupName,string seoTitle, bool? status,long id)
        {
            Object[] sqlpara =
            {
                new SqlParameter("@productGroupName",productGroupName),
                new SqlParameter("@productGroupMetaTitle",Function.cutSpaceAndConvert(productGroupName)),
                new SqlParameter("@seoTitle",seoTitle),
                new SqlParameter("@modifiedBy","Admin"),
                new SqlParameter("@modifiedDate",DateTime.Now),
                new SqlParameter("@status",status),
                new SqlParameter("@id",id)
            };
            var model = db.Database.ExecuteSqlCommand("EXEC sp_ProductGroup_Update @productGroupName,@productGroupMetaTitle,@seoTitle,@modifiedBy,@modifiedDate,@status,@id", sqlpara);
            return Convert.ToBoolean(model);
        }
    }
}
