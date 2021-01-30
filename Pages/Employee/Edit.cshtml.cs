using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using ziibdApp.Models;

namespace ziibdApp.Pages.Employee
{
    public class EditModel : PageModel
    {
        private readonly ModelContext _context;

        public EditModel(ModelContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Employees Employees { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Employees = await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Job)
                .Include(e => e.Manager).FirstOrDefaultAsync(m => m.EmployeeId == id);

            if (Employees == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");
            ViewData["JobId"] = new SelectList(_context.Jobs, "JobId", "JobId");
            ViewData["ManagerId"] = new SelectList(_context.Employees, "EmployeeId", "Email");
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


            

            _context.Attach(Employees).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeesExists(Employees.EmployeeId))
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

        private bool EmployeesExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }
    }
}
