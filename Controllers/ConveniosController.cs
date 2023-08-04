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
    public class ConveniosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConveniosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Convenios
        public async Task<IActionResult> Index()
        {
              return View(await _context.Convenios.ToListAsync());
        }

        // GET: Convenios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Convenios == null)
            {
                return NotFound();
            }

            var convenioModel = await _context.Convenios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (convenioModel == null)
            {
                return NotFound();
            }

            return View(convenioModel);
        }

        // GET: Convenios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Convenios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Desconto")] ConvenioModel convenioModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(convenioModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(convenioModel);
        }

        // GET: Convenios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Convenios == null)
            {
                return NotFound();
            }

            var convenioModel = await _context.Convenios.FindAsync(id);
            if (convenioModel == null)
            {
                return NotFound();
            }
            return View(convenioModel);
        }

        // POST: Convenios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Desconto")] ConvenioModel convenioModel)
        {
            if (id != convenioModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(convenioModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConvenioModelExists(convenioModel.Id))
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
            return View(convenioModel);
        }

        // GET: Convenios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Convenios == null)
            {
                return NotFound();
            }

            var convenioModel = await _context.Convenios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (convenioModel == null)
            {
                return NotFound();
            }

            return View(convenioModel);
        }

        // POST: Convenios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Convenios == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Convenios'  is null.");
            }
            var convenioModel = await _context.Convenios.FindAsync(id);
            if (convenioModel != null)
            {
                _context.Convenios.Remove(convenioModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConvenioModelExists(int id)
        {
          return _context.Convenios.Any(e => e.Id == id);
        }
    }
}
