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
    public class ReporteController : Controller
    {
        private readonly Context _context;

        public ReporteController(Context context)
        {
            _context = context;
        }

        // GET: Reporte
        public async Task<IActionResult> Index()
        {
              return _context.Reporte != null ? 
                          View(await _context.Reporte.ToListAsync()) :
                          Problem("Entity set 'Context.Reporte'  is null.");
        }

        // GET: Reporte/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Reporte == null)
            {
                return NotFound();
            }

            var reporte = await _context.Reporte
                .FirstOrDefaultAsync(m => m.IdDispositivo == id);
            if (reporte == null)
            {
                return NotFound();
            }

            return View(reporte);
        }

        // GET: Reporte/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reporte/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDispositivo,PresionDiastolica,PresionSistolica,SaturacionOxigeno,Temperatura,Pulso,HoraFecha")] Reporte reporte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reporte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reporte);
        }

        // GET: Reporte/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Reporte == null)
            {
                return NotFound();
            }

            var reporte = await _context.Reporte.FindAsync(id);
            if (reporte == null)
            {
                return NotFound();
            }
            return View(reporte);
        }

        // POST: Reporte/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdDispositivo,PresionDiastolica,PresionSistolica,SaturacionOxigeno,Temperatura,Pulso,HoraFecha")] Reporte reporte)
        {
            if (id != reporte.IdDispositivo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reporte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReporteExists(reporte.IdDispositivo))
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
            return View(reporte);
        }

        // GET: Reporte/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Reporte == null)
            {
                return NotFound();
            }

            var reporte = await _context.Reporte
                .FirstOrDefaultAsync(m => m.IdDispositivo == id);
            if (reporte == null)
            {
                return NotFound();
            }

            return View(reporte);
        }

        // POST: Reporte/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Reporte == null)
            {
                return Problem("Entity set 'Context.Reporte'  is null.");
            }
            var reporte = await _context.Reporte.FindAsync(id);
            if (reporte != null)
            {
                _context.Reporte.Remove(reporte);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReporteExists(string id)
        {
          return (_context.Reporte?.Any(e => e.IdDispositivo == id)).GetValueOrDefault();
        }
    }
}
