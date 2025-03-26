using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InfraStractur.Data;
using Models.Model;
using Microsoft.AspNetCore.Authorization;

namespace Jahez.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ConnectDataBase _context;

        public CategoriesController(ConnectDataBase context)
        {
            _context = context;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            var connectDataBase = _context.categories.Include(c => c.departmint);
            return View(await connectDataBase.ToListAsync());
        }
        //[Authorize(Roles = "User")]
        [Authorize(Policy = "SuperMarketOwnerOrAdmin")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorie = await _context.categories
                .Include(c => c.departmint)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categorie == null)
            {
                return NotFound();
            }

            return View(categorie);
        }

        [Authorize(Policy = "SuperMarketOwnerOrAdmin")]
        public IActionResult Create()
        {
            ViewData["departmintId"] = new SelectList(_context.departmints, "Id", "Id");
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "SuperMarketOwnerOrAdmin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NameCategorie,Description,Price,Quantity,dateTime,departmintId,Id,IsActive")] Categorie categorie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categorie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["departmintId"] = new SelectList(_context.departmints, "Id", "Id", categorie.departmintId);
            return View(categorie);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorie = await _context.categories.FindAsync(id);
            if (categorie == null)
            {
                return NotFound();
            }
            ViewData["departmintId"] = new SelectList(_context.departmints, "Id", "Id", categorie.departmintId);
            return View(categorie);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NameCategorie,Description,Price,Quantity,dateTime,departmintId,Id,IsActive")] Categorie categorie)
        {
            if (id != categorie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categorie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategorieExists(categorie.Id))
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
            ViewData["departmintId"] = new SelectList(_context.departmints, "Id", "Id", categorie.departmintId);
            return View(categorie);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorie = await _context.categories
                .Include(c => c.departmint)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categorie == null)
            {
                return NotFound();
            }

            return View(categorie);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var categorie = await _context.categories.FindAsync(id);
            if (categorie != null)
            {
                _context.categories.Remove(categorie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategorieExists(string id)
        {
            return _context.categories.Any(e => e.Id == id);
        }
    }
}
