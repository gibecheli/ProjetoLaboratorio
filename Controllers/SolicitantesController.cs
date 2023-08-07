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
    public class SolicitantesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SolicitantesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Solicitantes
        public async Task<IActionResult> Index()
        {
              return View(await _context.Solicitantes.ToListAsync());
        }

        // GET: Solicitantes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Solicitantes == null)
            {
                return NotFound();
            }

            var solicitanteModel = await _context.Solicitantes
                .FirstOrDefaultAsync(m => m.CpfCnpjS == id);
            if (solicitanteModel == null)
            {
                return NotFound();
            }

            return View(solicitanteModel);
        }

        // GET: Solicitantes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Solicitantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CpfCnpjS,TipoPessoa,Nome,Endereco,Cidade,Estado,Telefone,Celular,Email,DataCadastro")] SolicitanteModel solicitanteModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(solicitanteModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(solicitanteModel);
        }

        // GET: Solicitantes/Edit/5
        public async Task<IActionResult> Edit(string id)
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

        // POST: Solicitantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CpfCnpjS,TipoPessoa,Nome,Endereco,Cidade,Estado,Telefone,Celular,Email,DataCadastro")] SolicitanteModel solicitanteModel)
        {
            if (id != solicitanteModel.CpfCnpjS)
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
                    if (!SolicitanteModelExists(solicitanteModel.CpfCnpjS))
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

        // GET: Solicitantes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Solicitantes == null)
            {
                return NotFound();
            }

            var solicitanteModel = await _context.Solicitantes
                .FirstOrDefaultAsync(m => m.CpfCnpjS == id);
            if (solicitanteModel == null)
            {
                return NotFound();
            }

            return View(solicitanteModel);
        }

        // POST: Solicitantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
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

        private bool SolicitanteModelExists(string id)
        {
          return _context.Solicitantes.Any(e => e.CpfCnpjS == id);
        }
    }
}
