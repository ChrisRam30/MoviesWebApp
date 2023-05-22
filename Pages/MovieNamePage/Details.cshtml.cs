using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Movies.Data;
using Movies.Models;

namespace Movies.Pages.MovieNamePage
{
    public class DetailsModel : PageModel
    {
        private readonly Movies.Data.MoviesContext _context;

        public DetailsModel(Movies.Data.MoviesContext context)
        {
            _context = context;
        }

      public MovieName MovieName { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (id == null || _context.MovieName == null)
            {
                return NotFound();
            }

            var moviename = await _context.MovieName.FirstOrDefaultAsync(m => m.Id == id);
            if (moviename == null)
            {
                return NotFound();
            }
            else 
            {
                MovieName = moviename;
            }
            return Page();
        }
    }
}
