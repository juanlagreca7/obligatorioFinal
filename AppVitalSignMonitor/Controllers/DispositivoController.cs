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
    public class DispositivoController : Controller
    {
        private readonly Context _context;

        public DispositivoController(Context context)
        {
            _context = context;
        }

        // GET: Dispositivo
        public async Task<IActionResult> Index()
        {
            var context = _context.Dispositivo.Include(d => d.Creador).Include(d => d.Paciente);
            return View(await context.ToListAsync());
        }

        // GET: Dispositivo/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Dispositivo == null)
            {
                return NotFound();
            }

            var dispositivo = await _context.Dispositivo
                .Include(d => d.Creador)
                .Include(d => d.Paciente)
                .FirstOrDefaultAsync(m => m.IdDispositivo == id);
            if (dispositivo == null)
            {
                return NotFound();
            }

            return View(dispositivo);
        }

        // GET: Dispositivo/Create
        public IActionResult Create()
        {
            ViewData["CreadorId"] = new SelectList(_context.Usuario, "IdUsuario", "IdUsuario");
            ViewData["PacienteId"] = new SelectList(_context.Set<Paciente>(), "IdUsuario", "IdUsuario");
            return View();
        }

        // POST: Dispositivo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDispositivo,CreadorId,PacienteId,NombreDispositivo,Detalles,FechaAlta,UltimaModificacion,Estado,Tokken")] Dispositivo dispositivo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dispositivo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CreadorId"] = new SelectList(_context.Usuario, "IdUsuario", "IdUsuario", dispositivo.CreadorId);
            ViewData["PacienteId"] = new SelectList(_context.Set<Paciente>(), "IdUsuario", "IdUsuario", dispositivo.PacienteId);
            return View(dispositivo);
        }

        // GET: Dispositivo/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Dispositivo == null)
            {
                return NotFound();
            }

            var dispositivo = await _context.Dispositivo.FindAsync(id);
            if (dispositivo == null)
            {
                return NotFound();
            }
            ViewData["CreadorId"] = new SelectList(_context.Usuario, "IdUsuario", "IdUsuario", dispositivo.CreadorId);
            ViewData["PacienteId"] = new SelectList(_context.Set<Paciente>(), "IdUsuario", "IdUsuario", dispositivo.PacienteId);
            return View(dispositivo);
        }

        // POST: Dispositivo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdDispositivo,CreadorId,PacienteId,NombreDispositivo,Detalles,FechaAlta,UltimaModificacion,Estado,Tokken")] Dispositivo dispositivo)
        {
            if (id != dispositivo.IdDispositivo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dispositivo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DispositivoExists(dispositivo.IdDispositivo))
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
            ViewData["CreadorId"] = new SelectList(_context.Usuario, "IdUsuario", "IdUsuario", dispositivo.CreadorId);
            ViewData["PacienteId"] = new SelectList(_context.Set<Paciente>(), "IdUsuario", "IdUsuario", dispositivo.PacienteId);
            return View(dispositivo);
        }

        // GET: Dispositivo/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Dispositivo == null)
            {
                return NotFound();
            }

            var dispositivo = await _context.Dispositivo
                .Include(d => d.Creador)
                .Include(d => d.Paciente)
                .FirstOrDefaultAsync(m => m.IdDispositivo == id);
            if (dispositivo == null)
            {
                return NotFound();
            }

            return View(dispositivo);
        }

        // POST: Dispositivo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Dispositivo == null)
            {
                return Problem("Entity set 'Context.Dispositivo'  is null.");
            }
            var dispositivo = await _context.Dispositivo.FindAsync(id);
            if (dispositivo != null)
            {
                _context.Dispositivo.Remove(dispositivo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DispositivoExists(string id)
        {
          return (_context.Dispositivo?.Any(e => e.IdDispositivo == id)).GetValueOrDefault();
        }
    }
}
