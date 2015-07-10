using SpectroWebApplication.DAL;
using SpectroWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpectroWebApplication.Controllers
{
    public class _BaseController : Controller
    {
        public SpectroContext context;

        public _BaseController()
        {
            this.context = new SpectroContext();

            var test = Session["AccountID"];

            ViewBag.user = this.user ?? null;
        }

        public Account user {
            get {
                try
                {
                    return this.context.Accounts.Single(a => a.ID == (int) Session["AccountID"]);
                }
                catch
                {
                    return null;
                }
            }
        }
	}
}