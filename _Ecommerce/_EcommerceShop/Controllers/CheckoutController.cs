using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _EcommerceShop.Common;
using _EcommerceShop.Models;
using Models;
using Models._01.Entity;

namespace _EcommerceShop.Controllers
{
    public class CheckoutController : Controller
    {
        // GET: Checkout
        public ActionResult Payment()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Shipping()
        {
            var user = (UserLogin)Session[CommonConstants.USER_SESSION];
            if (user != null)
            {
                ViewBag.Customer = new UserGetByIdRepository().Execute(user.UserId);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Shipping(string firstName, string middleName, string lastName, string address, string numberPhone)
        {
            var user = (UserLogin)Session[CommonConstants.USER_SESSION];
            long id = user.UserId;
            var model = new UserUpdateRepository();
            bool cmd = model.UpdateShipping(firstName, middleName, lastName, address, numberPhone, id);
            if (cmd)
            {
                return RedirectToAction("Payment");
            }
            return View();
        }
        [ChildActionOnly]
        public ActionResult ProcessingBar()
        {
            return PartialView();
        }

        public decimal Amount()
        {
            decimal total = 0;
            var cartSession = (List<CartItem>)Session[CommonConstants.CartSession];
            foreach(var item in cartSession)
            {
                decimal finalPrice = (decimal)(item.Product.Price - (item.Product.Price / 100 * item.Product.Discount));
                total += finalPrice * item.Quantity;
            }
            return total;
        }
        public JsonResult ShipCOD()
        {
            var userSession = (UserLogin)Session[CommonConstants.USER_SESSION];
            var cartSession = (List<CartItem>)Session[CommonConstants.CartSession];
            long code = new Random().Next(000000, 999999);
            string orderCodes = "ORDER_" + code;
            var order = new Order();
            order.CreatedDate = DateTime.Now;
            order.UserId = userSession.UserId;
            order.OrderCode = orderCodes;
            order.Status = 1;
            order.Amount = Amount();
            
            try
            {
                long id = new OrderInsertRepository().Insert(order);
                var detail = new OrderDetail();
                var cmdDetail = new OrderDetailInsertRepository();
                foreach (var item in cartSession)
                {
                    detail.OrderCode = orderCodes;
                    detail.ProductID = item.Product.ID;
                    detail.ProductCode = item.Product.ProductCode;
                    detail.Quantity = item.Quantity;
                    detail.TotalProductPrice = item.Quantity * item.Product.Price;
                    detail.Status = true;
                    cmdDetail.Insert(detail);
                }
                Session[CommonConstants.CartSession] = null;
                return Json(new
                {
                    status = true
                });
            }
            catch
            {
                return Json(new
                {
                    status = false
                });
            }

        }
    }
}