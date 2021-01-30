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
    public class DetailsModel : PageModel
    {
        private readonly ziibdApp.Models.ModelContext _context;

        public DetailsModel(ziibdApp.Models.ModelContext context)
        {
            _context = context;
        }

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
    }
}
