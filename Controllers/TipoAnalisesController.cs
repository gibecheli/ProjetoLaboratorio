﻿using System;
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

            var tipoAnalisesModel = await _context.TipoAnalise
                .FirstOrDefaultAsync(m => m.TipoId == id);
            if (tipoAnalisesModel == null)
            {
                return NotFound();
            }

            return View(tipoAnalisesModel);
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
        public async Task<IActionResult> Create([Bind("TipoId,TipoAnalises,Descricao,valor")] TipoAnalisesModel tipoAnalisesModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoAnalisesModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoAnalisesModel);
        }

        // GET: TipoAnalises/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoAnalise == null)
            {
                return NotFound();
            }

            var tipoAnalisesModel = await _context.TipoAnalise.FindAsync(id);
            if (tipoAnalisesModel == null)
            {
                return NotFound();
            }
            return View(tipoAnalisesModel);
        }

        // POST: TipoAnalises/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoId,TipoAnalises,Descricao,valor")] TipoAnalisesModel tipoAnalisesModel)
        {
            if (id != tipoAnalisesModel.TipoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoAnalisesModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoAnalisesModelExists(tipoAnalisesModel.TipoId))
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
            return View(tipoAnalisesModel);
        }

        // GET: TipoAnalises/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoAnalise == null)
            {
                return NotFound();
            }

            var tipoAnalisesModel = await _context.TipoAnalise
                .FirstOrDefaultAsync(m => m.TipoId == id);
            if (tipoAnalisesModel == null)
            {
                return NotFound();
            }

            return View(tipoAnalisesModel);
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
            var tipoAnalisesModel = await _context.TipoAnalise.FindAsync(id);
            if (tipoAnalisesModel != null)
            {
                _context.TipoAnalise.Remove(tipoAnalisesModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoAnalisesModelExists(int id)
        {
          return _context.TipoAnalise.Any(e => e.TipoId == id);
        }
    }
}
