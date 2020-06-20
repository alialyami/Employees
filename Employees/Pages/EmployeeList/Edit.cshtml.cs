using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;
using Employees.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Employees.Pages.EmployeeList
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]

        public Employee Employee { get; set; }

        public async void OnGet(int id)
        {
            Employee = await _db.Employee.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var EmployeeFromdb = await _db.Employee.FindAsync(Employee.Id);
                EmployeeFromdb.EmployeeFirstName = Employee.EmployeeFirstName;
                EmployeeFromdb.EmployeeLastName = Employee.EmployeeLastName;
                EmployeeFromdb.Employer = Employee.Employer;
                EmployeeFromdb.Salary = Employee.Salary;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");

            }
            return RedirectToPage();
        }
    }
}