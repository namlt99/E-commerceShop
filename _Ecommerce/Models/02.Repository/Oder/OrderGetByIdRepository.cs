using Models._01.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class OrderGetByIdRepository
    {
        private EcommerceDbContext db = null;

        public OrderGetByIdRepository()
        {
            db = new EcommerceDbContext();
        }

        public ProductGroup Execute(long id)
        {
            Object[]  sqlpara = 
            {
                new SqlParameter("@id", id)
            };
            var model = db.Database.SqlQuery<ProductGroup>("EXEC sp_ProductGroup_GetById @id", sqlpara);
            return model.FirstOrDefault();
        }
    }
}
