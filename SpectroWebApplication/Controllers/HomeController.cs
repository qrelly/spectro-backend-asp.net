using SpectroWebApplication.DAL;
using SpectroWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpectroWebApplication.Controllers
{
    public class HomeController : _BaseController
    {
        public ActionResult Index()
        {
            ViewBag.posts = this.context.Posts.ToList().Where(post => post.IsPublic == true);

            return View();
        }
    }
}