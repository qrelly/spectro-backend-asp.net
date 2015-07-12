﻿using SpectroWebApplication.DAL;
using SpectroWebApplication.Models;
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

        [HttpPost]
        [ValidateInput(false)]
        public object Create (string title, string content)
        {
            if (user == null) return RedirectToAction("Index", "Home");

            var post = new Post {
                Title = Request.Form["title"],
                Content = Request.Form["content"],
                IsPublic = true,
                CreatedAt = DateTime.Now,
                Account = user
            };

            context.Posts.Add(post);
            context.SaveChanges();

            //return Url.Action("Post", "Show", new { id = post.ID });
            return Url.Action("Index", "Home");
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Remove(string id)
        {
            if (user == null) return RedirectToAction("Index", "Home");

            var PostID = int.Parse(id);
            var post = context.Posts.ToList().Single(p => p.ID == PostID);

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