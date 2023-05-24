using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GreenLocator.Data;
using GreenLocator.Models;
using Microsoft.AspNetCore.Authorization;
using GreenLocator.Logic;

namespace GreenLocator.Controllers
{
    public class AppliancesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AppliancesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Appliances
        [Authorize]
        public async Task<IActionResult> Index()
        {
              return _context.Appliance != null ? 
                          View(await _context.Appliance.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Appliance'  is null.");
        }

        // GET: Appliances/Details/5
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null || _context.Appliance == null)
            {
                return NotFound();
            }

            var appliance = await _context.Appliance
                .FirstOrDefaultAsync(m => m.Id.Equals(id));
            if (appliance == null)
            {
                return NotFound();
            }

            return View(appliance);
        }

        // GET: Appliances/Create
/*        public IActionResult Create()
        {
            Console.WriteLine("Hello pipec");
            return View();
        }*/

        public IActionResult GoToReport(string id)
        {
            Console.WriteLine("mes ciiaaaa");
            Reporter.id = id;
            return RedirectToAction("Create", "Reports");
        }

        // POST: Appliances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Category,Description,Title,Price,ImgUrl")] Appliance appliance)
        {
            Console.WriteLine(appliance.Category.ToString());
            appliance.Id = Guid.NewGuid().ToString();
            appliance.ApplianceUserId = Guid.NewGuid().ToString();
            Console.WriteLine("ImgUrl: " + appliance.ImgUrl);
            Console.WriteLine("Title: " + appliance.Title);
            Console.WriteLine("Price: " + appliance.Price.ToString());
            if (true)
            {
                Console.WriteLine("IsValid");
                _context.Add(appliance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            Console.WriteLine("prie return");
            return View(appliance);
        }

        // GET: Appliances/Edit/5
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null || _context.Appliance == null)
            {
                return NotFound();
            }

            var appliance = await _context.Appliance.FindAsync(id);
            if (appliance == null)
            {
                return NotFound();
            }
            return View(appliance);
        }

        // POST: Appliances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Category, Title, Price, Description")] Appliance appliance)
        {
            if (!id.Equals(appliance.Id))
            {
                return NotFound();
            }

            if (true)
            {
                try
                {
                    _context.Update(appliance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplianceExists(appliance.Id))
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
            return View(appliance);
        }

        // GET: Appliances/Delete/5
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null || _context.Appliance == null)
            {
                return NotFound();
            }

            var appliance = await _context.Appliance
                .FirstOrDefaultAsync(m => m.Id.Equals(id));
            if (appliance == null)
            {
                return NotFound();
            }

            return View(appliance);
        }

        // POST: Appliances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Appliance == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Appliance'  is null.");
            }
            var appliance = await _context.Appliance.FindAsync(id);
            if (appliance != null)
            {
                _context.Appliance.Remove(appliance);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplianceExists(string id)
        {
          return (_context.Appliance?.Any(e => e.Id.Equals(id))).GetValueOrDefault();
        }
    }
}
