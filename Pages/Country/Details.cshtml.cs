using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ziibdApp.Models;

namespace ziibdApp.Pages.Country
{
    public class DetailsModel : PageModel
    {
        private readonly ziibdApp.Models.ModelContext _context;

        public DetailsModel(ziibdApp.Models.ModelContext context)
        {
            _context = context;
        }

        public Countries Countries { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Countries = await _context.Countries
                .Include(c => c.Region).FirstOrDefaultAsync(m => m.CountryId == id);

            if (Countries == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
