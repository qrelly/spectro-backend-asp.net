using SpectroWebApplication.DAL;
using SpectroWebApplication.Models;
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
                name: "Sign out",
                url: "signout",
                defaults: new { controller = "Account", action = "SignOut" }
            );

            routes.MapRoute(
                name: "Post View",
                url: "post/{id}",
                defaults: new { controller = "Post", action = "Show", id = "" }
            );

            routes.MapRoute(
                name: "Create Post",
                url: "publish",
                defaults: new { controller = "Post", action = "Create" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

