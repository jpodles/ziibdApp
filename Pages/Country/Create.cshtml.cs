using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ziibdApp.Models;

namespace ziibdApp.Pages.Country
{
    public class CreateModel : PageModel
    {
        private readonly ziibdApp.Models.ModelContext _context;

        public CreateModel(ziibdApp.Models.ModelContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["RegionId"] = new SelectList(_context.Regions, "RegionId", "RegionId");
            return Page();
        }

        [BindProperty]
        public Countries Countries { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Countries.Add(Countries);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
