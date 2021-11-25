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
    public class SallesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SallesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Salles
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Salles.Include(s => s.Course);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Salles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salles = await _context.Salles
                .Include(s => s.Course)
                .FirstOrDefaultAsync(m => m.SallesId == id);
            if (salles == null)
            {
                return NotFound();
            }

            return View(salles);
        }

        // GET: Salles/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "courseId", "CourseName");
            return View();
        }

        // POST: Salles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SallesId,CourseId,Quantity,Price,Date")] Salles salles)
        {


            var subEng = await _context.Courses.FirstOrDefaultAsync(a => a.CourseName == "English");
            var subMath = await _context.Courses.FirstOrDefaultAsync(a => a.CourseName == "ریاضی");
            var subCom = await _context.Courses.FirstOrDefaultAsync(a => a.CourseName == "Computer");
            var subPelc = await _context.Courses.FirstOrDefaultAsync(a => a.CourseName == "PELC");
            var subPrepareing = await _context.Courses.FirstOrDefaultAsync(a => a.CourseName == "امادګی");

            var Engid = subEng.courseId;
            var Mathid = subMath.courseId;
            var Comid = subCom.courseId;
            var Pelcid = subPelc.courseId;
            var Prepareid = subPrepareing.courseId;



            var StoreEng = await _context.Stores.FirstOrDefaultAsync(a => a.courseId == Engid);
            var StoreMath = await _context.Stores.FirstOrDefaultAsync(a => a.courseId == Mathid);
            var StoreCom = await _context.Stores.FirstOrDefaultAsync(a => a.courseId == Comid);
            var StorePelc = await _context.Stores.FirstOrDefaultAsync(a => a.courseId == Pelcid);
            var StorePreparing = await _context.Stores.FirstOrDefaultAsync(a => a.courseId == Prepareid);






            if (ModelState.IsValid)
            {
                if (salles.CourseId == Engid)
                {
                    StoreEng.quantity -= salles.Quantity;
                }
                else if (salles.CourseId == Comid)
                {
                    StoreCom.quantity -= salles.Quantity;
                }
                else if (salles.CourseId == Mathid)
                {
                    StoreMath.quantity -= salles.Quantity;
                }
                else if (salles.CourseId == Prepareid)
                {
                    StorePreparing.quantity += salles.Quantity;
                }
                else if (salles.CourseId == Pelcid)
                {
                    StorePelc.quantity -= salles.Quantity;
                }
                else
                {
                    RedirectToAction("Index");
                }

              var b =  _context.Bankes.FirstOrDefault(a=>a.BankeId==1);
                b.AmountExist += salles.Price;

             

                _context.Add(salles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "courseId", "CourseName", salles.CourseId);
            return View(salles);
        }

        // GET: Salles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salles = await _context.Salles.FindAsync(id);
            if (salles == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "courseId", "CourseName", salles.CourseId);
            return View(salles);
        }

        // POST: Salles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SallesId,CourseId,Quantity,Price,Date")] Salles salles)
        {
            if (id != salles.SallesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SallesExists(salles.SallesId))
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
            ViewData["CourseId"] = new SelectList(_context.Courses, "courseId", "CourseName", salles.CourseId);
            return View(salles);
        }

        // GET: Salles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salles = await _context.Salles
                .Include(s => s.Course)
                .FirstOrDefaultAsync(m => m.SallesId == id);
            if (salles == null)
            {
                return NotFound();
            }

            return View(salles);
        }

        // POST: Salles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salles = await _context.Salles.FindAsync(id);
            _context.Salles.Remove(salles);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SallesExists(int id)
        {
            return _context.Salles.Any(e => e.SallesId == id);
        }
    }
}
