using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBank.Controllers
{
    public class ExchangeController : Controller
    {
        // GET: Exchange
        [Authorize]
        public ActionResult Index()
        {
            return RedirectToRoute("ExchangeRoute");
        }
        public ActionResult ExchangeBoard()
        {
            return View();
        }
    }
}