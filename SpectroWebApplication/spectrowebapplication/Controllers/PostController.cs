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
        public ActionResult Show(int PostID)
        {
            return View();
        }
	}
}