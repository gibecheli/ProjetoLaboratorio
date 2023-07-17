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
    public class PedidosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PedidosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pedidos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Pedidos.Include(p => p.AnalisesModel).Include(p => p.ClientesModel);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Pedidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pedidos == null)
            {
                return NotFound();
            }

            var pedidosModel = await _context.Pedidos
                .Include(p => p.AnalisesModel)
                .Include(p => p.ClientesModel)
                .FirstOrDefaultAsync(m => m.PedidoId == id);
            if (pedidosModel == null)
            {
                return NotFound();
            }

            return View(pedidosModel);
        }

        // GET: Pedidos/Create
        public IActionResult Create()
        {
            ViewData["AnalisesModelId"] = new SelectList(_context.Analises, "Id", "Descricao");
            ViewData["ClientesModelId"] = new SelectList(_context.Clientes, "Id", "CNPJ");
            return View();
        }

        // POST: Pedidos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PedidoId,ClientesModelId,AnalisesModelId,TipoAnalise,Quantidade,valor,DataEntrada,DataSaida")] PedidosModel pedidosModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedidosModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnalisesModelId"] = new SelectList(_context.Analises, "Id", "Descricao", pedidosModel.AnalisesModelId);
            ViewData["ClientesModelId"] = new SelectList(_context.Clientes, "Id", "CNPJ", pedidosModel.ClientesModelId);
            return View(pedidosModel);
        }

        // GET: Pedidos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pedidos == null)
            {
                return NotFound();
            }

            var pedidosModel = await _context.Pedidos.FindAsync(id);
            if (pedidosModel == null)
            {
                return NotFound();
            }
            ViewData["AnalisesModelId"] = new SelectList(_context.Analises, "Id", "Descricao", pedidosModel.AnalisesModelId);
            ViewData["ClientesModelId"] = new SelectList(_context.Clientes, "Id", "CNPJ", pedidosModel.ClientesModelId);
            return View(pedidosModel);
        }

        // POST: Pedidos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PedidoId,ClientesModelId,AnalisesModelId,TipoAnalise,Quantidade,valor,DataEntrada,DataSaida")] PedidosModel pedidosModel)
        {
            if (id != pedidosModel.PedidoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedidosModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidosModelExists(pedidosModel.PedidoId))
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
            ViewData["AnalisesModelId"] = new SelectList(_context.Analises, "Id", "Descricao", pedidosModel.AnalisesModelId);
            ViewData["ClientesModelId"] = new SelectList(_context.Clientes, "Id", "CNPJ", pedidosModel.ClientesModelId);
            return View(pedidosModel);
        }

        // GET: Pedidos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pedidos == null)
            {
                return NotFound();
            }

            var pedidosModel = await _context.Pedidos
                .Include(p => p.AnalisesModel)
                .Include(p => p.ClientesModel)
                .FirstOrDefaultAsync(m => m.PedidoId == id);
            if (pedidosModel == null)
            {
                return NotFound();
            }

            return View(pedidosModel);
        }

        // POST: Pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pedidos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Pedidos'  is null.");
            }
            var pedidosModel = await _context.Pedidos.FindAsync(id);
            if (pedidosModel != null)
            {
                _context.Pedidos.Remove(pedidosModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidosModelExists(int id)
        {
          return _context.Pedidos.Any(e => e.PedidoId == id);
        }
    }
}