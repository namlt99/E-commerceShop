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
    public class ProductImageUpdateRepository
    {
        private EcommerceDbContext db = null;

        public ProductImageUpdateRepository()
        {
            db = new EcommerceDbContext();
        }

        public bool Execute(string productCode, string fileName, string filePhysicalName, int? isMainImage, long id)
        {
            Object[] sqlpara =
            {
                new SqlParameter("@productCode",productCode),
                new SqlParameter("@fileName",fileName),
                new SqlParameter("@filePhysicalName",filePhysicalName),
                new SqlParameter("@isMainImage",isMainImage),
                new SqlParameter("@id",id)
            };
            var model = db.Database.ExecuteSqlCommand("EXEC sp_ProductImage_Insert @productCode,@fileName,@filePhysicalName,@isMainImage,@id", sqlpara);
            return Convert.ToBoolean(model);
        }
    }
}
