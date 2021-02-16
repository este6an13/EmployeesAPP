using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeesApp.Data;
using EmployeesApp.Models;

namespace EmployeesApp.Controllers
{
    public class CompanyEmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompanyEmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CompanyEmployees
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CompanyEmployee.Include(c => c.Company).Include(c => c.Employee);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CompanyEmployees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyEmployee = await _context.CompanyEmployee
                .Include(c => c.Company)
                .Include(c => c.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (companyEmployee == null)
            {
                return NotFound();
            }

            return View(companyEmployee);
        }

        // GET: CompanyEmployees/Create
        public IActionResult Create()
        {
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "Id");
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Id");
            return View();
        }

        // POST: CompanyEmployees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeId,CompanyId,JobTitle")] CompanyEmployee companyEmployee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(companyEmployee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "Id", companyEmployee.CompanyId);
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Id", companyEmployee.EmployeeId);
            return View(companyEmployee);
        }

        // GET: CompanyEmployees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyEmployee = await _context.CompanyEmployee.FindAsync(id);
            if (companyEmployee == null)
            {
                return NotFound();
            }
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "Id", companyEmployee.CompanyId);
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Id", companyEmployee.EmployeeId);
            return View(companyEmployee);
        }

        // POST: CompanyEmployees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,CompanyId,JobTitle")] CompanyEmployee companyEmployee)
        {
            if (id != companyEmployee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(companyEmployee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyEmployeeExists(companyEmployee.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "Id", companyEmployee.CompanyId);
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Id", companyEmployee.EmployeeId);
            return View(companyEmployee);
        }

        // GET: CompanyEmployees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyEmployee = await _context.CompanyEmployee
                .Include(c => c.Company)
                .Include(c => c.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (companyEmployee == null)
            {
                return NotFound();
            }

            return View(companyEmployee);
        }

        // POST: CompanyEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var companyEmployee = await _context.CompanyEmployee.FindAsync(id);
            _context.CompanyEmployee.Remove(companyEmployee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyEmployeeExists(int id)
        {
            return _context.CompanyEmployee.Any(e => e.Id == id);
        }
    }
}
