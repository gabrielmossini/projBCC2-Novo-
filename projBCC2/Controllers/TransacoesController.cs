﻿using System;
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
    public class TransacoesController : Controller
    {
        private readonly Contexto _context;

        public TransacoesController(Contexto context)
        {
            _context = context;
        }

        // GET: Transacoes
        public async Task<IActionResult> Index()
        {
              return View(await _context.Transacao.ToListAsync());
        }

        // GET: Transacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Transacao == null)
            {
                return NotFound();
            }

            var transacao = await _context.Transacao
                .FirstOrDefaultAsync(m => m.id == id);
            if (transacao == null)
            {
                return NotFound();
            }

            return View(transacao);
        }

        // GET: Transacoes/Create
        [Authorize(Roles = "ADMIN")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Transacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,contaid,data,quantidade,valor,operacao")] Transacao transacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transacao);
        }

        // GET: Transacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Transacao == null)
            {
                return NotFound();
            }

            var transacao = await _context.Transacao.FindAsync(id);
            if (transacao == null)
            {
                return NotFound();
            }
            return View(transacao);
        }

        // POST: Transacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,contaid,data,quantidade,valor,operacao")] Transacao transacao)
        {
            if (id != transacao.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransacaoExists(transacao.id))
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
            return View(transacao);
        }

        // GET: Transacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Transacao == null)
            {
                return NotFound();
            }

            var transacao = await _context.Transacao
                .FirstOrDefaultAsync(m => m.id == id);
            if (transacao == null)
            {
                return NotFound();
            }

            return View(transacao);
        }

        // POST: Transacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Transacao == null)
            {
                return Problem("Entity set 'Contexto.Transacao'  is null.");
            }
            var transacao = await _context.Transacao.FindAsync(id);
            if (transacao != null)
            {
                _context.Transacao.Remove(transacao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransacaoExists(int id)
        {
          return _context.Transacao.Any(e => e.id == id);
        }
    }
}