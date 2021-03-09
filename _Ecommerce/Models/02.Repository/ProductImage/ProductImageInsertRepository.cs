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
    public class ProductImageInsertRepository
    {
        private EcommerceDbContext db = null;

        public ProductImageInsertRepository()
        {
            db = new EcommerceDbContext();
        }

        public bool Execute(string productCode, string fileName, string filePhysicalName, int? isMainImage)
        {
            Object[] sqlpara =
            {
                new SqlParameter("@productCode",productCode),
                new SqlParameter("@fileName",fileName),
                new SqlParameter("@filePhysicalName",filePhysicalName),
                new SqlParameter("@isMainImage",isMainImage)
            };
            var model = db.Database.ExecuteSqlCommand("EXEC sp_ProductImage_Insert @productCode,@fileName,@filePhysicalName,@isMainImage", sqlpara);
            return Convert.ToBoolean(model);
        }

    }
}
