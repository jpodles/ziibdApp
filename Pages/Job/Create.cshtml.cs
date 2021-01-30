using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ziibdApp.Models;

namespace ziibdApp.Pages.Job
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
            return Page();
        }

        [BindProperty]
        public Jobs Jobs { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Jobs.Add(Jobs);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
