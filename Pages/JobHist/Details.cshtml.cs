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
    public class DetailsModel : PageModel
    {
        private readonly ziibdApp.Models.ModelContext _context;

        public DetailsModel(ziibdApp.Models.ModelContext context)
        {
            _context = context;
        }

        public JobHistory JobHistory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            JobHistory = await _context.JobHistory
                .Include(j => j.Department)
                .Include(j => j.Employee)
                .Include(j => j.Job).FirstOrDefaultAsync(m => m.EmployeeId == id);

            if (JobHistory == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
