using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _EcommerceShop.Controllers
{
    public class ProductController : Controller
    {
        // GET: ProductGroup
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductByCategory(long cateId)
        {
            ViewBag.Products = new ProductSearchRepository().getProductByCategory(cateId);
            return View();
        }
        [ValidateInput(false)]
        public ActionResult ProductDetail(long proId)
        {
            ViewBag.Product = new ProductGetByIdRepository().Execute(proId);
            ViewBag.Images = new ProductImageSearchRepository().getListAll(ViewBag.Product.ProductCode);
            return View();
        }
    }
}