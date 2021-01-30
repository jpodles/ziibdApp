using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ziibdApp.Models;

namespace ziibdApp.Pages.Region
{
    public class DetailsModel : PageModel
    {
        private readonly ziibdApp.Models.ModelContext _context;

        public DetailsModel(ziibdApp.Models.ModelContext context)
        {
            _context = context;
        }

        public Regions Regions { get; set; }

        public async Task<IActionResult> OnGetAsync(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Regions = await _context.Regions.FirstOrDefaultAsync(m => m.RegionId == id);

            if (Regions == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
