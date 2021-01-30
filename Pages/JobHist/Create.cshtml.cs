using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ziibdApp.Models;

namespace ziibdApp.Pages.JobHist
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
        ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");
        ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Email");
        ViewData["JobId"] = new SelectList(_context.Jobs, "JobId", "JobId");
            return Page();
        }

        [BindProperty]
        public JobHistory JobHistory { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.JobHistory.Add(JobHistory);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
