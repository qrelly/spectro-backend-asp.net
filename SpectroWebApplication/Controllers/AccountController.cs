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

            ViewBag.user = user;

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

                Session["AccountID"] = account.ID;

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

            ViewBag.user = user;

            return View();
        }

        [HttpPost]
        public ActionResult SignUp(string _email, string _name, string _password)
        {
            if (user != null) return RedirectToAction("Index", "Home");

            var email = Request.Form["email"];
            var name = Request.Form["name"];
            var password = Request.Form["password"];

            password = Crypto.SHA256(password).ToLower();

            try
            {
                context.Accounts.ToList().Single(a => a.Email == email);
            }
            catch (Exception e)
            {
                var account = new Account
                {
                    Email = email,
                    Name = name,
                    Password = password
                };

                context.Accounts.Add(account);
                context.SaveChanges();

                return RedirectToAction("SignIn", "Account");
            }

            ViewBag.error = "Email already taken";

            return View();
        }

        public ActionResult SignOut()
        {
            if (user != null) Session.RemoveAll();

            ViewBag.user = user;

            return RedirectToAction("Index", "Home");;
        }
	}
}