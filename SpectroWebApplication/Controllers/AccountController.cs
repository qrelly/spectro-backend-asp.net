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
using System.Web.Security;

namespace SpectroWebApplication.Controllers
{
    public class AccountController : _BaseController
    {
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(string email, string password)
        {
            if (user != null) return RedirectToAction("Index", "Home");

            var context = new SpectroContext();

            ViewBag.email = email;
            ViewBag.password = password;

            password = Crypto.SHA256(password).ToLower();

            Account account = context.Accounts.First(a => a.Email == email);

            if (account.Password == password)
            {
                FormsAuthentication.SetAuthCookie(account.Email, createPersistentCookie: true);
                Session["Account"] = account;

                return RedirectToAction("Index", "Home");
            }
            else
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

        [HttpPost]
        public ActionResult SignUp (string email, string name, string password)
        {
            if (user != null) return RedirectToAction("Index", "Home");

            password = Crypto.SHA256(password).ToLower();

            var existedAccount = context.Accounts.FirstOrDefault(a => a.Email == email);

            if (existedAccount == null)
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
            else
            {
                ViewBag.error = "Email already taken";

                return View();
            }
        }

        public ActionResult SignOut()
        {
            if (user != null)
            {
                FormsAuthentication.SignOut();
                Session.Abandon();
            }

            return RedirectToAction("Index", "Home");;
        }
	}
}