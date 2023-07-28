using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoLaboratorio.Data;
using ProjetoLaboratorio.Models;

namespace ProjetoLaboratorio.Controllers
{
    public class TipoAnalisesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoAnalisesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoAnalises
        public async Task<IActionResult> Index()
        {
              return View(await _context.TipoAnalise.ToListAsync());
        }

        // GET: TipoAnalises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoAnalise == null)
            {
                return NotFound();
            }

            var tipoAnaliseModel = await _context.TipoAnalise
                .FirstOrDefaultAsync(m => m.TipoAnaliseId == id);
            if (tipoAnaliseModel == null)
            {
                return NotFound();
            }

            return View(tipoAnaliseModel);
        }

        // GET: TipoAnalises/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoAnalises/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoAnaliseId,TipoAnalise,Descricao,Valor")] TipoAnaliseModel tipoAnaliseModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoAnaliseModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoAnaliseModel);
        }

        // GET: TipoAnalises/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoAnalise == null)
            {
                return NotFound();
            }

            var tipoAnaliseModel = await _context.TipoAnalise.FindAsync(id);
            if (tipoAnaliseModel == null)
            {
                return NotFound();
            }
            return View(tipoAnaliseModel);
        }

        // POST: TipoAnalises/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoAnaliseId,TipoAnalise,Descricao,Valor")] TipoAnaliseModel tipoAnaliseModel)
        {
            if (id != tipoAnaliseModel.TipoAnaliseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoAnaliseModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoAnaliseModelExists(tipoAnaliseModel.TipoAnaliseId))
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
            return View(tipoAnaliseModel);
        }

        // GET: TipoAnalises/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoAnalise == null)
            {
                return NotFound();
            }

            var tipoAnaliseModel = await _context.TipoAnalise
                .FirstOrDefaultAsync(m => m.TipoAnaliseId == id);
            if (tipoAnaliseModel == null)
            {
                return NotFound();
            }

            return View(tipoAnaliseModel);
        }

        // POST: TipoAnalises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoAnalise == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TipoAnalise'  is null.");
            }
            var tipoAnaliseModel = await _context.TipoAnalise.FindAsync(id);
            if (tipoAnaliseModel != null)
            {
                _context.TipoAnalise.Remove(tipoAnaliseModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoAnaliseModelExists(int id)
        {
          return _context.TipoAnalise.Any(e => e.TipoAnaliseId == id);
        }
    }
}
