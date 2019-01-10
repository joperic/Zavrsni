using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Zavrsni.Models;

namespace Zavrsni.Controllers
{
    public class KnjiznicacsController : Controller
    {
        private readonly ZavrsniContext _context;

        public KnjiznicacsController(ZavrsniContext context)
        {
            _context = context;
        }

        // GET: Knjiznicacs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Knjiznicacs.ToListAsync());
        }

        // GET: Knjiznicacs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var knjiznicacs = await _context.Knjiznicacs
                .FirstOrDefaultAsync(m => m.id == id);
            if (knjiznicacs == null)
            {
                return NotFound();
            }

            return View(knjiznicacs);
        }

        // GET: Knjiznicacs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Knjiznicacs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,NazivKnjige,Vrsta,Autor,GodinaIzadanja")] Knjiznicacs knjiznicacs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(knjiznicacs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(knjiznicacs);
        }

        // GET: Knjiznicacs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var knjiznicacs = await _context.Knjiznicacs.FindAsync(id);
            if (knjiznicacs == null)
            {
                return NotFound();
            }
            return View(knjiznicacs);
        }

        // POST: Knjiznicacs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,NazivKnjige,Vrsta,Autor,GodinaIzadanja")] Knjiznicacs knjiznicacs)
        {
            if (id != knjiznicacs.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(knjiznicacs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KnjiznicacsExists(knjiznicacs.id))
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
            return View(knjiznicacs);
        }

        // GET: Knjiznicacs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var knjiznicacs = await _context.Knjiznicacs
                .FirstOrDefaultAsync(m => m.id == id);
            if (knjiznicacs == null)
            {
                return NotFound();
            }

            return View(knjiznicacs);
        }

        // POST: Knjiznicacs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var knjiznicacs = await _context.Knjiznicacs.FindAsync(id);
            _context.Knjiznicacs.Remove(knjiznicacs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KnjiznicacsExists(int id)
        {
            return _context.Knjiznicacs.Any(e => e.id == id);
        }
    }
}
