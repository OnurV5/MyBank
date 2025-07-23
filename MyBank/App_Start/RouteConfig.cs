using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyBank
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "RemoveCustomer",
                url: "Admin/RemoveCustomer/{id}",
                defaults: new { controller = "Admin", action = "RemoveCustomer" }
            );
            routes.MapRoute(
                name: "SeeCustomers",
                url: "Admin/SeeCustomers",
                defaults: new { controller = "Admin", action = "SeeCustomers" }
                );
            routes.MapRoute(
                name: "LoginRoute",
                url: "Login/Login",
                defaults: new { controller = "Login", action = "Login" }
                );
            routes.MapRoute(
                name: "CryptoRoute",
                url: "Crypto/CryptoBoard",
                defaults: new { controller = "Crypto", action = "CryptoBoard" }
                );



        }
    }
}
