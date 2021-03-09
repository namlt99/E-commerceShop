using Models._01.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class GiftCodeGetByIdRepository
    {
        private EcommerceDbContext db = null;

        public GiftCodeGetByIdRepository()
        {
            db = new EcommerceDbContext();
        }

        public GiftCode Execute(long id)
        {
            Object[]  sqlpara = 
            {
                new SqlParameter("@id", id)
            };
            var model = db.Database.SqlQuery<GiftCode>("EXEC sp_GiftCode_GetById @id", sqlpara);
            return model.FirstOrDefault();
        }
    }
}
