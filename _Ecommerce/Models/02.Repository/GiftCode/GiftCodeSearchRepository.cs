using Models._01.Entity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class GiftCodeSearchRepository
    {
        private EcommerceDbContext db = null;

        public GiftCodeSearchRepository()
        {
            db = new EcommerceDbContext();
        }

        public IEnumerable<GiftCode> Execute(string searchString,int page,int pageSize)
        {
            object[] sqlpara =
            {
                new SqlParameter("@searchString",searchString)
            };
            var model = db.Database.SqlQuery<GiftCode>("EXEC sp_GiftCode_Search @searchString", sqlpara).ToList();
            return model.OrderByDescending(x => x.ID).ToPagedList(page,pageSize);
        }

        public List<GiftCode> getListAll()
        {
            return db.GiftCodes.ToList();
        }
    }
}
