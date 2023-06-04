using LaptopTieuLuan.Data;
using LaptopTieuLuan.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaptopTieuLuan.Controllers
{
    public class UserController : Controller
    {
        private readonly LaptopContext _laptopContext;

        public UserController(LaptopContext laptopContext)
        {
            _laptopContext = laptopContext;
        }

        public IActionResult Index()
        {
            List<User> users = _laptopContext.Users.ToList();
            return View(users);
        }

        public IActionResult Delete(int id)
        {
            User user = _laptopContext.Users.Where(u => u.UserId == id).First();

            if (user == null)
            {
                return NotFound();
            }

            _laptopContext.Users.Remove(user);
            _laptopContext.SaveChanges();

            return RedirectToAction("Index", "User");
        }
    }
}
