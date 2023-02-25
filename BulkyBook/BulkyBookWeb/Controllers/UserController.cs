using BulkyBookWeb.Database;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;

        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Users> objCategoryList = _db.Users.ToList();
            //IEnumerable<Category> objCategoryList = (IEnumerable<Category>)_db.Users;
            return View(objCategoryList);
        }
    }
}
