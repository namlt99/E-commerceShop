using _EcommerceShop.Common;
using Models;
using Models._01.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _EcommerceShop.Areas.Admin.Controllers
{
    public class AdminContactController : BaseController
    {
        // GET: Admin/AdminContact
        public ActionResult AdminContactList(string searchString, int page = 1, int pageSize = 10)
        {
            if (searchString == null)
            {
                searchString = "";
            }
            ViewBag.size = pageSize;
            ViewBag.searchString = searchString;
            var cmd = new ContactSearchRepository();
            var model = cmd.Execute(searchString, page, pageSize);
            return View(model);
        }

        // GET: Admin/AdminContact/Create
        public ActionResult AdminContactInsert()
        {
            return View();
        }

        // POST: Admin/AdminContact/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AdminContactInsert(FormCollection collection)
        {
            try
            {
                string content = collection["content"];
                var status = collection["status"].ToString();
                bool d;
                if (status == "1")
                {
                    d = true;
                }
                else
                {
                    d = false;
                }
                var cmd = new ContactInsertRepository();
                bool result = cmd.Execute(content, d);
                if (result)
                {
                    setAlert("Thêm liên hệ thành công!", "success");
                    return RedirectToAction("AdminContactList");
                }
                return View(collection);
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/AdminContact/Edit/5
        public ActionResult AdminContactEdit(long id)
        {
            var cmd = new ContactGetByIdRepository();
            ViewBag.Result = cmd.Execute(id);
            return View();
        }

        // POST: Admin/AdminContact/Edit/5
        [HttpPost]
        public ActionResult AdminContactEdit(long id, FormCollection collection)
        {
            try
            {
                string content = collection["content"];
                var status= collection["status"].ToString();
                bool d;
                if (status == "1")
                {
                    d = true;
                }
                else
                {
                    d = false;
                }
                var cmd = new ContactUpdateRepository();
                bool result = cmd.Execute(content, d, id);
                if (result)
                {
                    setAlert("Sửa liên hệ thành công!", "success");
                    return RedirectToAction("AdminContactList");
                }
                return View(collection);
            }
            catch
            {
                return View();
            }
        }

        // POST: Admin/AdminContact/Delete/5
        public ActionResult AdminContactDelete(long id)
        {
            try
            {
                var cmd = new ContactDeleteById();
                bool result = cmd.Execute(id);
                if (result)
                {
                    return RedirectToAction("AdminContactList");
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
