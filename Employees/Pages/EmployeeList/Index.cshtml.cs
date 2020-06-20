using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employees.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Employees.Pages.EmployeeList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Employee> Employees { get; set; }
        public async Task OnGet()
        {
            Employees = await _db.Employee.ToListAsync();

        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var Employee = await _db.Employee.FindAsync(id);
            if (Employee== null)
            {
                return NotFound();
            }
            _db.Employee.Remove(Employee);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}