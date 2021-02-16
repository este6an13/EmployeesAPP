using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesApp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public string JobTitle { get; set; }
        public string Email { get; set; }

        public virtual ICollection<CompanyEmployee> Experiences { get; set; }

        public Employee()
        { 
        
        }
    }
}
