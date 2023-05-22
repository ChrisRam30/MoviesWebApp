using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Movies.Data;
using Movies.Models;

namespace Movies.Pages.MovieNamePage
{
    public class CreateModel : PageModel
    {
        private readonly Movies.Data.MoviesContext _context;

        public CreateModel(Movies.Data.MoviesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MovieName MovieName { get; set; } = default!;
        

        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.MovieName == null || MovieName == null)
            {
                return Page();
            }

            _context.MovieName.Add(MovieName);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
