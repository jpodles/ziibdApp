using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using ziibdApp.Models;

namespace ziibdApp.Pages.Location
{
    public class CreateModel : PageModel
    {
        private readonly ModelContext _context;

        public CreateModel(ModelContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountryId", "CountryId");
            return Page();
        }

        [BindProperty]
        public Locations Locations { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Locations.Add(Locations);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
