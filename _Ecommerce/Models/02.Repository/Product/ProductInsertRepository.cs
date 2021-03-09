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
    public class ProductInsertRepository
    {
        private EcommerceDbContext db = null;

        public ProductInsertRepository()
        {
            db = new EcommerceDbContext();
        }

        public bool Execute(string productName, string productCode, string image, decimal? price, string detail, int? quantity, bool? status, long? categoryId)
        {
            Object[] sqlpara =
            {
                new SqlParameter("@productName",productName),
                new SqlParameter("@productCode",productCode),
                new SqlParameter("@productMetaTitle",Function.cutSpaceAndConvert(productName)),
                new SqlParameter("@seoTitle",productName),
                new SqlParameter("@image",image),
                new SqlParameter("@price",price),
                new SqlParameter("@detail",detail),
                new SqlParameter("@quantity",quantity),
                new SqlParameter("@createdBy","Admin"),
                new SqlParameter("@status",status),
                new SqlParameter("@categoryId",categoryId)
            };
            var model = db.Database.ExecuteSqlCommand("EXEC sp_Product_Insert @productName,@productCode,@productMetaTitle,@seoTitle,@image,@price,@detail,@quantity,@createdBy,@status,@categoryId", sqlpara);
            return Convert.ToBoolean(model);
        }

    }
}
