using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _191_MOMENT_3.Data;
using _191_MOMENT_3.Models;

namespace _191_MOMENT_3.Controllers
{
    public class MainLibraryController : Controller
    {
        private readonly LibraryContext _context;

        public MainLibraryController(LibraryContext context)
        {
            _context = context;
        }

        // GET: MainLibrary
        public async Task<IActionResult> Index()
        {
              return View(await _context.mainLibrary.ToListAsync());
        }

        // GET: MainLibrary/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.mainLibrary == null)
            {
                return NotFound();
            }

            var libraryModel = await _context.mainLibrary
                .FirstOrDefaultAsync(m => m.Id == id);
            if (libraryModel == null)
            {
                return NotFound();
            }

            return View(libraryModel);
        }

        // GET: MainLibrary/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MainLibrary/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Artist,Album,Year,Minutes,PostedDate")] LibraryModel libraryModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(libraryModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(libraryModel);
        }

        // GET: MainLibrary/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.mainLibrary == null)
            {
                return NotFound();
            }

            var libraryModel = await _context.mainLibrary.FindAsync(id);
            if (libraryModel == null)
            {
                return NotFound();
            }
            return View(libraryModel);
        }

        // POST: MainLibrary/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Artist,Album,Year,Minutes,PostedDate")] LibraryModel libraryModel)
        {
            if (id != libraryModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libraryModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibraryModelExists(libraryModel.Id))
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
            return View(libraryModel);
        }

        // GET: MainLibrary/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.mainLibrary == null)
            {
                return NotFound();
            }

            var libraryModel = await _context.mainLibrary
                .FirstOrDefaultAsync(m => m.Id == id);
            if (libraryModel == null)
            {
                return NotFound();
            }

            return View(libraryModel);
        }

        // POST: MainLibrary/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.mainLibrary == null)
            {
                return Problem("Entity set 'LibraryContext.mainLibrary'  is null.");
            }
            var libraryModel = await _context.mainLibrary.FindAsync(id);
            if (libraryModel != null)
            {
                _context.mainLibrary.Remove(libraryModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibraryModelExists(int id)
        {
          return _context.mainLibrary.Any(e => e.Id == id);
        }
    }
}
