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
    public class ClientesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
              return View(await _context.Clientes.ToListAsync());
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var clientesModel = await _context.Clientes
                .FirstOrDefaultAsync(m => m.CpfCnpj == id);
            if (clientesModel == null)
            {
                return NotFound();
            }

            return View(clientesModel);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TipoPessoa,CpfCnpj,Nome,Endereco,Cidade,Estado,Telefone,Celular,Email,InscricaoEstadual,RazaoSocial,NomePropriedade,DataDoCadastro")] ClientesModel clientesModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientesModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clientesModel);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var clientesModel = await _context.Clientes.FindAsync(id);
            if (clientesModel == null)
            {
                return NotFound();
            }
            return View(clientesModel);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,TipoPessoa,CpfCnpj,Nome,Endereco,Cidade,Estado,Telefone,Celular,Email,InscricaoEstadual,RazaoSocial,NomePropriedade,DataDoCadastro")] ClientesModel clientesModel)
        {
            if (id != clientesModel.CpfCnpj)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientesModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientesModelExists(clientesModel.CpfCnpj))
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
            return View(clientesModel);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var clientesModel = await _context.Clientes
                .FirstOrDefaultAsync(m => m.CpfCnpj == id);
            if (clientesModel == null)
            {
                return NotFound();
            }

            return View(clientesModel);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Clientes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Clientes'  is null.");
            }
            var clientesModel = await _context.Clientes.FindAsync(id);
            if (clientesModel != null)
            {
                _context.Clientes.Remove(clientesModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientesModelExists(string id)
        {
          return _context.Clientes.Any(e => e.CpfCnpj == id);
        }
    }
}
