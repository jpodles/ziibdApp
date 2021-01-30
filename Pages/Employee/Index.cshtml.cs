using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ziibdApp.Models;

namespace ziibdApp.Pages.Employee
{
    public class IndexModel : PageModel
    {
        private readonly ModelContext _context;

        public IndexModel(ModelContext context)
        {
            _context = context;
        }

        public IList<Employees> Employees { get; set; }

        public async Task OnGetAsync()
        {
            Employees = await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Job)
                .Include(e => e.Manager).ToListAsync();
        }
    }
}
