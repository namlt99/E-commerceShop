using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _EcommerceShop.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [ChildActionOnly]
        public ActionResult Menu()
        {
            var cmd = new ProductGroupSearchRepository();
            ViewBag.ProductGroup = cmd.getListAll();
            return PartialView();
        }

        public PartialViewResult ChildrenMenu(long parentId)
        {
            ViewBag.Count = new CategorySearchRepository().getCategoryByProductGroupId(parentId).Count();
            ViewBag.ChildrenMenu = new CategorySearchRepository().getCategoryByProductGroupId(parentId);

            return PartialView();
        }

        public PartialViewResult Slide()
        {
            var cmd = new SlideSearchRepository().getListAll();

            ViewBag.Slides = cmd;
            return PartialView();
        }
    }
}