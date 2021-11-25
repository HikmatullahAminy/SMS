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
    public class AddmissionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AddmissionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Addmissions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Addmissions.Include(a => a.Course).Include(a => a.Employees).Include(a => a.Student);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Addmissions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addmission = await _context.Addmissions
                .Include(a => a.Course)
                .Include(a => a.Employees)
                .Include(a => a.Student)
                .FirstOrDefaultAsync(m => m.AddmissionId == id);
            if (addmission == null)
            {
                return NotFound();
            }

            return View(addmission);
        }

        // GET: Addmissions/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "courseId", "CourseName");
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeName");
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentName");
            return View();
        }

        // POST: Addmissions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AddmissionId,StudentId,Fees,CourseId,EmployeeId,Date,Time")] Addmission addmission)
        {
            if (ModelState.IsValid)
            {
                _context.Add(addmission);

                var b = _context.Bankes.FirstOrDefault(a => a.BankeId == 1);
                b.AmountExist += addmission.Fees;


                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "courseId", "CourseName", addmission.CourseId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeName", addmission.EmployeeId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentName", addmission.StudentId);
            return View(addmission);
        }

        // GET: Addmissions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addmission = await _context.Addmissions.FindAsync(id);
            if (addmission == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "courseId", "CourseName", addmission.CourseId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeName", addmission.EmployeeId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentName", addmission.StudentId);
            return View(addmission);
        }

        // POST: Addmissions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AddmissionId,StudentId,Fees,CourseId,EmployeeId,Date,Time")] Addmission addmission)
        {
            if (id != addmission.AddmissionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(addmission);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddmissionExists(addmission.AddmissionId))
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
            ViewData["CourseId"] = new SelectList(_context.Courses, "courseId", "CourseName", addmission.CourseId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeName", addmission.EmployeeId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentName", addmission.StudentId);
            return View(addmission);
        }

        // GET: Addmissions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addmission = await _context.Addmissions
                .Include(a => a.Course)
                .Include(a => a.Employees)
                .Include(a => a.Student)
                .FirstOrDefaultAsync(m => m.AddmissionId == id);
            if (addmission == null)
            {
                return NotFound();
            }

            return View(addmission);
        }

        // POST: Addmissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var addmission = await _context.Addmissions.FindAsync(id);
            _context.Addmissions.Remove(addmission);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddmissionExists(int id)
        {
            return _context.Addmissions.Any(e => e.AddmissionId == id);
        }
    }
}
