using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GreenLocator.Data;
using GreenLocator.Models;
using GreenLocator.Logic;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace GreenLocator.Controllers
{
    public class ReportsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> DeleteAppliance(string id)
        {
            return RedirectToAction("Delete", "Appliances", new { id });
        }

        // GET: Reports
        public async Task<IActionResult> Index()
        {
            return _context.Report != null ? 
                          View(await _context.Report.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Report'  is null.");
        }

        // GET: Reports/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Report == null)
            {
                return NotFound();
            }

            var report = await _context.Report
                .FirstOrDefaultAsync(m => m.ReportId == id);
            if (report == null)
            {
                return NotFound();
            }

            return View(report);
        }

        // GET: Reports/Create
        public IActionResult Create(string applianceId)
        {
            Console.WriteLine(applianceId);
            return View(new Report { ApplianceId = applianceId});
        }

        // POST: Reports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReportComment,ReportCategory")] Report report)
        {
            report.ReportId = Guid.NewGuid().ToString();
            report.ReportStatus = ReportStatus.Unseen;
            report.ApplianceId = Reporter.id;
            Console.WriteLine("zonggaa: " + Reporter.id);
/*            Console.WriteLine("applianceId: " + applianceId);*/
            report.UserId = User.Identity.Name;
            if (true)
            {
                _context.Add(report);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Appliances");
            }
            return View(report);
        }

        // GET: Reports/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Report == null)
            {
                return NotFound();
            }

            var report = await _context.Report.FindAsync(id);
            if (report == null)
            {
                return NotFound();
            }
            return View(report);
        }

        // POST: Reports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ReportId,ApplianceId,UserId,ReportComment,ReportCategory")] Report report)
        {
            if (id != report.ReportId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(report);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReportExists(report.ReportId))
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
            return View(report);
        }

        // GET: Reports/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Report == null)
            {
                return NotFound();
            }

            var report = await _context.Report
                .FirstOrDefaultAsync(m => m.ReportId == id);
            if (report == null)
            {
                return NotFound();
            }

            return View(report);
        }

        // POST: Reports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Report == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Report'  is null.");
            }
            var report = await _context.Report.FindAsync(id);
            if (report != null)
            {
                _context.Report.Remove(report);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReportExists(string id)
        {
          return (_context.Report?.Any(e => e.ReportId == id)).GetValueOrDefault();
        }
    }
}
