using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using LaptopWeb.Models;
using LaptopWeb.Data;
using System.Linq;

namespace LaptopWeb.Controllers
{
    public class AuthController : Controller
    {

        private readonly LaptopContext _laptopContext;

        public AuthController(LaptopContext laptopContext)
        {
            _laptopContext = laptopContext;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User model)
        {
            if (IsValidUser(model.Email, model.Password))
            {
                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, model.Email)
                    };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                //var authenticationProperties = new AuthenticationProperties
                //{
                //  IsPersistent = model.RememberMe
                //};

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), authenticationProperties);
                return RedirectToAction("Index", "Admin");
            }

            ModelState.AddModelError("", "Invalid username or password.");

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Main");
        }

        private bool IsValidUser(string email, string password)
        {
            // Replace this with your actual user validation logic
            var validUsers = _laptopContext.Users.Where(e => e.Email == email).First();

            return validUsers.Password == password;
        }

    }
}
