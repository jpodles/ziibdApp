using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ziibdApp.Models;

namespace ziibdApp.Pages.Location
{
    public class DeleteModel : PageModel
    {
        private readonly ziibdApp.Models.ModelContext _context;

        public DeleteModel(ziibdApp.Models.ModelContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Locations Locations { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Locations = await _context.Locations
                .Include(l => l.Country).FirstOrDefaultAsync(m => m.LocationId == id);

            if (Locations == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Locations = await _context.Locations.FindAsync(id);

            if (Locations != null)
            {
                _context.Locations.Remove(Locations);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
