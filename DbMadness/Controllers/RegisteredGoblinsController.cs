using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DbMadness.Models;

namespace DbMadness.Controllers
{
    public class RegisteredGoblinsController : Controller
    {
        private readonly SpellBookContext _context;

        public RegisteredGoblinsController(SpellBookContext context)
        {
            _context = context;
        }

        // GET: RegisteredGoblins
        public async Task<IActionResult> Index()
        {
              return _context.RegisteredGoblins != null ? 
                          View(await _context.RegisteredGoblins.ToListAsync()) :
                          Problem("Entity set 'SpellBookContext.RegisteredGoblins'  is null.");
        }

        // GET: RegisteredGoblins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RegisteredGoblins == null)
            {
                return NotFound();
            }

            var registeredGoblin = await _context.RegisteredGoblins
                .FirstOrDefaultAsync(m => m.GoblinId == id);
            if (registeredGoblin == null)
            {
                return NotFound();
            }

            return View(registeredGoblin);
        }

        // GET: RegisteredGoblins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RegisteredGoblins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GoblinId,FirstName,LastName,FavIcecreamFlavor,Liar")] RegisteredGoblin registeredGoblin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registeredGoblin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(registeredGoblin);
        }

        // GET: RegisteredGoblins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RegisteredGoblins == null)
            {
                return NotFound();
            }

            var registeredGoblin = await _context.RegisteredGoblins.FindAsync(id);
            if (registeredGoblin == null)
            {
                return NotFound();
            }
            return View(registeredGoblin);
        }

        // POST: RegisteredGoblins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GoblinId,FirstName,LastName,FavIcecreamFlavor,Liar")] RegisteredGoblin registeredGoblin)
        {
            if (id != registeredGoblin.GoblinId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registeredGoblin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegisteredGoblinExists(registeredGoblin.GoblinId))
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
            return View(registeredGoblin);
        }

        // GET: RegisteredGoblins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RegisteredGoblins == null)
            {
                return NotFound();
            }

            var registeredGoblin = await _context.RegisteredGoblins
                .FirstOrDefaultAsync(m => m.GoblinId == id);
            if (registeredGoblin == null)
            {
                return NotFound();
            }

            return View(registeredGoblin);
        }

        // POST: RegisteredGoblins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RegisteredGoblins == null)
            {
                return Problem("Entity set 'SpellBookContext.RegisteredGoblins'  is null.");
            }
            var registeredGoblin = await _context.RegisteredGoblins.FindAsync(id);
            if (registeredGoblin != null)
            {
                _context.RegisteredGoblins.Remove(registeredGoblin);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegisteredGoblinExists(int id)
        {
          return (_context.RegisteredGoblins?.Any(e => e.GoblinId == id)).GetValueOrDefault();
        }
    }
}
