using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBank.Models.Entity;
using System.Web.Security;


namespace MyBank.Controllers
{
    public class LoginController : Controller

    {
        // GET: Login
        MyBankDBEntities db = new MyBankDBEntities();
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(member mem)
        {
            System.Diagnostics.Debug.WriteLine("Login methodu çalıştı");
            var admininfo = db.Administrator.FirstOrDefault(x => x.Email == mem.email && x.Pwrd == mem.password);
            if (admininfo != null)
            {
                FormsAuthentication.SetAuthCookie(mem.email, false);
                Session["UserType"] = "Admin";
                return RedirectToAction("Index", "Admin");
            }
            var consultantinfo = db.Consultant.FirstOrDefault(u => u.Email == mem.email && u.Pwrd == mem.password);
            if (consultantinfo != null)
            {
                FormsAuthentication.SetAuthCookie(mem.email, false);
                Session["UserType"] = "User";
                return RedirectToAction("Index", "Consultant");
            }
            // Kullanıcı bulunamadı
            ViewBag.ErrorMessage = "Geçersiz kullanıcı adı veya şifre!";
            return View();
        }



    }
    public class member
    {
        public string email { get; set; }
        public string password { get; set; }
        public member() { }
    }
}