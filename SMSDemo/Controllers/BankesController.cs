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
    public class BankesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BankesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Bankes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bankes.ToListAsync());
        }

        // GET: Bankes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banke = await _context.Bankes
                .FirstOrDefaultAsync(m => m.BankeId == id);
            if (banke == null)
            {
                return NotFound();
            }

            return View(banke);
        }

        // GET: Bankes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bankes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BankeId,AmountExist")] Banke banke)
        {
            if (ModelState.IsValid)
            {
                _context.Add(banke);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(banke);
        }

        // GET: Bankes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banke = await _context.Bankes.FindAsync(id);
            if (banke == null)
            {
                return NotFound();
            }
            return View(banke);
        }

        // POST: Bankes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BankeId,AmountExist")] Banke banke)
        {
            if (id != banke.BankeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(banke);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BankeExists(banke.BankeId))
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
            return View(banke);
        }

        // GET: Bankes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banke = await _context.Bankes
                .FirstOrDefaultAsync(m => m.BankeId == id);
            if (banke == null)
            {
                return NotFound();
            }

            return View(banke);
        }

        // POST: Bankes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var banke = await _context.Bankes.FindAsync(id);
            _context.Bankes.Remove(banke);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BankeExists(int id)
        {
            return _context.Bankes.Any(e => e.BankeId == id);
        }
    }
}
