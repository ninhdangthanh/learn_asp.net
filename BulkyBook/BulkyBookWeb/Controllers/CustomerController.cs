using BulkyBookWeb.Database;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
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
            List<Customer> objCustomerList = _db.Customers.ToList();
            return View(objCustomerList);
        }
    }
}
