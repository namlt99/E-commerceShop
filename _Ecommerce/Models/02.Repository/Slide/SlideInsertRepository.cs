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
    public class SlideInsertRepository
    {
        private EcommerceDbContext db = null;

        public SlideInsertRepository()
        {
            db = new EcommerceDbContext();
        }

        public bool Execute(string image, string link, string description, bool? status)
        {
            Object[] sqlpara =
            {
                new SqlParameter("@image",image),
                new SqlParameter("@link",link),
                new SqlParameter("@description",description),
                new SqlParameter("@createdBy","Admin"),
                new SqlParameter("@status",status)
            };
            var model = db.Database.ExecuteSqlCommand("EXEC sp_Slide_Insert @image,@link,@description,@createdBy,@status", sqlpara);
            return Convert.ToBoolean(model);
        }

    }
}
