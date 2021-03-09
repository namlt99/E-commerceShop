using Models._01.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SlideGetByIdRepository
    {
        private EcommerceDbContext db = null;

        public SlideGetByIdRepository()
        {
            db = new EcommerceDbContext();
        }

        public Slide Execute(long id)
        {
            Object[]  sqlpara = 
            {
                new SqlParameter("@id", id)
            };
            var model = db.Database.SqlQuery<Slide>("EXEC sp_Slide_GetById @id", sqlpara);
            return model.FirstOrDefault();
        }
    }
}
