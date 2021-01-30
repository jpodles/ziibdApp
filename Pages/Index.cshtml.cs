using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using ziibdApp.Models;
namespace ziibdApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ModelContext _context;

        public int CountriesCount { get; set; }
        public int DepartmentCount { get; set; }
        public int EmployeesCount { get; set; }
        public int JobsCount { get; set; }
        public int LocationsCount { get; set; }
        public int RegionsCount { get; set; }

        public IndexModel(ModelContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            CountriesCount = _context.Countries.Count();
            DepartmentCount = _context.Departments.Count();
            EmployeesCount = _context.Employees.Count();
            JobsCount = _context.Jobs.Count();
            LocationsCount = _context.Locations.Count();
            RegionsCount = _context.Regions.Count();
        }
    }
}
