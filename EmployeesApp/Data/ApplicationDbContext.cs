using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using EmployeesApp.Models;

namespace EmployeesApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<EmployeesApp.Models.Employee> Employee { get; set; }
        public DbSet<EmployeesApp.Models.Company> Company { get; set; }
        public DbSet<EmployeesApp.Models.CompanyEmployee> CompanyEmployee { get; set; }
    }
}
