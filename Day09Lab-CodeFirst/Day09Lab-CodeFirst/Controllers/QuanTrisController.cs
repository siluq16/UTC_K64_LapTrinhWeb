﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Day09Lab_CodeFirst.Models;

namespace Day09Lab_CodeFirst.Controllers
{
    public class QuanTrisController : Controller
    {
        private readonly ShoppingCartContext _context;

        public QuanTrisController(ShoppingCartContext context)
        {
            _context = context;
        }

        // GET: QuanTris
        public async Task<IActionResult> Index()
        {
            return View(await _context.QuanTris.ToListAsync());
        }

        // GET: QuanTris/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quanTri = await _context.QuanTris
                .FirstOrDefaultAsync(m => m.ID == id);
            if (quanTri == null)
            {
                return NotFound();
            }

            return View(quanTri);
        }

        // GET: QuanTris/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: QuanTris/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TaiKhoan,MatKhau,TrangThai")] QuanTri quanTri)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quanTri);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(quanTri);
        }

        // GET: QuanTris/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quanTri = await _context.QuanTris.FindAsync(id);
            if (quanTri == null)
            {
                return NotFound();
            }
            return View(quanTri);
        }

        // POST: QuanTris/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TaiKhoan,MatKhau,TrangThai")] QuanTri quanTri)
        {
            if (id != quanTri.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quanTri);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuanTriExists(quanTri.ID))
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
            return View(quanTri);
        }

        // GET: QuanTris/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quanTri = await _context.QuanTris
                .FirstOrDefaultAsync(m => m.ID == id);
            if (quanTri == null)
            {
                return NotFound();
            }

            return View(quanTri);
        }

        // POST: QuanTris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var quanTri = await _context.QuanTris.FindAsync(id);
            if (quanTri != null)
            {
                _context.QuanTris.Remove(quanTri);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuanTriExists(int id)
        {
            return _context.QuanTris.Any(e => e.ID == id);
        }
    }
}
