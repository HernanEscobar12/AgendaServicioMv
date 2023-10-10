using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgendaServicios.Web.Data;
using AgendaServicios.Web.Models;

namespace AgendaServicios.Web.Controllers
{
    public class TiposServiciosController : Controller
    {
        private readonly AppDbContext _context;

        public TiposServiciosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TiposServicios
        public async Task<IActionResult> Index()
        {
              return _context.TiposServicios != null ? 
                          View(await _context.TiposServicios.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.TiposServicios'  is null.");
        }

        // GET: TiposServicios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TiposServicios == null)
            {
                return NotFound();
            }

            var tiposServicio = await _context.TiposServicios
                .FirstOrDefaultAsync(m => m.TipoServicioId == id);
            if (tiposServicio == null)
            {
                return NotFound();
            }

            return View(tiposServicio);
        }

        // GET: TiposServicios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TiposServicios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoServicioId,Descripcion")] TiposServicio tiposServicio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiposServicio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tiposServicio);
        }

        // GET: TiposServicios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TiposServicios == null)
            {
                return NotFound();
            }

            var tiposServicio = await _context.TiposServicios.FindAsync(id);
            if (tiposServicio == null)
            {
                return NotFound();
            }
            return View(tiposServicio);
        }

        // POST: TiposServicios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoServicioId,Descripcion")] TiposServicio tiposServicio)
        {
            if (id != tiposServicio.TipoServicioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiposServicio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiposServicioExists(tiposServicio.TipoServicioId))
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
            return View(tiposServicio);
        }

        // GET: TiposServicios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TiposServicios == null)
            {
                return NotFound();
            }

            var tiposServicio = await _context.TiposServicios
                .FirstOrDefaultAsync(m => m.TipoServicioId == id);
            if (tiposServicio == null)
            {
                return NotFound();
            }

            return View(tiposServicio);
        }

        // POST: TiposServicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TiposServicios == null)
            {
                return Problem("Entity set 'AppDbContext.TiposServicios'  is null.");
            }
            var tiposServicio = await _context.TiposServicios.FindAsync(id);
            if (tiposServicio != null)
            {
                _context.TiposServicios.Remove(tiposServicio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiposServicioExists(int id)
        {
          return (_context.TiposServicios?.Any(e => e.TipoServicioId == id)).GetValueOrDefault();
        }
    }
}
