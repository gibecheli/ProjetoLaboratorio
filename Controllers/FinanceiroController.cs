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
    public class FinanceiroController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FinanceiroController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Financeiro
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Financeiro.Include(f => f.Pedidos);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Financeiro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Financeiro == null)
            {
                return NotFound();
            }

            var financeiroModel = await _context.Financeiro
                .Include(f => f.Pedidos)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (financeiroModel == null)
            {
                return NotFound();
            }

            return View(financeiroModel);
        }

        // GET: Financeiro/Create
        public IActionResult Create()
        {
            ViewData["PedidosId"] = new SelectList(_context.Pedidos, "PedidoId", "ClienteId");
            return View();
        }

        // POST: Financeiro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PedidosId,ValorTotal,FormaPagamento,StatusPagamento")] FinanceiroModel financeiroModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(financeiroModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PedidosId"] = new SelectList(_context.Pedidos, "PedidoId", "ClienteId", financeiroModel.PedidosId);
            return View(financeiroModel);
        }

        // GET: Financeiro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Financeiro == null)
            {
                return NotFound();
            }

            var financeiroModel = await _context.Financeiro.FindAsync(id);
            if (financeiroModel == null)
            {
                return NotFound();
            }
            ViewData["PedidosId"] = new SelectList(_context.Pedidos, "PedidoId", "ClienteId", financeiroModel.PedidosId);
            return View(financeiroModel);
        }

        // POST: Financeiro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PedidosId,ValorTotal,FormaPagamento,StatusPagamento")] FinanceiroModel financeiroModel)
        {
            if (id != financeiroModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(financeiroModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FinanceiroModelExists(financeiroModel.Id))
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
            ViewData["PedidosId"] = new SelectList(_context.Pedidos, "PedidoId", "ClienteId", financeiroModel.PedidosId);
            return View(financeiroModel);
        }

        // GET: Financeiro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Financeiro == null)
            {
                return NotFound();
            }

            var financeiroModel = await _context.Financeiro
                .Include(f => f.Pedidos)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (financeiroModel == null)
            {
                return NotFound();
            }

            return View(financeiroModel);
        }

        // POST: Financeiro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Financeiro == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Financeiro'  is null.");
            }
            var financeiroModel = await _context.Financeiro.FindAsync(id);
            if (financeiroModel != null)
            {
                _context.Financeiro.Remove(financeiroModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FinanceiroModelExists(int id)
        {
          return _context.Financeiro.Any(e => e.Id == id);
        }
    }
}
