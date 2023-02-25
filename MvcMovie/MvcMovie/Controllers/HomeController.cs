using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;
using System.Diagnostics;

namespace MvcMovie.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Welcome(string name, int numTimes = 5)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }

    }
}