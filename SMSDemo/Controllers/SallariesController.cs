using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SMSDemo.Data;
using SMSDemo.Models;

namespace SMSDemo.Controllers
{
    public class SallariesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SallariesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sallaries
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Sallaries.Include(s => s.Employee);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Sallaries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sallary = await _context.Sallaries
                .Include(s => s.Employee)
                .FirstOrDefaultAsync(m => m.SallaryId == id);
            if (sallary == null)
            {
                return NotFound();
            }

            return View(sallary);
        }

        // GET: Sallaries/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeName");
            return View();
        }

        // POST: Sallaries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SallaryId,EmployeeSallary,Date,EmployeeId")] Sallary sallary)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sallary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeName", sallary.EmployeeId);
            return View(sallary);
        }

        // GET: Sallaries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sallary = await _context.Sallaries.FindAsync(id);
            if (sallary == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeName", sallary.EmployeeId);
            return View(sallary);
        }

        // POST: Sallaries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SallaryId,EmployeeSallary,Date,EmployeeId")] Sallary sallary)
        {
            if (id != sallary.SallaryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sallary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SallaryExists(sallary.SallaryId))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeName", sallary.EmployeeId);
            return View(sallary);
        }

        // GET: Sallaries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sallary = await _context.Sallaries
                .Include(s => s.Employee)
                .FirstOrDefaultAsync(m => m.SallaryId == id);
            if (sallary == null)
            {
                return NotFound();
            }

            return View(sallary);
        }

        // POST: Sallaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sallary = await _context.Sallaries.FindAsync(id);
            _context.Sallaries.Remove(sallary);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SallaryExists(int id)
        {
            return _context.Sallaries.Any(e => e.SallaryId == id);
        }
    }
}
