using Models._01.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ProductGetByIdRepository
    {
        private EcommerceDbContext db = null;

        public ProductGetByIdRepository()
        {
            db = new EcommerceDbContext();
        }

        public Product Execute(long id)
        {
            Object[]  sqlpara = 
            {
                new SqlParameter("@id", id)
            };
            var model = db.Database.SqlQuery<Product>("EXEC sp_Product_GetById @id", sqlpara);
            return model.FirstOrDefault();
        }
    }
}
