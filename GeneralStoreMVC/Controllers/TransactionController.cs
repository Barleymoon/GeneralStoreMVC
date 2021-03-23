using GeneralStoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeneralStoreMVC.Controllers
{
    public class TransactionController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Transaction
        public ActionResult Index()
        {
            return View(_db.Transactions.ToList());
        }

        //GET: Transaction
        public ActionResult Create()
        {
            /*var productsList = _db.Products.Select(p => new SelectListItem() { Text = p.Name, Value = p.ProductId.ToString() });
            ViewBag.Products = productsList;*/
            ViewBag.Products = new SelectList(_db.Products, "ProductId", "Name");
            ViewBag.Customers = new SelectList(_db.Customers, "CustomerId", "FullName");
            return View();
        }

        //POST: Transactions
        [HttpPost]
        public ActionResult Create(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _db.Transactions.Add(transaction);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transaction);
        }
    }
}