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
            var posts = this.context
                            .Posts
                            .Where(post => post.IsPublic)
                            .OrderByDescending(o => o.CreatedAt)
                            .ToList();

            return View(posts);
        }
    }
}