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
            ViewBag.user = user;
            ViewBag.posts = this.context.Posts.ToList().OrderBy(o => o.CreatedAt).Reverse().Where(post => post.IsPublic == true);

            return View();
        }
    }
}