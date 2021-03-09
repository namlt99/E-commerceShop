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
    public class GiftCodeInsertRepository
    {
        private EcommerceDbContext db = null;

        public GiftCodeInsertRepository()
        {
            db = new EcommerceDbContext();
        }

        public bool Execute(int? value,string code, DateTime? startDate, DateTime? endDate, bool? status)
        {
            Object[] sqlpara =
            {
                new SqlParameter("@value",value),
                new SqlParameter("@code",code),
                new SqlParameter("@startDate",startDate),
                new SqlParameter("@endDate",endDate),
                new SqlParameter("@createdBy","Admin"),
                new SqlParameter("@status",status)
            };
            var model = db.Database.ExecuteSqlCommand("EXEC sp_GiftCode_Insert @value,@code,@startDate,@endDate,@createdBy,@status", sqlpara);
            return Convert.ToBoolean(model);
        }

    }
}
