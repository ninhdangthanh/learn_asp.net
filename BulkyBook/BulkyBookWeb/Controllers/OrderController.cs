using BulkyBookWeb.Database;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyBookWeb.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _db;

        public OrderController(ApplicationDbContext db)
        {
            _db = db;
        }

        //GET
        public IActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(_db.Customers, "CustomerId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                _db.Orders.Add(order);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(_db.Customers, "CustomerId", "Name", order.CustomerId);
            return RedirectToAction("Index");
        }
    }
}
