using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SpectroWebApplication
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Sign in",
                url: "signin",
                defaults: new { controller = "Account", action = "SignIn" }
            );

            routes.MapRoute(
                name: "Sign up",
                url: "signup",
                defaults: new { controller = "Account", action = "SignUp" }
            );

            routes.MapRoute(
                name: "Post View",
                url: "post/{id}",
                defaults: new { controller = "Post", action = "Show", id = UrlParameter.Optional },
                constraints: new { id = @"\d+" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

