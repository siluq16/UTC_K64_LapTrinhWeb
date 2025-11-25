using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLBH.Models;

namespace QLBH.Controllers
{
    public class HangHoasController : Controller
    {
        private readonly QlhangHoaContext _context;

        public HangHoasController(QlhangHoaContext context)
        {
            _context = context;
        }

        // GET: HangHoas
        public async Task<IActionResult> Index()
        {
            var qlhangHoaContext = _context.HangHoas.Where(h => h.Gia >=100)
                                    .Include(h => h.MaLoaiNavigation);
            return View(await qlhangHoaContext.ToListAsync());
        }

        [HttpGet]
        public IActionResult GetProductByCategoryID(int? maLoai)
        {
            var query = _context.HangHoas
                            .Include(h => h.MaLoaiNavigation)
                            .Where(h => h.Gia >= 100);
            if (maLoai.HasValue)
            {
                query = query.Where(p => p.MaLoai == maLoai.Value);
            }
            var products = query.ToList();
            return PartialView("_ProductPartialView", products);
        }

        public IActionResult FilterProduct(int? maLoai, string? keyWord)
        {
            var query = _context.HangHoas
                            .Include(h => h.MaLoaiNavigation)
                            .Where(h => h.Gia >= 100);
            if (maLoai.HasValue)
            {
                query = query.Where(p => p.MaLoai == maLoai.Value);
            }
            if (!string.IsNullOrEmpty(keyWord))
            {
                query = query.Where(p => p.TenHang.Contains(keyWord));
            }
            var products = query.ToList();
            return PartialView("_ProductPartialView", products);
        }
        // GET: HangHoas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hangHoa = await _context.HangHoas
                .Include(h => h.MaLoaiNavigation)
                .FirstOrDefaultAsync(m => m.MaHang == id);
            if (hangHoa == null)
            {
                return NotFound();
            }

            return View(hangHoa);
        }

        // GET: HangHoas/Create
        public IActionResult Create()
        {
            ViewData["MaLoai"] = new SelectList(_context.LoaiHangs, "MaLoai", "TenLoai");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaLoai,TenHang,Gia,Anh")] HangHoa hangHoa)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var e in errors)
                {
                    Console.WriteLine(e.ErrorMessage);
                }
                ViewData["MaLoai"] = new SelectList(_context.LoaiHangs, "MaLoai", "TenLoai", hangHoa.MaLoai);
                return View(hangHoa);
            }
            else
            {
                _context.Add(hangHoa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hangHoa = await _context.HangHoas.FindAsync(id);
            if (hangHoa == null)
            {
                return NotFound();
            }
            ViewData["MaLoai"] = new SelectList(_context.LoaiHangs, "MaLoai", "MaLoai", hangHoa.MaLoai);
            return View(hangHoa);
        }

        // POST: HangHoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaHang,MaLoai,TenHang,Gia,Anh")] HangHoa hangHoa)
        {
            if (id != hangHoa.MaHang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hangHoa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HangHoaExists(hangHoa.MaHang))
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
            ViewData["MaLoai"] = new SelectList(_context.LoaiHangs, "MaLoai", "MaLoai", hangHoa.MaLoai);
            return View(hangHoa);
        }

        // GET: HangHoas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hangHoa = await _context.HangHoas
                .Include(h => h.MaLoaiNavigation)
                .FirstOrDefaultAsync(m => m.MaHang == id);
            if (hangHoa == null)
            {
                return NotFound();
            }

            return View(hangHoa);
        }

        // POST: HangHoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hangHoa = await _context.HangHoas.FindAsync(id);
            if (hangHoa != null)
            {
                _context.HangHoas.Remove(hangHoa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HangHoaExists(int id)
        {
            return _context.HangHoas.Any(e => e.MaHang == id);
        }
    }
}
