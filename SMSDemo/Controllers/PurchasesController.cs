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
    public class PurchasesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PurchasesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Purchases
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Purchases.Include(p => p.Course);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Purchases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase = await _context.Purchases
                .Include(p => p.Course)
                .FirstOrDefaultAsync(m => m.PurchaseId == id);
            if (purchase == null)
            {
                return NotFound();
            }

            return View(purchase);
        }

        // GET: Purchases/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "courseId", "CourseName");
            return View();
        }

        // POST: Purchases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PurchaseId,CourseId,Quantity,Price,Date")] Purchase purchase)
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
                if (purchase.CourseId == Engid)
                {
                    StoreEng.quantity += purchase.Quantity;
                }
                else if (purchase.CourseId == Comid)
                {
                    StoreCom.quantity += purchase.Quantity;
                }
                else if (purchase.CourseId == Mathid)
                {
                    StoreMath.quantity += purchase.Quantity;
                }
                else if (purchase.CourseId == Pelcid)
                {
                    StorePelc.quantity += purchase.Quantity;
                }
                else if (purchase.CourseId == Prepareid)
                {
                    StorePreparing.quantity += purchase.Quantity;
                }
                else
                {
                    RedirectToAction("Index");
                }

                var b = _context.Bankes.FirstOrDefault(a => a.BankeId == 1);
                b.AmountExist -= purchase.Price;


                _context.Add(purchase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "courseId", "CourseName", purchase.CourseId);
            return View(purchase);
        }

        // GET: Purchases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase = await _context.Purchases.FindAsync(id);
            if (purchase == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "courseId", "CoureseName", purchase.CourseId);
            return View(purchase);
        }

        // POST: Purchases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PurchaseId,CourseId,Quantity,Price,Date")] Purchase purchase)
        {
            if (id != purchase.PurchaseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaseExists(purchase.PurchaseId))
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
            ViewData["CourseId"] = new SelectList(_context.Courses, "courseId", "CourseName", purchase.CourseId);
            return View(purchase);
        }

        // GET: Purchases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase = await _context.Purchases
                .Include(p => p.Course)
                .FirstOrDefaultAsync(m => m.PurchaseId == id);
            if (purchase == null)
            {
                return NotFound();
            }

            return View(purchase);
        }

        // POST: Purchases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purchase = await _context.Purchases.FindAsync(id);
            _context.Purchases.Remove(purchase);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurchaseExists(int id)
        {
            return _context.Purchases.Any(e => e.PurchaseId == id);
        }
    }
}
