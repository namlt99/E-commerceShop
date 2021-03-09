using _EcommerceShop.Common;
using _EcommerceShop.Models;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace _EcommerceShop.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
       
        public ActionResult CartList()
        {
            var cart = Session[CommonConstants.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
                ViewBag.Cart = list;
            }
            ViewBag.Count = list.Count();
            return View();
        }

        public JsonResult DeleteAll()
        {
            Session[CommonConstants.CartSession] = null;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult CheckLogin()
        {
            var sessionLogin = (UserLogin)Session[CommonConstants.USER_SESSION];
            if (sessionLogin== null)
            {
                return Json(new
                {
                    status = false
                });
            }
            else
            {
                return Json(new
                {
                    status = true
                });
            }
        }
        public JsonResult Delete(long id)
        {
            var sessionCart = (List<CartItem>)Session[CommonConstants.CartSession];
            sessionCart.RemoveAll(x => x.Product.ID == id);
            Session[CommonConstants.CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }


        public JsonResult Plus(long id,int quantity)
        {
            var sessionCart = (List<CartItem>)Session[CommonConstants.CartSession];
            foreach (var item in sessionCart)
            {
                var jsonItem = sessionCart.SingleOrDefault(x => x.Product.ID == id);
                if (jsonItem != null)
                {
                    item.Quantity = quantity;
                }
            }
            Session[CommonConstants.CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CommonConstants.CartSession];
            foreach(var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.Product.ID == item.Product.ID);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            Session[CommonConstants.CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult AddItem(long productId, int quantity)
        {
            var product = new ProductGetByIdRepository().Execute(productId);
            var cart = Session[CommonConstants.CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.Product.ID == productId))
                {
                    foreach (var item in list)
                    {
                        if (item.Product.ID == productId)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    // create object Cart
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = quantity;
                    list.Add(item);
                }
                // set in Session
                Session[CommonConstants.CartSession] = list;
            }
            else
            {
                // create object Cart
                var item = new CartItem();
                item.Product = product;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                list.Add(item);
                // set in Session
                Session[CommonConstants.CartSession] = list;
            }
            return Json(new
            {
                status = true
            });
        }


    }
}