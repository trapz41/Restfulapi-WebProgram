using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HaberlerController : Controller
    {
        private readonly WebApplication2Context _context;

        public HaberlerController(WebApplication2Context context)
        {
            _context = context;
        }
     
        // GET: Haberler
        public async Task<IActionResult> Index()
        {
              return View(await _context.Haberler.ToListAsync());
        }

        // GET: Haberler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Haberler == null)
            {
                return NotFound();
            }

            var haberler = await _context.Haberler
                .FirstOrDefaultAsync(m => m.id == id);
            if (haberler == null)
            {
                return NotFound();
            }

            return View(haberler);
        }

        // GET: Haberler/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Haberler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,baslik,duyuru")] Haberler haberler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(haberler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(haberler);
        }

        // GET: Haberler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Haberler == null)
            {
                return NotFound();
            }

            var haberler = await _context.Haberler.FindAsync(id);
            if (haberler == null)
            {
                return NotFound();
            }
            return View(haberler);
        }

        // POST: Haberler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,baslik,duyuru")] Haberler haberler)
        {
            if (id != haberler.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(haberler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HaberlerExists(haberler.id))
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
            return View(haberler);
        }

        // GET: Haberler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Haberler == null)
            {
                return NotFound();
            }

            var haberler = await _context.Haberler
                .FirstOrDefaultAsync(m => m.id == id);
            if (haberler == null)
            {
                return NotFound();
            }

            return View(haberler);
        }

        // POST: Haberler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Haberler == null)
            {
                return Problem("Entity set 'WebApplication2Context.Haberler'  is null.");
            }
            var haberler = await _context.Haberler.FindAsync(id);
            if (haberler != null)
            {
                _context.Haberler.Remove(haberler);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HaberlerExists(int id)
        {
          return _context.Haberler.Any(e => e.id == id);
        }
    }
}
