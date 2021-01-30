using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ziibdApp.Models;

namespace ziibdApp.Pages.Job
{
    public class DeleteModel : PageModel
    {
        private readonly ziibdApp.Models.ModelContext _context;

        public DeleteModel(ziibdApp.Models.ModelContext context)
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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Jobs = await _context.Jobs.FindAsync(id);

            if (Jobs != null)
            {
                _context.Jobs.Remove(Jobs);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
