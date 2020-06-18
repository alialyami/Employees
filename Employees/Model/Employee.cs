using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Employees.Model
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public float Salary { get; set; }
        public string Employer { get; set; }
    }
}
