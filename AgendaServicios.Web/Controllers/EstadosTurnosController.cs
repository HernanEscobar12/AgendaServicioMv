using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgendaServicios.Web.Data;
using AgendaServicios.Web.Models;

namespace AgendaServicios.Web.Controllers
{
    public class EstadosTurnosController : Controller
    {
        private readonly AppDbContext _context;

        public EstadosTurnosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: EstadosTurnos
        public async Task<IActionResult> Index()
        {
              //return _context.EstadosTurnos != null ? 
              //            View(await _context.EstadosTurnos.ToListAsync()) :
              //            Problem("Entity set 'AppDbContext.EstadosTurnos'  is null.");
                var estadosTurnos = _context.EstadosTurnos.ToList();
                return View(estadosTurnos);
        }

        // GET: EstadosTurnos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EstadosTurnos == null)
            {
                return NotFound();
            }

            var estadosTurno = await _context.EstadosTurnos
                .FirstOrDefaultAsync(m => m.EstadoTurnoId == id);
            if (estadosTurno == null)
            {
                return NotFound();
            }

            return View(estadosTurno);
        }

        // GET: EstadosTurnos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EstadosTurnos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EstadoTurnoId,Descripcion")] EstadosTurno estadosTurno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadosTurno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadosTurno);
        }

        // GET: EstadosTurnos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var estadosTurno = await _context.EstadosTurnos.FindAsync(id);
            if (estadosTurno == null)
            {
                return NotFound();
            }
            return View(estadosTurno);
        }

        // POST: EstadosTurnos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EstadoTurnoId,Descripcion")] EstadosTurno estadosTurno)
        {
            if (id != estadosTurno.EstadoTurnoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadosTurno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadosTurnoExists(estadosTurno.EstadoTurnoId))
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
            return View(estadosTurno);
        }

        // GET: EstadosTurnos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EstadosTurnos == null)
            {
                return NotFound();
            }

            var estadosTurno = await _context.EstadosTurnos
                .FirstOrDefaultAsync(m => m.EstadoTurnoId == id);
            if (estadosTurno == null)
            {
                return NotFound();
            }

            return View(estadosTurno);
        }

        // POST: EstadosTurnos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EstadosTurnos == null)
            {
                return Problem("Entity set 'AppDbContext.EstadosTurnos'  is null.");
            }
            var estadosTurno = await _context.EstadosTurnos.FindAsync(id);
            if (estadosTurno != null)
            {
                _context.EstadosTurnos.Remove(estadosTurno);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadosTurnoExists(int id)
        {
          return (_context.EstadosTurnos?.Any(e => e.EstadoTurnoId == id)).GetValueOrDefault();
        }
    }
}
