using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BrowserAdventures.Models;
using browsersqlserver.database.windows;

namespace BrowserAdventures
{
    public class AccessPointsController : Controller
    {
        private readonly BrowserAdventureContext _context;

        public AccessPointsController(BrowserAdventureContext context)             
        {
            _context = context;
        }

        // GET: AccessPoints
        public async Task<IActionResult> Index()
        {
            return View(await _context.AccessPoint.ToListAsync());
        }

        // GET: AccessPoints/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accessPoint = await _context.AccessPoint
                .FirstOrDefaultAsync(m => m.AccessPointID == id);
            if (accessPoint == null)
            {
                return NotFound();
            }

            return View(accessPoint);
        }

        // GET: AccessPoints/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AccessPoints/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccessPointID,From,To,Description")] AccessPoint accessPoint)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accessPoint);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(accessPoint);
        }

        // GET: AccessPoints/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accessPoint = await _context.AccessPoint.FindAsync(id);
            if (accessPoint == null)
            {
                return NotFound();
            }
            return View(accessPoint);
        }

        // POST: AccessPoints/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AccessPointID,From,To,Description")] AccessPoint accessPoint)
        {
            if (id != accessPoint.AccessPointID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accessPoint);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccessPointExists(accessPoint.AccessPointID))
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
            return View(accessPoint);
        }

        // GET: AccessPoints/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accessPoint = await _context.AccessPoint
                .FirstOrDefaultAsync(m => m.AccessPointID == id);
            if (accessPoint == null)
            {
                return NotFound();
            }

            return View(accessPoint);
        }

        // POST: AccessPoints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accessPoint = await _context.AccessPoint.FindAsync(id);
            _context.AccessPoint.Remove(accessPoint);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccessPointExists(int id)
        {
            return _context.AccessPoint.Any(e => e.AccessPointID == id);
        }
    }
}
