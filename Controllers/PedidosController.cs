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
            var applicationDbContext = _context.Pedidos.Include(p => p.Analise).Include(p => p.Cliente).Include(p => p.TipoAnalise);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Pedidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pedidos == null)
            {
                return NotFound();
            }

            var pedidoModel = await _context.Pedidos
                .Include(p => p.Analise)
                .Include(p => p.Cliente)
                .Include(p => p.TipoAnalise)
                .FirstOrDefaultAsync(m => m.PedidoId == id);
            if (pedidoModel == null)
            {
                return NotFound();
            }

            return View(pedidoModel);
        }

        // GET: Pedidos/Create
        public IActionResult Create()
        {
            ViewData["AnaliseId"] = new SelectList(_context.Analises, "Id", "Descricao");
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "CpfCnpj", "CpfCnpj");
            ViewData["TipoAnaliseId"] = new SelectList(_context.TipoAnalise, "TipoAnaliseId", "Descricao");
            return View();
        }

        // POST: Pedidos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PedidoId,ClienteId,AnaliseId,TipoAnaliseId,Quantidade,Valor,Total,Observacao,DataEntrada,DataSaida")] PedidoModel pedidoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedidoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnaliseId"] = new SelectList(_context.Analises, "Id", "Descricao", pedidoModel.AnaliseId);
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "CpfCnpj", "CpfCnpj", pedidoModel.ClienteId);
            ViewData["TipoAnaliseId"] = new SelectList(_context.TipoAnalise, "TipoAnaliseId", "Descricao", pedidoModel.TipoAnaliseId);
            return View(pedidoModel);
        }

        // GET: Pedidos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pedidos == null)
            {
                return NotFound();
            }

            var pedidoModel = await _context.Pedidos.FindAsync(id);
            if (pedidoModel == null)
            {
                return NotFound();
            }
            ViewData["AnaliseId"] = new SelectList(_context.Analises, "Id", "Descricao", pedidoModel.AnaliseId);
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "CpfCnpj", "CpfCnpj", pedidoModel.ClienteId);
            ViewData["TipoAnaliseId"] = new SelectList(_context.TipoAnalise, "TipoAnaliseId", "Descricao", pedidoModel.TipoAnaliseId);
            return View(pedidoModel);
        }

        // POST: Pedidos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PedidoId,ClienteId,AnaliseId,TipoAnaliseId,Quantidade,Valor,Total,Observacao,DataEntrada,DataSaida")] PedidoModel pedidoModel)
        {
            if (id != pedidoModel.PedidoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedidoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoModelExists(pedidoModel.PedidoId))
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
            ViewData["AnaliseId"] = new SelectList(_context.Analises, "Id", "Descricao", pedidoModel.AnaliseId);
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "CpfCnpj", "CpfCnpj", pedidoModel.ClienteId);
            ViewData["TipoAnaliseId"] = new SelectList(_context.TipoAnalise, "TipoAnaliseId", "Descricao", pedidoModel.TipoAnaliseId);
            return View(pedidoModel);
        }

        // GET: Pedidos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pedidos == null)
            {
                return NotFound();
            }

            var pedidoModel = await _context.Pedidos
                .Include(p => p.Analise)
                .Include(p => p.Cliente)
                .Include(p => p.TipoAnalise)
                .FirstOrDefaultAsync(m => m.PedidoId == id);
            if (pedidoModel == null)
            {
                return NotFound();
            }

            return View(pedidoModel);
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
            var pedidoModel = await _context.Pedidos.FindAsync(id);
            if (pedidoModel != null)
            {
                _context.Pedidos.Remove(pedidoModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoModelExists(int id)
        {
          return _context.Pedidos.Any(e => e.PedidoId == id);
        }
    }
}
