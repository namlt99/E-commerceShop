using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace _EcommerceShop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Product Category",
                url: "san-pham/{CategoryMetaTitle}-{cateId}",
                defaults: new { controller = "Product", action = "ProductByCategory", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Product Detail",
                url: "chi-tiet/{ProductMetaTitle}-{proId}",
                defaults: new { controller = "Product", action = "ProductDetail", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Cart List",
                url: "gio-hang",
                defaults: new { controller = "Cart", action = "CartList", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Checkout",
                url: "thanh-toan",
                defaults: new { controller = "Checkout", action = "Checkout", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Add Cart",
                url: "them-vao-gio-hang",
                defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
