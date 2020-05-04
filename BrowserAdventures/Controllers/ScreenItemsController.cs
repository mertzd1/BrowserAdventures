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
    public class ScreenItemsController : Controller
    {
        private readonly BrowserAdventureContext _context;

        public ScreenItemsController(BrowserAdventureContext context)
        {
            _context = context;
        }

        // GET: ScreenItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.ScreenItem.ToListAsync());
        }

        // GET: ScreenItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var screenItem = await _context.ScreenItem
                .FirstOrDefaultAsync(m => m.ScreenItemID == id);
            if (screenItem == null)
            {
                return NotFound();
            }

            return View(screenItem);
        }

        // GET: ScreenItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ScreenItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ScreenItemID,ScreenID,ScreenItemDescription,ScreenItemTakenDescription,ScreenItemAction")] ScreenItem screenItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(screenItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(screenItem);
        }

        // GET: ScreenItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var screenItem = await _context.ScreenItem.FindAsync(id);
            if (screenItem == null)
            {
                return NotFound();
            }
            return View(screenItem);
        }

        // POST: ScreenItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ScreenItemID,ScreenID,ScreenItemDescription,ScreenItemTakenDescription,ScreenItemAction")] ScreenItem screenItem)
        {
            if (id != screenItem.ScreenItemID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(screenItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScreenItemExists(screenItem.ScreenItemID))
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
            return View(screenItem);
        }

        // GET: ScreenItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var screenItem = await _context.ScreenItem
                .FirstOrDefaultAsync(m => m.ScreenItemID == id);
            if (screenItem == null)
            {
                return NotFound();
            }

            return View(screenItem);
        }

        // POST: ScreenItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var screenItem = await _context.ScreenItem.FindAsync(id);
            _context.ScreenItem.Remove(screenItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScreenItemExists(int id)
        {
            return _context.ScreenItem.Any(e => e.ScreenItemID == id);
        }
    }
}
