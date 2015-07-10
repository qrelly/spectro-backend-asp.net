using SpectroWebApplication.DAL;
using SpectroWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace SpectroWebApplication.Controllers
{
    public class AccountController : _BaseController
    {
        public ActionResult SignIn()
        {
            if (user != null) return RedirectToAction("Index", "Home");

            ViewBag.email = Request.Form["email"] ?? "";
            ViewBag.password = Request.Form["password"] ?? "";

            return View();
        }

        [HttpPost]
        public ActionResult SignIn(object data)
        {
            if (user != null) return RedirectToAction("Index", "Home");

            var context = new SpectroContext();
            string email = Request.Form["email"];
            string password = Request.Form["password"];

            ViewBag.email = email;
            ViewBag.password = password;

            password = Crypto.SHA256(password).ToLower();
            Account account;

            try
            {
                account = context.Accounts.Single(a => a.Email == email && a.Password == password);

                //Session["AccountID"] = account.ID;
                Session.Add("AccountID", account.ID);

                return RedirectToAction("Index", "Home");
            }
            catch (InvalidOperationException e)
            {
                ViewBag.error = "Invalid email / password combination";
            }


            return View();
        }

        public ActionResult SignUp()
        {
            if (user != null) return RedirectToAction("Index", "Home");

            return View();
        }

        public ActionResult SignOut()
        {
            if (user != null) Session.RemoveAll();

            return RedirectToAction("Index", "Home");;
        }
	}
}