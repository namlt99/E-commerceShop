using Models._01.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CategoryGetByIdRepository
    {
        private EcommerceDbContext db = null;

        public CategoryGetByIdRepository()
        {
            db = new EcommerceDbContext();
        }

        public Category Execute(long id)
        {
            Object[]  sqlpara = 
            {
                new SqlParameter("@id", id)
            };
            var model = db.Database.SqlQuery<Category>("EXEC sp_Category_GetById @id", sqlpara);
            return model.FirstOrDefault();
        }
    }
}
