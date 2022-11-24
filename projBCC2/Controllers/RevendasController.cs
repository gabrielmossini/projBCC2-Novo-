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
    public class RevendasController : Controller
    {
        private readonly Contexto _context;

        public RevendasController(Contexto context)
        {
            _context = context;
        }

        // GET: Revendas
        public async Task<IActionResult> Index()
        {
            var contexto = _context.revendas.Include(r => r.cliente).Include(r => r.compra);
            return View(await contexto.ToListAsync());
        }

        // GET: Revendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.revendas == null)
            {
                return NotFound();
            }

            var revenda = await _context.revendas
                .Include(r => r.cliente)
                .Include(r => r.compra)
                .FirstOrDefaultAsync(m => m.id == id);
            if (revenda == null)
            {
                return NotFound();
            }

            return View(revenda);
        }
        // GET: Revendas/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["clienteid"] = new SelectList(_context.clientes, "id", "nome");
            ViewData["compraid"] = new SelectList(_context.compras, "id", "produto");
            return View();
        }

        // POST: Revendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,clienteid,compraid,data,quantidadeVenda")] Revenda revenda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(revenda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["clienteid"] = new SelectList(_context.clientes, "id", "nome", revenda.clienteid);
            ViewData["compraid"] = new SelectList(_context.compras, "id", "produto", revenda.compraid);
            return View(revenda);
        }

        // GET: Revendas/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.revendas == null)
            {
                return NotFound();
            }

            var revenda = await _context.revendas.FindAsync(id);
            if (revenda == null)
            {
                return NotFound();
            }
            ViewData["clienteid"] = new SelectList(_context.clientes, "id", "nome", revenda.clienteid);
            ViewData["compraid"] = new SelectList(_context.compras, "id", "produto", revenda.compraid);
            return View(revenda);
        }

        // POST: Revendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,clienteid,compraid,data,quantidadeVenda")] Revenda revenda)
        {
            if (id != revenda.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(revenda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RevendaExists(revenda.id))
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
            ViewData["clienteid"] = new SelectList(_context.clientes, "id", "nome", revenda.clienteid);
            ViewData["compraid"] = new SelectList(_context.compras, "id", "produto", revenda.compraid);
            return View(revenda);
        }

        // GET: Revendas/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.revendas == null)
            {
                return NotFound();
            }

            var revenda = await _context.revendas
                .Include(r => r.cliente)
                .Include(r => r.compra)
                .FirstOrDefaultAsync(m => m.id == id);
            if (revenda == null)
            {
                return NotFound();
            }

            return View(revenda);
        }

        // POST: Revendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.revendas == null)
            {
                return Problem("Entity set 'Contexto.revendas'  is null.");
            }
            var revenda = await _context.revendas.FindAsync(id);
            if (revenda != null)
            {
                _context.revendas.Remove(revenda);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RevendaExists(int id)
        {
          return _context.revendas.Any(e => e.id == id);
        }
    }
}
