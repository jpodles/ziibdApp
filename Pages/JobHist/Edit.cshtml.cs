using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ziibdApp.Models;

namespace ziibdApp.Pages.JobHist
{
    public class EditModel : PageModel
    {
        private readonly ziibdApp.Models.ModelContext _context;

        public EditModel(ziibdApp.Models.ModelContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");
           ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Email");
           ViewData["JobId"] = new SelectList(_context.Jobs, "JobId", "JobId");
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

            _context.Attach(JobHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobHistoryExists(JobHistory.EmployeeId))
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

        private bool JobHistoryExists(int id)
        {
            return _context.JobHistory.Any(e => e.EmployeeId == id);
        }
    }
}
