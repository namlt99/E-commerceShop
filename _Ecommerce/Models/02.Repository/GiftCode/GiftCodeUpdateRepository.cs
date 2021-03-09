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
    public class GiftCodeUpdateRepository
    {
        private EcommerceDbContext db = null;

        public GiftCodeUpdateRepository()
        {
            db = new EcommerceDbContext();
        }

        public bool Execute(int? value, string code, DateTime? startDate, DateTime? endDate, bool? status,long id)
        {
            Object[] sqlpara =
            {
                new SqlParameter("@value",value),
                new SqlParameter("@code",code),
                new SqlParameter("@startDate",startDate),
                new SqlParameter("@endDate",endDate),
                new SqlParameter("@modifiedBy","Admin"),
                new SqlParameter("@modifiedDate",DateTime.Now),
                new SqlParameter("@status",status),
                new SqlParameter("@id",id)
            };
            var model = db.Database.ExecuteSqlCommand("EXEC sp_GiftCode_Update @value,@code,@startDate,@endDate,@modifiedBy,@modifiedDate,@status,@id", sqlpara);
            return Convert.ToBoolean(model);
        }
    }
}
