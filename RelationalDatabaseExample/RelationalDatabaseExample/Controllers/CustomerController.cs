using BulkyBookWeb.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RelationalDatabaseExample.Models;

namespace RelationalDatabaseExample.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CustomerController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var customerObj = _db.Customers.Include(e => e.Orders).ToList();
            return View(customerObj);
        }
    }
}
