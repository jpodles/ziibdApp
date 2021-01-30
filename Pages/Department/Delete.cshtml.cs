using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ziibdApp.Models;

namespace ziibdApp.Pages.Department
{
    public class DeleteModel : PageModel
    {
        private readonly ziibdApp.Models.ModelContext _context;

        public DeleteModel(ziibdApp.Models.ModelContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Departments Departments { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Departments = await _context.Departments
                .Include(d => d.Location)
                .Include(d => d.Manager).FirstOrDefaultAsync(m => m.DepartmentId == id);

            if (Departments == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Departments = await _context.Departments.FindAsync(id);

            if (Departments != null)
            {
                _context.Departments.Remove(Departments);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
