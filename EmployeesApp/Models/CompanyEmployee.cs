using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesApp.Models
{
    public class CompanyEmployee
    {
        [Key]
        public int Id { get; set; }

        
        [Column(Order = 0)]
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        [Column(Order = 1)]
        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public string JobTitle { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Company Company { get; set; }
    }

}
