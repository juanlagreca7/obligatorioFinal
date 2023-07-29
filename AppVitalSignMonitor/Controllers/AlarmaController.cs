using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppVitalSignMonitor;
using AppVitalSignMonitor.Models;

namespace AppVitalSignMonitor.Controllers
{
    public class AlarmaController : Controller
    {
        private readonly Context _context;

        public AlarmaController(Context context)
        {
            _context = context;
        }

        // GET: Alarma
        public async Task<IActionResult> Index()
        {
              return _context.Alarma != null ? 
                          View(await _context.Alarma.ToListAsync()) :
                          Problem("Entity set 'Context.Alarma'  is null.");
        }

        // GET: Alarma/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Alarma == null)
            {
                return NotFound();
            }

            var alarma = await _context.Alarma
                .FirstOrDefaultAsync(m => m.IdAlarma == id);
            if (alarma == null)
            {
                return NotFound();
            }

            return View(alarma);
        }

        // GET: Alarma/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Alarma/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAlarma,ValorComparativo,TipoAlarma,TipoComparacion,FechaCreacion")] Alarma alarma)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alarma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alarma);
        }

        // GET: Alarma/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Alarma == null)
            {
                return NotFound();
            }

            var alarma = await _context.Alarma.FindAsync(id);
            if (alarma == null)
            {
                return NotFound();
            }
            return View(alarma);
        }

        // POST: Alarma/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdAlarma,ValorComparativo,TipoAlarma,TipoComparacion,FechaCreacion")] Alarma alarma)
        {
            if (id != alarma.IdAlarma)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alarma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlarmaExists(alarma.IdAlarma))
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
            return View(alarma);
        }

        // GET: Alarma/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Alarma == null)
            {
                return NotFound();
            }

            var alarma = await _context.Alarma
                .FirstOrDefaultAsync(m => m.IdAlarma == id);
            if (alarma == null)
            {
                return NotFound();
            }

            return View(alarma);
        }

        // POST: Alarma/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Alarma == null)
            {
                return Problem("Entity set 'Context.Alarma'  is null.");
            }
            var alarma = await _context.Alarma.FindAsync(id);
            if (alarma != null)
            {
                _context.Alarma.Remove(alarma);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlarmaExists(string id)
        {
          return (_context.Alarma?.Any(e => e.IdAlarma == id)).GetValueOrDefault();
        }
    }
}
