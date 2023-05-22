using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Movies.Data;
using Movies.Models;

namespace Movies.Pages.MovieNamePage
{
    public class EditModel : PageModel
    {
        private readonly Movies.Data.MoviesContext _context;

        public EditModel(Movies.Data.MoviesContext context)
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

            var moviename =  await _context.MovieName.FirstOrDefaultAsync(m => m.Id == id);
            if (moviename == null)
            {
                return NotFound();
            }
            MovieName = moviename;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MovieName).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                if (!MovieNameExists(MovieName.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MovieNameExists(int id)
        {
          return (_context.MovieName?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
