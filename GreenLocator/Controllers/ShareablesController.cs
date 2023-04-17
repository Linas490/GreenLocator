using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GreenLocator.Data;
using GreenLocator.Models;

namespace GreenLocator.Controllers
{
    public class ShareablesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShareablesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Shareables
        public async Task<IActionResult> Index()
        {
              return _context.Shareable != null ? 
                          View(await _context.Shareable.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Shareable'  is null.");
        }

        // GET: Shareables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Shareable == null)
            {
                return NotFound();
            }

            var shareable = await _context.Shareable
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shareable == null)
            {
                return NotFound();
            }

            return View(shareable);
        }

        // GET: Shareables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Shareables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CategoryId,UserId,Describtion,Rating")] Shareable shareable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shareable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shareable);
        }

        // GET: Shareables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Shareable == null)
            {
                return NotFound();
            }

            var shareable = await _context.Shareable.FindAsync(id);
            if (shareable == null)
            {
                return NotFound();
            }
            return View(shareable);
        }

        // POST: Shareables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CategoryId,UserId,Describtion,Rating")] Shareable shareable)
        {
            if (id != shareable.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shareable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShareableExists(shareable.Id))
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
            return View(shareable);
        }

        // GET: Shareables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Shareable == null)
            {
                return NotFound();
            }

            var shareable = await _context.Shareable
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shareable == null)
            {
                return NotFound();
            }

            return View(shareable);
        }

        // POST: Shareables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Shareable == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Shareable'  is null.");
            }
            var shareable = await _context.Shareable.FindAsync(id);
            if (shareable != null)
            {
                _context.Shareable.Remove(shareable);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShareableExists(int id)
        {
          return (_context.Shareable?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
