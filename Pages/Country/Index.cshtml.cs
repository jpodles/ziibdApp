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
    public class IndexModel : PageModel
    {
        private readonly ziibdApp.Models.ModelContext _context;

        public IndexModel(ziibdApp.Models.ModelContext context)
        {
            _context = context;
        }

        public IList<Countries> Countries { get;set; }

        public async Task OnGetAsync()
        {
            Countries = await _context.Countries
                .Include(c => c.Region).ToListAsync();
        }
    }
}
