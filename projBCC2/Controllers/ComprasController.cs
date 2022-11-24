using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using projBCC2.Models;

namespace projBCC2.Controllers
{
    [Authorize]
    public class ComprasController : Controller
    {
        private readonly Contexto _context;

        public ComprasController(Contexto context)
        {
            _context = context;
        }

        // GET: Compras
        public async Task<IActionResult> Index()
        {
            var contexto = _context.compras.Include(c => c.empresa).Include(c => c.funcionario);
            return View(await contexto.ToListAsync());
        }

        // GET: Compras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.compras == null)
            {
                return NotFound();
            }

            var compra = await _context.compras
                .Include(c => c.empresa)
                .Include(c => c.funcionario)
                .FirstOrDefaultAsync(m => m.id == id);
            if (compra == null)
            {
                return NotFound();
            }

            return View(compra);
        }

        // GET: Compras/Create
        public IActionResult Create()
        {
            ViewData["empresaid"] = new SelectList(_context.empresas, "id", "nomeEmpresa");
            ViewData["funcionarioid"] = new SelectList(_context.funcionarios, "id", "nomeFuncionarios");
            return View();
        }

        // POST: Compras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,funcionarioid,empresaid,produto,data,quantidadeCompra,valorUN")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(compra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["empresaid"] = new SelectList(_context.empresas, "id", "nomeEmpresa", compra.empresaid);
            ViewData["funcionarioid"] = new SelectList(_context.funcionarios, "id", "nomeFuncionarios", compra.funcionarioid);
            return View(compra);
        }

        // GET: Compras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.compras == null)
            {
                return NotFound();
            }

            var compra = await _context.compras.FindAsync(id);
            if (compra == null)
            {
                return NotFound();
            }
            ViewData["empresaid"] = new SelectList(_context.empresas, "id", "nomeEmpresa", compra.empresaid);
            ViewData["funcionarioid"] = new SelectList(_context.funcionarios, "id", "nomeFuncionarios", compra.funcionarioid);
            return View(compra);
        }

        // POST: Compras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,funcionarioid,empresaid,produto,data,quantidadeCompra,valorUN")] Compra compra)
        {
            if (id != compra.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompraExists(compra.id))
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
            ViewData["empresaid"] = new SelectList(_context.empresas, "id", "nomeEmpresa", compra.empresaid);
            ViewData["funcionarioid"] = new SelectList(_context.funcionarios, "id", "nomeFuncionarios", compra.funcionarioid);
            return View(compra);
        }

        // GET: Compras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.compras == null)
            {
                return NotFound();
            }

            var compra = await _context.compras
                .Include(c => c.empresa)
                .Include(c => c.funcionario)
                .FirstOrDefaultAsync(m => m.id == id);
            if (compra == null)
            {
                return NotFound();
            }

            return View(compra);
        }

        // POST: Compras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.compras == null)
            {
                return Problem("Entity set 'Contexto.compras'  is null.");
            }
            var compra = await _context.compras.FindAsync(id);
            if (compra != null)
            {
                _context.compras.Remove(compra);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompraExists(int id)
        {
          return _context.compras.Any(e => e.id == id);
        }
    }
}
