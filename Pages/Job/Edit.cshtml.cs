using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ziibdApp.Models;

namespace ziibdApp.Pages.Job
{
    public class EditModel : PageModel
    {
        private readonly ziibdApp.Models.ModelContext _context;

        public EditModel(ziibdApp.Models.ModelContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Jobs Jobs { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Jobs = await _context.Jobs.FirstOrDefaultAsync(m => m.JobId == id);

            if (Jobs == null)
            {
                return NotFound();
            }
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

            _context.Attach(Jobs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobsExists(Jobs.JobId))
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

        private bool JobsExists(string id)
        {
            return _context.Jobs.Any(e => e.JobId == id);
        }
    }
}
