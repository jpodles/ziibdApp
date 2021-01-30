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
    public class DeleteModel : PageModel
    {
        private readonly ziibdApp.Models.ModelContext _context;

        public DeleteModel(ziibdApp.Models.ModelContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Regions = await _context.Regions.FindAsync(id);

            if (Regions != null)
            {
                _context.Regions.Remove(Regions);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
