using SpectroWebApplication.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpectroWebApplication.Controllers
{
    public class PostController : Controller
    {
        //
        // GET: /Post/:id
        public ActionResult Show(int PostID = 1)
        {
            SpectroContext context = new SpectroContext();

            ViewBag.post = context.Posts.Single(post => post.ID == PostID);
            
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
	}
}