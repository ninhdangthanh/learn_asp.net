using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie1.Data;
using RazorPagesMovie1.Models;

namespace RazorPagesMovie1.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesMovie1.Data.RazorPagesMovieContext _context;

        public DetailsModel(RazorPagesMovie1.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }

        public Movie Movie { get; set; }

        #region snippet1
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movie.FirstOrDefaultAsync(m => m.ID == id);

            if (Movie == null)
            {
                return NotFound();
            }
            return Page();
        }
        #endregion
    }
}