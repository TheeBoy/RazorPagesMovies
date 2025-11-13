using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;

namespace RazorPagesMovie.Models
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;

        public DeleteModel(RazorPagesMovie.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UpcomingMovie UpcomingMovie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var upcomingmovie = await _context.UpcomingMovie.FirstOrDefaultAsync(m => m.Id == id);

            if (upcomingmovie is not null)
            {
                UpcomingMovie = upcomingmovie;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var upcomingmovie = await _context.UpcomingMovie.FindAsync(id);
            if (upcomingmovie != null)
            {
                UpcomingMovie = upcomingmovie;
                _context.UpcomingMovie.Remove(UpcomingMovie);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
