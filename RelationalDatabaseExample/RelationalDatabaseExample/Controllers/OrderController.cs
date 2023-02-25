using BulkyBookWeb.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RelationalDatabaseExample.Models;
using System;

namespace RelationalDatabaseExample.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _db;

        public OrderController(ApplicationDbContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            var orders = _db.Orders.ToList();
            return View(orders);
        }


        //GET
        public IActionResult Create()
        {

            ViewBag.CustomerId = new SelectList(_db.Customers, "CustomerId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection form, Order order)
        {
            Customer cus1 = _db.Customers.Find(order.CustomerId);
            order.Description = form["descText"];
            order.Customer = cus1;
            

            if (cus1 != null)
            {
                order.Customer = cus1;

                
                _db.Orders.Add(order);
                _db.SaveChanges();
                return RedirectToAction("Index");
                

                ViewBag.CustomerId = new SelectList(_db.Customers, "CustomerId", "Name", order.CustomerId);
                return View(order);
            }
            return RedirectToAction("..");
        }
    }

}
