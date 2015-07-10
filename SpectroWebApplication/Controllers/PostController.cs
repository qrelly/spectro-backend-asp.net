using SpectroWebApplication.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpectroWebApplication.Controllers
{
    public class PostController : _BaseController
    {
        public ActionResult Show(int PostID = 1)
        {
            ViewBag.post = this.context.Posts.Single(post => post.ID == PostID);
            
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
	}
}