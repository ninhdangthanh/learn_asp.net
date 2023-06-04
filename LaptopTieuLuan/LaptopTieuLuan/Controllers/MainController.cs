using LaptopTieuLuan.Data;
using LaptopTieuLuan.Models;
using LaptopTieuLuan.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LaptopTieuLuan.Controllers
{
    public class MainController : Controller
    {
        private readonly LaptopContext _laptopContext;

        public MainController(LaptopContext laptopContext)
        {
            _laptopContext = laptopContext;
        }

        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.listLaptopDell = _laptopContext.Laptops.Include(c => c.Trademark).Where(d => d.Trademark.TrademarkName == "Dell").Take(3).ToList();
            model.listLaptopAcer = _laptopContext.Laptops.Include(c => c.Trademark).Where(d => d.Trademark.TrademarkName == "Acer").Take(3).ToList();
            model.listLaptopAsus = _laptopContext.Laptops.Include(c => c.Trademark).Where(d => d.Trademark.TrademarkName == "Asus").Take(3).ToList();
            
            return View(model);
        }

        public IActionResult Details(int id)
        {
            Laptop laptop = _laptopContext.Laptops.Include(c => c.Trademark).Where(d => d.LaptopId == id).FirstOrDefault();
            return View(laptop);
        }

        [HttpPost]
        public IActionResult Search(String searchValue)
        {
            ViewData["searchValue"] = searchValue;
            List<Laptop> laptops = _laptopContext.Laptops.Include(e => e.Trademark).Where(l => l.name.Contains(searchValue)).ToList();
            return View(laptops);
        }

        public IActionResult All()
        {
            List<Laptop> laptops = _laptopContext.Laptops.Include(e => e.Trademark).ToList();
            return View(laptops);
        }

        [HttpPost]
        public IActionResult All(String laptop, String screen, String cpu, String ram, String memory, String price)
        {
            List<Laptop> laptops = _laptopContext.Laptops.Include(e => e.Trademark).ToList();
            if(laptop != "novalue")
            {
                laptops = laptops.Where(l => l.Trademark.TrademarkName == laptop).ToList();
            }
            if (screen != "novalue")
            {
                laptops = laptops.Where(l => l.screen.Contains(screen)).ToList();
            }
            if (cpu != "novalue")
            {
                laptops = laptops.Where(l => l.cpu.Contains(cpu)).ToList();
            }
            if (ram != "novalue")
            {
                laptops = laptops.Where(l => l.ram.Contains(ram)).ToList();
            }
            if (memory != "novalue")
            {
                laptops = laptops.Where(l => l.memory_compact.Contains(memory)).ToList();
            }

            
            if (price == "asc")
            {
                laptops = laptops.OrderBy(l => l.price_real).ToList();
            } else if(price == "desc")
            {
                laptops = laptops.OrderByDescending(l => l.price_real).ToList();
            } 
            
            return View(laptops);
        }


        public IActionResult LaptopDell(String series)
        {
            List<Laptop> laptops = _laptopContext.Laptops.Include(l => l.Trademark).Where(l => l.Trademark.TrademarkName == "Dell").ToList();

            HashSet<string> fieldValues = new HashSet<string>();

            var query = from entity in _laptopContext.Laptops
                        where entity.Trademark.TrademarkName == "Dell"
                        select entity.series;

            fieldValues = new HashSet<string>(query);
            ViewBag.FieldValues = fieldValues;

            if (series == null)
            {
                return View(laptops);
            }
            laptops = laptops.Where(l => l.series == series).ToList();
            ViewBag.Series = series;

            return View(laptops);
        }

        public IActionResult LaptopAsus(String series)
        {
            List<Laptop> laptops = _laptopContext.Laptops.Include(l => l.Trademark).Where(l => l.Trademark.TrademarkName == "Asus").ToList();

            HashSet<string> fieldValues = new HashSet<string>();

            var query = from entity in _laptopContext.Laptops
                        where entity.Trademark.TrademarkName == "Asus"
                        select entity.series;

            fieldValues = new HashSet<string>(query);
            ViewBag.FieldValues = fieldValues;

            if (series == null)
            {
                return View(laptops);
            }
            laptops = laptops.Where(l => l.series == series).ToList();
            ViewBag.Series = series;

            return View(laptops);
        }

        public IActionResult LaptopAcer(String series)
        {
            List<Laptop> laptops = _laptopContext.Laptops.Include(l => l.Trademark).Where(l => l.Trademark.TrademarkName == "Acer").ToList();

            HashSet<string> fieldValues = new HashSet<string>();

            var query = from entity in _laptopContext.Laptops
                        where entity.Trademark.TrademarkName == "Acer"
                        select entity.series;

            fieldValues = new HashSet<string>(query);
            ViewBag.FieldValues = fieldValues;

            if (series == null)
            {
                return View(laptops);
            }
            laptops = laptops.Where(l => l.series == series).ToList();
            ViewBag.Series = series;

            return View(laptops);
        }


    }
}
