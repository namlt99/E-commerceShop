using Models._01.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ProductImageGetByIdRepository
    {
        private EcommerceDbContext db = null;

        public ProductImageGetByIdRepository()
        {
            db = new EcommerceDbContext();
        }

        public ProductImage Execute(long id)
        {
            Object[]  sqlpara = 
            {
                new SqlParameter("@id", id)
            };
            var model = db.Database.SqlQuery<ProductImage>("EXEC sp_ProductImage_GetById @id", sqlpara);
            return model.FirstOrDefault();
        }
    }
}
