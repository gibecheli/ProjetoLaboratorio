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
    public class ResultadosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResultadosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Resultados
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Resultado.Include(r => r.Pedido);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Resultados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Resultado == null)
            {
                return NotFound();
            }

            var resultadoModel = await _context.Resultado
                .Include(r => r.Pedido)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resultadoModel == null)
            {
                return NotFound();
            }

            return View(resultadoModel);
        }

        // GET: Resultados/Create
        public IActionResult Create()
        {
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "PedidoId", "ClienteId");
            return View();
        }

        // POST: Resultados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PedidoId,Laudo,DataLaudo,EmailCliente")] ResultadoModel resultadoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resultadoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "PedidoId", "ClienteId", resultadoModel.PedidoId);
            return View(resultadoModel);
        }

        // GET: Resultados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Resultado == null)
            {
                return NotFound();
            }

            var resultadoModel = await _context.Resultado.FindAsync(id);
            if (resultadoModel == null)
            {
                return NotFound();
            }
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "PedidoId", "ClienteId", resultadoModel.PedidoId);
            return View(resultadoModel);
        }

        // POST: Resultados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PedidoId,Laudo,DataLaudo,EmailCliente")] ResultadoModel resultadoModel)
        {
            if (id != resultadoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resultadoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResultadoModelExists(resultadoModel.Id))
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
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "PedidoId", "ClienteId", resultadoModel.PedidoId);
            return View(resultadoModel);
        }

        // GET: Resultados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Resultado == null)
            {
                return NotFound();
            }

            var resultadoModel = await _context.Resultado
                .Include(r => r.Pedido)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resultadoModel == null)
            {
                return NotFound();
            }

            return View(resultadoModel);
        }

        // POST: Resultados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Resultado == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Resultado'  is null.");
            }
            var resultadoModel = await _context.Resultado.FindAsync(id);
            if (resultadoModel != null)
            {
                _context.Resultado.Remove(resultadoModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResultadoModelExists(int id)
        {
          return _context.Resultado.Any(e => e.Id == id);
        }
    }
}
