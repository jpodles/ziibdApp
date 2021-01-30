using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ziibdApp.Models;

namespace ziibdApp.Pages.JobHist
{
    public class IndexModel : PageModel
    {
        private readonly ziibdApp.Models.ModelContext _context;

        public IndexModel(ziibdApp.Models.ModelContext context)
        {
            _context = context;
        }

        public IList<JobHistory> JobHistory { get;set; }

        public async Task OnGetAsync()
        {
            JobHistory = await _context.JobHistory
                .Include(j => j.Department)
                .Include(j => j.Employee)
                .Include(j => j.Job).ToListAsync();
        }
    }
}
