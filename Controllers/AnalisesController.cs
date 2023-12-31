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
    public class AnalisesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnalisesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Analises
        public async Task<IActionResult> Index()
        {
              return View(await _context.Analises.ToListAsync());
        }

        // GET: Analises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Analises == null)
            {
                return NotFound();
            }

            var analiseModel = await _context.Analises
                .FirstOrDefaultAsync(m => m.Id == id);
            if (analiseModel == null)
            {
                return NotFound();
            }

            return View(analiseModel);
        }

        // GET: Analises/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Analises/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao")] AnaliseModel analiseModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(analiseModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(analiseModel);
        }

        // GET: Analises/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Analises == null)
            {
                return NotFound();
            }

            var analiseModel = await _context.Analises.FindAsync(id);
            if (analiseModel == null)
            {
                return NotFound();
            }
            return View(analiseModel);
        }

        // POST: Analises/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao")] AnaliseModel analiseModel)
        {
            if (id != analiseModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(analiseModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnaliseModelExists(analiseModel.Id))
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
            return View(analiseModel);
        }

        // GET: Analises/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Analises == null)
            {
                return NotFound();
            }

            var analiseModel = await _context.Analises
                .FirstOrDefaultAsync(m => m.Id == id);
            if (analiseModel == null)
            {
                return NotFound();
            }

            return View(analiseModel);
        }

        // POST: Analises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Analises == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Analises'  is null.");
            }
            var analiseModel = await _context.Analises.FindAsync(id);
            if (analiseModel != null)
            {
                _context.Analises.Remove(analiseModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnaliseModelExists(int id)
        {
          return _context.Analises.Any(e => e.Id == id);
        }
    }
}
