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
    public class FavoritesController : Controller
    {
        private readonly SpellBookContext _context;

        public FavoritesController(SpellBookContext context)
        {
            _context = context;
        }

        // GET: Favorites
        public async Task<IActionResult> Index()
        {
            var spellBookContext = _context.Favorites.Include(f => f.AnimalNavigation).Include(f => f.ColorNavigation).Include(f => f.GoblinNavigation).Include(f => f.NumberNavigation);
            return View(await spellBookContext.ToListAsync());
        }

        // GET: Favorites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Favorites == null)
            {
                return NotFound();
            }

            var favorite = await _context.Favorites
                .Include(f => f.AnimalNavigation)
                .Include(f => f.ColorNavigation)
                .Include(f => f.GoblinNavigation)
                .Include(f => f.NumberNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (favorite == null)
            {
                return NotFound();
            }

            return View(favorite);
        }

        // GET: Favorites/Create
        public IActionResult Create()
        {
            ViewData["Animal"] = new SelectList(_context.FavoriteAnimals, "Id", "Value");
            ViewData["Color"] = new SelectList(_context.FavoriteColors, "Id", "Value");
            ViewData["Goblin"] = new SelectList(_context.RegisteredGoblins, "GoblinId", "FirstName");
            ViewData["Number"] = new SelectList(_context.FavoriteNumbers, "Id", "Value");
            return View();
        }

        // POST: Favorites/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Animal,Color,Number,Goblin")] Favorite favorite)
        {
            if (ModelState.IsValid)
            {
                _context.Add(favorite);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Animal"] = new SelectList(_context.FavoriteAnimals, "Id", "Value", favorite.Animal);
            ViewData["Color"] = new SelectList(_context.FavoriteColors, "Id", "Value", favorite.Color);
            ViewData["Goblin"] = new SelectList(_context.RegisteredGoblins, "GoblinId", "GoblinId", favorite.Goblin);
            ViewData["Number"] = new SelectList(_context.FavoriteNumbers, "Id", "Value", favorite.Number);
            return View(favorite);
        }

        // GET: Favorites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Favorites == null)
            {
                return NotFound();
            }

            var favorite = await _context.Favorites.FindAsync(id);
            if (favorite == null)
            {
                return NotFound();
            }
            ViewData["Animal"] = new SelectList(_context.FavoriteAnimals, "Id", "Value", favorite.Animal);
            ViewData["Color"] = new SelectList(_context.FavoriteColors, "Id", "Value", favorite.Color);
            ViewData["Goblin"] = new SelectList(_context.RegisteredGoblins, "GoblinId", "GoblinId", favorite.Goblin);
            ViewData["Number"] = new SelectList(_context.FavoriteNumbers, "Id", "Value", favorite.Number);
            return View(favorite);
        }

        // POST: Favorites/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Animal,Color,Number,Goblin")] Favorite favorite)
        {
            if (id != favorite.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(favorite);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FavoriteExists(favorite.Id))
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
            ViewData["Animal"] = new SelectList(_context.FavoriteAnimals, "Id", "Value", favorite.Animal);
            ViewData["Color"] = new SelectList(_context.FavoriteColors, "Id", "Value", favorite.Color);
            ViewData["Goblin"] = new SelectList(_context.RegisteredGoblins, "GoblinId", "GoblinId", favorite.Goblin);
            ViewData["Number"] = new SelectList(_context.FavoriteNumbers, "Id", "Value", favorite.Number);
            return View(favorite);
        }

        // GET: Favorites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Favorites == null)
            {
                return NotFound();
            }

            var favorite = await _context.Favorites
                .Include(f => f.AnimalNavigation)
                .Include(f => f.ColorNavigation)
                .Include(f => f.GoblinNavigation)
                .Include(f => f.NumberNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (favorite == null)
            {
                return NotFound();
            }

            return View(favorite);
        }

        // POST: Favorites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Favorites == null)
            {
                return Problem("Entity set 'SpellBookContext.Favorites'  is null.");
            }
            var favorite = await _context.Favorites.FindAsync(id);
            if (favorite != null)
            {
                _context.Favorites.Remove(favorite);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FavoriteExists(int id)
        {
          return (_context.Favorites?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
