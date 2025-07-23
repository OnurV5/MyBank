using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBank.Controllers
{
    public class CryptoController : Controller
    {
        // GET: Crypto
        [Authorize]
        public ActionResult Index()
        {
            return RedirectToRoute("CryptoRoute");
        }
        
        public ActionResult CryptoBoard()
        {
            return View();
        }
    }
}