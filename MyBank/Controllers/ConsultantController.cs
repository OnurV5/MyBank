using MyBank.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBank.Controllers
{
    public class ConsultantController : Controller
    {
        // GET: Consultant
        MyBankDBEntities db=new MyBankDBEntities();
        [Authorize]
        public ActionResult Index()
        { 
            return View();
        }
        public ActionResult AddNewCustomer()
        {
            List<SelectListItem> consultants = (from i in db.Consultant.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = i.Fname + " " + i.LName,
                                                    Value = i.ID.ToString()
                                                }).ToList();
            ViewBag.dgr1 = consultants;
            return View();
        }

        [HttpPost]
        public ActionResult AddNewCustomer(Customer p)
        {
            if (!ModelState.IsValid)
            {
                List<SelectListItem> consultants = (from i in db.Consultant.ToList()
                                                    select new SelectListItem
                                                    {
                                                        Text = i.Fname + " " + i.LName,
                                                        Value = i.ID.ToString()
                                                    }).ToList();
                ViewBag.dgr1 = consultants;
                return View(p);
            }

            int newCustomerId = db.Customer.Any() ? db.Customer.Max(c => c.ID) + 1 : 1;
            p.ID = newCustomerId;

            var consultant = db.Consultant.Where(c => c.ID == p.ConsltID).FirstOrDefault();
            p.Consultant = consultant;

            db.Customer.Add(p);



            db.SaveChanges();
            return RedirectToAction("SeeCustomers");
        }

        public ActionResult RemoveCustomer(int id)
        {
            var customer = db.Customer.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            db.Customer.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("SeeCustomers");
        }
        public ActionResult GetCustomer(int id)
        {
            var customer = db.Customer.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            List<SelectListItem> consultants = (from i in db.Consultant.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = i.Fname + " " + i.LName,
                                                    Value = i.ID.ToString()
                                                }).ToList();
            ViewBag.dgr1 = consultants;


            return View("GetCustomer", customer);
        }
        public ActionResult EditCustomer(Customer p)
        {
            var customer = db.Customer.Find(p.ID);
            if (customer == null)
            {
                return HttpNotFound();
            }
            if (!ModelState.IsValid)
            {
                List<SelectListItem> consultants = (from i in db.Consultant.ToList()
                                                    select new SelectListItem
                                                    {
                                                        Text = i.Fname + " " + i.LName,
                                                        Value = i.ID.ToString()
                                                    }).ToList();
                ViewBag.dgr1 = consultants;
                return View("GetCustomer", customer);

            }
            customer.FName = p.FName;
            customer.FromCountry = p.FromCountry;
            customer.Email = p.Email;
            customer.Phone = p.Phone;
            customer.ConsltID = p.ConsltID;
            customer.Deposit.Cash = p.Deposit.Cash;
            customer.Deposit.Currency = p.Deposit.Currency;
            db.SaveChanges();
            return RedirectToAction("SeeCustomers");
        }
        public ActionResult SeeCustomers()
        {
            var customers = db.Customer.ToList();
            return View(customers);
        }
        public ActionResult AddNewCashTransaction(CashTransactions p)
        {
            var customer = db.Customer.Where(c => c.ID == p.CusID).FirstOrDefault();
            var consultant = db.Consultant.Where(c => c.ID == p.ConsID).FirstOrDefault();
            // Generate a unique ID by getting the max existing ID and adding 1
            p.ID = db.CashTransactions.Max(c => c.ID) + 1;
            p.Customer = customer;
            if (!ModelState.IsValid)
            {
                List<SelectListItem> customers = (from i in db.Customer.ToList()
                                                  select new SelectListItem
                                                  {
                                                      Text = i.FName + " " + i.LName,
                                                      Value = i.ID.ToString()
                                                  }).ToList();
                ViewBag.dgr1 = customers;

                return View("AddNewCashTransaction");

            }
            if (p.Deposit_Withdraw)
            {
                p.Customer.Deposit.Cash = (p.Customer.Deposit.Cash - p.Amount);
            }
            else
            {
                p.Customer.Deposit.Cash = (p.Customer.Deposit.Cash + p.Amount);
            }
            db.CashTransactions.Add(p);
            db.SaveChanges();
            return RedirectToAction("SeeCashTransactions");


        }
        public ActionResult RemoveCashTransaction(int id)
        {
            var cashtransactions = db.CashTransactions.Find(id);
            if (cashtransactions == null)
            {
                return HttpNotFound();
            }
            if (cashtransactions.Deposit_Withdraw)
            {
                cashtransactions.Customer.Deposit.Cash = (cashtransactions.Customer.Deposit.Cash + cashtransactions.Amount);
            }
            else
            {
                cashtransactions.Customer.Deposit.Cash = (cashtransactions.Customer.Deposit.Cash - cashtransactions.Amount);
            }
            db.CashTransactions.Remove(cashtransactions);
            db.SaveChanges();
            return RedirectToAction("SeeCashTransactions");
        }
        /*
        public ActionResult GetCashTransaction(int id)
        {
            var CashTransactions = db.CashTransactions.Find(id);
            String a="";
            if (CashTransactions == null)
            {
                return HttpNotFound();
            }
            List<SelectListItem> customers = (from i in db.Customer.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = i.FName + " " + i.LName,
                                                  Value = i.ID.ToString()
                                              }).ToList();
            ViewBag.dgr1 = customers;
            List<SelectListItem> consultants = (from i in db.Consultant.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = i.Fname + " " + i.LName,
                                                    Value = i.ID.ToString()
                                                }).ToList();
            ViewBag.dgr2 = consultants;
            ViewBag.dgr3 = a;
            return View("GetCashTransaction", CashTransactions);
        }
        public ActionResult EditCashTransaction(CashTransactions p)
        {
            var CashTransactions = db.CashTransactions.Find(p.ID);
            if (CashTransactions == null)
            {
                return HttpNotFound();
            }
            if (!ModelState.IsValid)
            {
                String a = "";
                List<SelectListItem> customers = (from i in db.Customer.ToList()
                                                  select new SelectListItem
                                                  {
                                                      Text = i.FName + " " + i.LName,
                                                      Value = i.ID.ToString()
                                                  }).ToList();
                ViewBag.dgr1 = customers;
                List<SelectListItem> consultants = (from i in db.Consultant.ToList()
                                                    select new SelectListItem
                                                    {
                                                        Text = i.Fname + " " + i.LName,
                                                        Value = i.ID.ToString()
                                                    }).ToList();
                ViewBag.dgr2 = consultants;
                ViewBag.dgr3 = a;
                ViewBag.dgr1 = consultants;
                return View("GetCashTransaction",p);
            }
            CashTransactions.Currency = p.Currency;
            CashTransactions.Amount = p.Amount;
            CashTransactions.CusID = p.CusID;
            CashTransactions.ConsID = p.ConsID;
            CashTransactions.Deposit_Withdraw = p.Deposit_Withdraw;
            CashTransactions.ID = p.ID;
            
            db.SaveChanges();
            return RedirectToAction("SeeCashTransactions");
        }
       */
        public ActionResult SeeCashTransactions()
        {
            var CashTransactionss = db.CashTransactions.ToList();
            return View(CashTransactionss);
        }
    }
}