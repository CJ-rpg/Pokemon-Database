using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pokemon.BL.Logic;
using Pokemon.UI.Data;

namespace Pokemon.UI.Controllers
{
    public class AbilitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AbilitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Abilities
        public async Task<IActionResult> Index()
        {
            var abilities = _context.Ability.ToList();
            return View(abilities);
        }

        // GET: Abilities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ability == null)
            {
                return NotFound();
            }

            var ability = await _context.Ability
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ability == null)
            {
                return NotFound();
            }

            return View(ability);
        }

        // GET: Abilities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Abilities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] Ability ability)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ability);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ability);
        }

        // GET: Abilities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ability == null)
            {
                return NotFound();
            }

            var ability = await _context.Ability.FindAsync(id);
            if (ability == null)
            {
                return NotFound();
            }
            return View(ability);
        }

        // POST: Abilities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] Ability ability)
        {
            if (id != ability.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ability);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AbilityExists(ability.Id))
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
            return View(ability);
        }

        // GET: Abilities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ability == null)
            {
                return NotFound();
            }

            var ability = await _context.Ability
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ability == null)
            {
                return NotFound();
            }

            return View(ability);
        }

        // POST: Abilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ability == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Ability'  is null.");
            }
            var ability = await _context.Ability.FindAsync(id);
            if (ability != null)
            {
                _context.Ability.Remove(ability);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AbilityExists(int id)
        {
          return (_context.Ability?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
