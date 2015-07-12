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
        public ActionResult Show (string id)
        {
            ViewBag.user = user;

            int PostID = int.Parse(id);

            ViewBag.post = this.context.Posts.Single(post => post.ID == PostID);
            
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.user = user;

            return View();
        }
	}
}