using SpectroWebApplication.DAL;
using SpectroWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpectroWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            SpectroContext database = new SpectroContext();

            ViewBag.posts = database.Posts.ToList().Where(post => post.IsPublic == true);

            return View();
        }
    }
}