using Models;
using Models._03.Function;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _EcommerceShop.Areas.Admin.Controllers
{
    public class AdminProductController : Controller
    {
        // GET: Admin/AdminProduct
        public ActionResult AdminProductList(string searchString, int page = 1, int pageSize = 10)
        {
            if (searchString == null)
            {
                searchString = "";
            }
            ViewBag.size = pageSize;
            ViewBag.searchString = searchString;
            var cmd = new ProductSearchRepository();
            var model = cmd.Execute(searchString, page, pageSize);
            return View(model);
        }

        // GET: Admin/AdminProduct/Details/5
        public ActionResult AdminProductDetail(long id)
        {
            ViewBag.Result = new ProductGetByIdRepository().Execute(id);
            ViewBag.Images = new ProductImageSearchRepository().Execute(ViewBag.Result.ProductCode);
            return View();
        }

        // GET: Admin/AdminProduct/Create
        public ActionResult AdminProductInsert()
        {
            ViewBag.Category = new CategorySearchRepository().getListAll();
            return View();
        }

        // POST: Admin/AdminProduct/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AdminProductInsert(FormCollection collection)
        {
            try
            {
                var status = collection["status"].ToString();
                var cmd = new ProductInsertRepository();
                bool result = cmd.Execute(collection["productName"], collection["productCode"], collection["image"], Convert.ToInt32(collection["price"]), collection["detail"], Convert.ToInt32(collection["quantity"]),Function.toBoolean(status), Convert.ToInt64(collection["categoryId"]));
                if (result)
                {
                    return RedirectToAction("AdminProductList");
                }
                return View(collection);
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/AdminProduct/Edit/5
        public ActionResult AdminProductEdit(long id)
        {
            var cmd = new ProductGetByIdRepository();
            ViewBag.Result = cmd.Execute(id);
            ViewBag.CategorySelected = new CategoryGetByIdRepository().Execute(ViewBag.Result.CategoryId);
            ViewBag.Category = new CategorySearchRepository().getListAll();
            return View();
        }

        // POST: Admin/AdminProduct/Edit/5
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AdminProductEdit(long id, FormCollection collection)
        {
            try
            {

                var status = collection["status"].ToString();
                var cmd = new ProductUpdateRepository();
                bool result = cmd.Execute(collection["productName"],collection["productCode"], collection["seoTitle"],collection["image"],Convert.ToInt64(collection["price"]), Convert.ToInt32(collection["discount"]),collection["detail"],Convert.ToInt32(collection["quantity"]), Convert.ToDateTime(collection["topHot"]),Function.toBoolean(status), Convert.ToInt32(collection["categoryId"]), id);
                if (result)
                {
                    return RedirectToAction("AdminProductList");
                }
                return View(collection);
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/AdminProduct/Delete/5
        public ActionResult AdminProductDelete(long id)
        {
            try
            {
                var cmd = new ProductDeleteById();
                bool result = cmd.Execute(id);
                if (result)
                {
                    return RedirectToAction("AdminProductList");
                }
                else
                {
                    return ViewBag.Error = "Khong xoa dc";
                }
            }
            catch
            {
                return View();
            }
        }

        
    }
}
