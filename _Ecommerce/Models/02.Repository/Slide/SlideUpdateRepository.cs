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
    public class SlideUpdateRepository
    {
        private EcommerceDbContext db = null;

        public SlideUpdateRepository()
        {
            db = new EcommerceDbContext();
        }

        public bool Execute(string image, string link, string description, bool? status, long id)
        {
            Object[] sqlpara =
            {
                new SqlParameter("@image",image),
                new SqlParameter("@link",link),
                new SqlParameter("@description",description),
                new SqlParameter("@modifiedBy","Admin"),
                new SqlParameter("@modifiedDate",DateTime.Now),
                new SqlParameter("@status",status),
                new SqlParameter("@id",id)
            };
            var model = db.Database.ExecuteSqlCommand("EXEC sp_Slide_Update @image,@link,@description,@modifiedBy,@modifiedDate,@status,@id", sqlpara);
            return Convert.ToBoolean(model);
        }
    }
}
