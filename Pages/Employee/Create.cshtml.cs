using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using ziibdApp.Models;

namespace ziibdApp.Pages.Employee
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
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");
            ViewData["JobId"] = new SelectList(_context.Jobs, "JobId", "JobId");
            ViewData["ManagerId"] = new SelectList(_context.Employees, "EmployeeId", "Email");
            return Page();
        }

        [BindProperty]
        public Employees Employees { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Employees.Add(Employees);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
