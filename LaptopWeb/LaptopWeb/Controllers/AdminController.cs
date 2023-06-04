using LaptopWeb.Data;
using LaptopWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaptopWeb.Controllers
{
    public class AdminController : Controller
    {
        private readonly LaptopContext _laptopContext;

        public AdminController(LaptopContext laptopContext)
        {
            _laptopContext = laptopContext;
        }

        public IActionResult Index()
        {
            string myData = ViewBag.AddLaptop as string;
            ViewBag.AddLaptop = myData;
            List<Laptop> laptops = _laptopContext.Laptops.Include(l => l.Trademark).ToList();
            return View(laptops);
        }

        public IActionResult Add()
        {
            return View(new Laptop());
        }

        [HttpPost]
        public IActionResult Add(Laptop laptop)
        {
            if (laptop != null)
            {
                laptop.price_real = Int32.Parse(laptop.price);
                laptop.cpu = laptop.cpu_compact + "-3.3 Ghz up 4.2Ghz 4MB";
                Trademark? trademark = _laptopContext.Trademarks.Find(laptop.TrademarkId);
                laptop.Trademark = trademark;
                laptop.card = "NVIDIA Quadro T1000 2GB GDDR5";
                laptop.ram = laptop.ram_compact + "2133MHz LPDDR3";
                laptop.screen = laptop.screen_compact + " HD+ ( 2560 x 1600 )";
            }
            else
            {
                ViewBag.AddLaptop = "Add laptop Failed";
                return View(new Laptop());
            }
            _laptopContext.Laptops.Add(laptop);
            _laptopContext.SaveChanges();

            ViewBag.AddLaptop = "Add laptop success";
            return RedirectToAction("Index", "Admin");
        }

        public IActionResult Edit(int id)
        {
            Laptop laptop = _laptopContext.Laptops.Include(l => l.Trademark).Where(e => e.LaptopId == id).First();
            return View(laptop);
        }

        [HttpPost]
        public IActionResult Edit(Laptop laptop)
        {
            if (laptop != null)
            {
                laptop.price_real = Int32.Parse(laptop.price);
                laptop.cpu = laptop.cpu_compact + "-3.3 Ghz up 4.2Ghz 4MB";
                Trademark? trademark = _laptopContext.Trademarks.Find(laptop.TrademarkId);
                laptop.Trademark = trademark;
                laptop.card = "NVIDIA Quadro T1000 2GB GDDR5";
                laptop.ram = laptop.ram_compact + "2133MHz LPDDR3";
                laptop.screen = laptop.screen_compact + " HD+ ( 2560 x 1600 )";

                _laptopContext.Update(laptop);
                _laptopContext.SaveChanges();
                return RedirectToAction("Index", "Admin");
            }
            Laptop laptop1 = _laptopContext.Laptops.Include(l => l.Trademark).Where(e => e.LaptopId == laptop.LaptopId).First();
            return View(laptop1);
        }

        public IActionResult Delete(int id)
        {
            var laptop = _laptopContext.Laptops.Find(id);

            if (laptop == null)
            {
                return NotFound();
            }

            _laptopContext.Laptops.Remove(laptop);
            _laptopContext.SaveChanges();

            return RedirectToAction("Index", "Admin");
        }
    }
}
