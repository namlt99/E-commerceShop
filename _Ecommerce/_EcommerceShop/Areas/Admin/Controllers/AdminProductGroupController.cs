using Models;
using Models._03.Function;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _EcommerceShop.Areas.Admin.Controllers
{
    public class AdminProductGroupController : Controller
    {
        // GET: Admin/AdminProductGroup
        public ActionResult AdminProductGroupList(string searchString, int page = 1, int pageSize = 10)
        {
            if (searchString == null)
            {
                searchString = "";
            }
            ViewBag.size = pageSize;
            ViewBag.searchString = searchString;
            var cmd = new ProductGroupSearchRepository();
            var model = cmd.Execute(searchString, page, pageSize);
            return View(model);
        }

        // GET: Admin/AdminProductGroup/Details/5
        public ActionResult Details(long id)
        {
            return View();
        }

        // GET: Admin/AdminProductGroup/Create
        public ActionResult AdminProductGroupInsert()
        {
            return View();
        }

        // POST: Admin/AdminProductGroup/Create
        [HttpPost]
        public ActionResult AdminProductGroupInsert(FormCollection collection)
        {
            try
            {
                var status = collection["status"].ToString();
                var showOnHome = collection["showOnHome"];
                var cmd = new ProductGroupInsertRepository();
                bool result = cmd.Execute(collection["productGroupName"], Function.toBoolean(status));
                if (result)
                {
                    return RedirectToAction("AdminProductGroupList");
                }
                return View(collection);
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/AdminProductGroup/Edit/5
        public ActionResult AdminProductGroupEdit(long id)
        {
            var cmd = new ProductGroupGetByIdRepository();
            ViewBag.Result = cmd.Execute(id);
            return View();
        }

        // POST: Admin/AdminProductGroup/Edit/5
        [HttpPost]
        public ActionResult AdminProductGroupEdit(long id, FormCollection collection)
        {
            try
            {
                
                var status = collection["status"].ToString();
                var cmd = new ProductGroupUpdateRepository();
                bool result = cmd.Execute(collection["productGroupName"],collection["seoTitle"], Function.toBoolean(status),id);
                if (result)
                {
                    return RedirectToAction("AdminProductGroupList");
                }
                return View(collection);
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult AdminProductGroupDelete(long id)
        {
            try
            {
                var cmd = new ProductGroupDeleteById();
                bool result = cmd.Execute(id);
                if (result)
                {
                    return RedirectToAction("AdminProductGroupList");
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
