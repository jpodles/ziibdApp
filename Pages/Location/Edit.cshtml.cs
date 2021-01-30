using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ziibdApp.Models;

namespace ziibdApp.Pages.Location
{
    public class EditModel : PageModel
    {
        private readonly ziibdApp.Models.ModelContext _context;

        public EditModel(ziibdApp.Models.ModelContext context)
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
           ViewData["CountryId"] = new SelectList(_context.Countries, "CountryId", "CountryId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Locations).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationsExists(Locations.LocationId))
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

        private bool LocationsExists(int id)
        {
            return _context.Locations.Any(e => e.LocationId == id);
        }
    }
}
