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
    public class ProductUpdateRepository
    {
        private EcommerceDbContext db = null;

        public ProductUpdateRepository()
        {
            db = new EcommerceDbContext();
        }

        public bool Execute(string productName, string productCode,string seoTitle, string image, decimal? price, int? discount, string detail, int? quantity, DateTime? topHot, bool? status, long? categoryId,long id)
        {
            Object[] sqlpara =
            {
                new SqlParameter("@productName",productName),
                new SqlParameter("@productCode",productCode),
                new SqlParameter("@productMetaTitle",Function.cutSpaceAndConvert(productName)),
                new SqlParameter("@seoTitle",seoTitle),
                new SqlParameter("@image",image),
                new SqlParameter("@price",price),
                new SqlParameter("@discount",discount),
                new SqlParameter("@detail",detail),
                new SqlParameter("@quantity",quantity),
                new SqlParameter("@topHot",topHot),
                new SqlParameter("@createdBy","Admin"),
                new SqlParameter("@status",status),
                new SqlParameter("@categoryId",categoryId),
                new SqlParameter("@id",id)
            };
            var model = db.Database.ExecuteSqlCommand("EXEC sp_Product_Update @productName,@productCode,@productMetaTitle,@seoTitle,@image,@price,@discount,@detail,@quantity,@topHot,@createdBy,@status,@categoryId,@id", sqlpara);
            return Convert.ToBoolean(model);
        }
    }
}
