using Models;
using Models._03.Function;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _EcommerceShop.Areas.Admin.Controllers
{
    public class AdminCategoryController : Controller
    {
        // GET: Admin/AdminCategory
        public ActionResult AdminCategoryList(string searchString, int page = 1, int pageSize = 10)
        {
            if (searchString == null)
            {
                searchString = "";
            }
            ViewBag.size = pageSize;
            ViewBag.searchString = searchString;
            var cmd = new CategorySearchRepository();
            var model = cmd.Execute(searchString, page, pageSize);
            return View(model);
        }

        // GET: Admin/AdminCategory/Create
        [HttpGet]
        public ActionResult AdminCategoryInsert()
        {
            ViewBag.ProductGroup = new ProductGroupSearchRepository().getListAll();
            return View();
        }

        // POST: Admin/AdminCategory/Create
        [HttpPost]
        public ActionResult AdminCategoryInsert(FormCollection collection)
        {
            try
            {
                var status = collection["status"].ToString();
                int productGroupId =Convert.ToInt32(collection["productGroupId"]);
                var cmd = new CategoryInsertRepository();
                bool result = cmd.Execute(collection["categoryName"], Function.toBoolean(status),productGroupId);
                if (result)
                {
                    return RedirectToAction("AdminCategoryList");
                }
                return View(collection);
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/AdminCategory/Edit/5
        public ActionResult AdminCategoryEdit(long id)
        {
            var cmd = new CategoryGetByIdRepository();
            ViewBag.Result = cmd.Execute(id);
            ViewBag.ProductGroupSelected = new ProductGroupGetByIdRepository().Execute(ViewBag.Result.ProductGroupId);
            ViewBag.ProductGroup = new ProductGroupSearchRepository().getListAll();
            return View();
        }

        // POST: Admin/AdminCategory/Edit/5
        [HttpPost]
        public ActionResult AdminCategoryEdit(long id, FormCollection collection)
        {
            try
            {

                var status = collection["status"].ToString();
                int productGroupId = Convert.ToInt32(collection["productGroupId"]);
                var cmd = new CategoryUpdateRepository();
                bool result = cmd.Execute(collection["categoryName"], collection["seoTitle"], Function.toBoolean(status), id,productGroupId);
                if (result)
                {
                    return RedirectToAction("AdminCategoryList");
                }
                return View(collection);
            }
            catch
            {
                return View(collection);
            }
        }
       
        public ActionResult AdminCategoryDelete(long id)
        {
            try
            {
                var cmd = new CategoryDeleteById();
                bool result = cmd.Execute(id);
                if (result)
                {
                    return RedirectToAction("AdminCategoryList");
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
