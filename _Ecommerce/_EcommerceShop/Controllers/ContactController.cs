using Models;
using Models._01.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _EcommerceShop.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult AdminContactList()
        {
            return View();
        }

        // GET: Contact/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Contact/Create
        public ActionResult AdminContactInsert()
        {
            return View();
        }

        // POST: Contact/Create
        [HttpPost]
        public ActionResult AdminContactInsert(Contact contact)
        {
            try
            {
                //var cmd = new ContactInsertRepository();
                //bool result = cmd.Execute(contact); 
                
                    return RedirectToAction("AdminContactList");
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Contact/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Contact/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contact/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Contact/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
