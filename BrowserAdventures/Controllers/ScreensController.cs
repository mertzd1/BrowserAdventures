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
    public class ScreensController : Controller
    {
        private readonly BrowserAdventureContext _context;

        public ScreensController(BrowserAdventureContext context)
        {
            _context = context;
        }

        // GET: Screens
        public async Task<IActionResult> Index()
        {
            return View(await _context.Screen.ToListAsync());
        }

        // GET: Screens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var screen = await _context.Screen
                .FirstOrDefaultAsync(m => m.ScreenID == id);
            if (screen == null)
            {
                return NotFound();
            }

            return View(screen);
        }

        // GET: Screens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Screens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ScreenID,ScreenName,ScreenDescription")] Screen screen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(screen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(screen);
        }

        // GET: Screens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var screen = await _context.Screen.FindAsync(id);
            if (screen == null)
            {
                return NotFound();
            }
            return View(screen);
        }

        // POST: Screens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ScreenID,ScreenName,ScreenDescription")] Screen screen)
        {
            if (id != screen.ScreenID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(screen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScreenExists(screen.ScreenID))
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
            return View(screen);
        }

        // GET: Screens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var screen = await _context.Screen
                .FirstOrDefaultAsync(m => m.ScreenID == id);
            if (screen == null)
            {
                return NotFound();
            }

            return View(screen);
        }

        // POST: Screens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var screen = await _context.Screen.FindAsync(id);
            _context.Screen.Remove(screen);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScreenExists(int id)
        {
            return _context.Screen.Any(e => e.ScreenID == id);
        }
    }
}
