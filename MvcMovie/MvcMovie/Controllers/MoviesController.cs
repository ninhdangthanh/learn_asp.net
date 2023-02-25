using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string searchString, string movieGenre)
        {
            var movies = from m in _context.Movies
                         select m;

            IQueryable<string> genreQuery = from m in _context.Movies
                                            orderby m.Genre
                                            select m.Genre;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(x => x.Genre == movieGenre);
            }

            var movieGenreVM = new MovieGenreViewModel
            {
                Genres = new SelectList(genreQuery.Distinct().ToList()),
                Movies = movies.ToList()
            };

            ViewData["MyString"] = "Searching for : " + searchString;

            return View(movieGenreVM);
        }

        // GET: Movies/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = _context.Movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var movie = _context.Movies.Find(id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                _context.Update(movie);
                _context.SaveChanges();
                
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie =  _context.Movies
                .FirstOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var movie =  _context.Movies.Find(id);
            _context.Movies.Remove(movie);
            _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
