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
    public class SlideSearchRepository
    {
        private EcommerceDbContext db = null;

        public SlideSearchRepository()
        {
            db = new EcommerceDbContext();
        }

        public IEnumerable<Slide> Execute(string searchString,int page,int pageSize)
        {
            object[] sqlpara =
            {
                new SqlParameter("@searchString",searchString)
            };
            var model = db.Database.SqlQuery<Slide>("EXEC sp_Slide_Search @searchString", sqlpara).ToList();
            return model.OrderByDescending(x => x.ID).ToPagedList(page,pageSize);
        }

        public List<Slide> getListAll()
        {
            return db.Slides.Where(x => x.Status==true).ToList();
        }
    }
}
