using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ziibdApp.Models;

namespace ziibdApp.Pages.Location
{
    public class IndexModel : PageModel
    {
        private readonly ModelContext _context;

        public IndexModel(ModelContext context)
        {
            _context = context;
        }

        public IList<Locations> Locations { get; set; }

        public async Task OnGetAsync()
        {
            Locations = await _context.Locations
                .Include(l => l.Country).ToListAsync();
        }
    }
}
