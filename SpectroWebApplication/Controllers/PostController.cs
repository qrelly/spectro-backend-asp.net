using SpectroWebApplication.DAL;
using SpectroWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace SpectroWebApplication.Controllers
{
    public class PostController : _BaseController
    {
        public ActionResult Show (int id)
        {
            var post = this.context.Posts.First(p => p.ID == id);

            return View(post);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public object Create (string title, string content)
        {
            if (user == null) return RedirectToAction("Index", "Home");

            var post = new Post {
                Title = title,
                Content = content,
                IsPublic = true,
                CreatedAt = DateTime.Now,
                Account = user
            };

            context.Posts.Add(post);
            context.SaveChanges();

            return Url.Action("Post", "Show", new { id = post.ID });
        }

        public ActionResult Edit (int id)
        {
            var post = context.Posts.First(p => p.ID == id);

            return View(post);
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Edit (int id, string title, string content)
        {
            var post = context.Posts.First(p => p.ID == id);

            if (post.Account.ID == user.ID)
            {
                post.Title = title;
                post.Content = content;

                context.SaveChanges();

                return Json(new {
                    status = "success",
                    redirect = Url.Action("Edit", "Post", new { id = post.ID })
                });
            }

            return Json(new {
                status = "failure",
                message = "Access denied"
            });
        }

        public ActionResult Remove (int id)
        {
            if (user == null) return RedirectToAction("Index", "Home");

            var post = context.Posts.First(p => p.ID == id);

            if (user != post.Account)
            {
                RedirectToAction("Index", "Home");
            }

            context.Posts.Remove(post);
            context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
	}
}