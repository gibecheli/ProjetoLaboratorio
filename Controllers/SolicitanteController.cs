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
    public class SolicitanteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SolicitanteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Solicitante
        public async Task<IActionResult> Index()
        {
              return View(await _context.Solicitantes.ToListAsync());
        }

        // GET: Solicitante/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Solicitantes == null)
            {
                return NotFound();
            }

            var solicitanteModel = await _context.Solicitantes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (solicitanteModel == null)
            {
                return NotFound();
            }

            return View(solicitanteModel);
        }

        // GET: Solicitante/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Solicitante/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TipoPessoa,Nome,Endereco,Cidade,Estado,Telefone,Celular,Email,CPF,CNPJ,IE,RazaoSocial,DataDeCadastro")] SolicitanteModel solicitanteModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(solicitanteModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(solicitanteModel);
        }

        // GET: Solicitante/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Solicitantes == null)
            {
                return NotFound();
            }

            var solicitanteModel = await _context.Solicitantes.FindAsync(id);
            if (solicitanteModel == null)
            {
                return NotFound();
            }
            return View(solicitanteModel);
        }

        // POST: Solicitante/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TipoPessoa,Nome,Endereco,Cidade,Estado,Telefone,Celular,Email,CPF,CNPJ,IE,RazaoSocial,DataDeCadastro")] SolicitanteModel solicitanteModel)
        {
            if (id != solicitanteModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(solicitanteModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SolicitanteModelExists(solicitanteModel.Id))
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
            return View(solicitanteModel);
        }

        // GET: Solicitante/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Solicitantes == null)
            {
                return NotFound();
            }

            var solicitanteModel = await _context.Solicitantes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (solicitanteModel == null)
            {
                return NotFound();
            }

            return View(solicitanteModel);
        }

        // POST: Solicitante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Solicitantes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Solicitantes'  is null.");
            }
            var solicitanteModel = await _context.Solicitantes.FindAsync(id);
            if (solicitanteModel != null)
            {
                _context.Solicitantes.Remove(solicitanteModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SolicitanteModelExists(int id)
        {
          return _context.Solicitantes.Any(e => e.Id == id);
        }
    }
}