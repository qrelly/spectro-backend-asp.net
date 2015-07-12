using SpectroWebApplication.DAL;
using SpectroWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace SpectroWebApplication.Controllers
{
    public class _BaseController : Controller
    {
        public SpectroContext context;

        public _BaseController()
        {
            this.context = new SpectroContext();
        }
        
        public Account user {
            get {
                try
                {
                    var account = this.context.Accounts.ToList().Single(a => a.ID == (int)Session["AccountID"]);

                    return account;
                }
                catch
                {
                    return null;
                }
            }
        }
	}
}