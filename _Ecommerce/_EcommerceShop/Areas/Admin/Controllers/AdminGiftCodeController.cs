using _EcommerceShop.Common;
using Models;
using Models._03.Function;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _EcommerceShop.Areas.Admin.Controllers
{
    public class AdminGiftCodeController : Controller
    {
        // GET: Admin/AdminGiftCode
        public ActionResult AdminGiftCodeList(string searchString, int page = 1, int pageSize = 10)
        {
            if (searchString == null)
            {
                searchString = "";
            }
            ViewBag.size = pageSize;
            ViewBag.searchString = searchString;
            var cmd = new GiftCodeSearchRepository();
            var model = cmd.Execute(searchString, page, pageSize);
            return View(model);
        }

        // GET: Admin/AdminGiftCode/Details/5
        public ActionResult Details(long id)
        {
            return View();
        }

        // GET: Admin/AdminGiftCode/Create
        public ActionResult AdminGiftCodeInsert()
        {
            return View();
        }

        // POST: Admin/AdminGiftCode/Create
        [HttpPost]
        public ActionResult AdminGiftCodeInsert(FormCollection collection)
        {
            try
            {
                var status = collection["status"].ToString();
                var value = Convert.ToInt32(collection["value"]);
                var cmd = new GiftCodeInsertRepository();
                bool result = cmd.Execute(value,collection["code"], Convert.ToDateTime(collection["startDate"]), Convert.ToDateTime(collection["endDate"]), Function.toBoolean(status));
                if (result)
                {
                    return RedirectToAction("AdminGiftCodeList");
                }
                return View(collection);
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/AdminGiftCode/Edit/5
        public ActionResult AdminGiftCodeEdit(long id)
        {
            var cmd = new GiftCodeGetByIdRepository();
            ViewBag.Result = cmd.Execute(id);
            return View();
        }

        // POST: Admin/AdminGiftCode/Edit/5
        [HttpPost]
        public ActionResult AdminGiftCodeEdit(long id, FormCollection collection)
        {
            try
            {
                var status = collection["status"].ToString();
                var value = Convert.ToInt32(collection["value"]);
                var cmd = new GiftCodeUpdateRepository();
                bool result = cmd.Execute(value, collection["code"], Convert.ToDateTime(collection["startDate"]), Convert.ToDateTime(collection["endDate"]), Function.toBoolean(status),id);
                if (result)
                {
                    return RedirectToAction("AdminGiftCodeList");
                }
                return View(collection);
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/AdminGiftCode/Delete/5
        public ActionResult AdminGiftCodeDelete(long id)
        {
            try
            {
                var cmd = new GiftCodeDeleteById();
                bool result = cmd.Execute(id);
                if (result)
                {
                    return RedirectToAction("AdminGiftCodeList");
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
