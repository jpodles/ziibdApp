using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ziibdApp.Models;

namespace ziibdApp.Pages.Region
{
    public class IndexModel : PageModel
    {
        private readonly ModelContext _context;

        public IndexModel(ModelContext context)
        {
            _context = context;
        }

        public IList<Regions> Regions { get; set; }

        public async Task OnGetAsync()
        {
            Regions = await _context.Regions.ToListAsync();
        }
    }
}
