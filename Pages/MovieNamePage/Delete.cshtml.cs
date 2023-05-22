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
    public class DeleteModel : PageModel
    {
        private readonly Movies.Data.MoviesContext _context;

        public DeleteModel(Movies.Data.MoviesContext context)
        {
            _context = context;
        }

        [BindProperty]
      public MovieName MovieName { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.MovieName == null)
            {
                return NotFound();
            }
            var moviename = await _context.MovieName.FindAsync(id);

            if (moviename != null)
            {
                MovieName = moviename;
                _context.MovieName.Remove(MovieName);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
