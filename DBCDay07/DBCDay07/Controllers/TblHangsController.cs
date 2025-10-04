using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DBCDay07.Models;

namespace DBCDay07.Controllers
{
    public class TblHangsController : Controller
    {
        private readonly QlbhContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public TblHangsController(QlbhContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: TblHangs
        public async Task<IActionResult> Index()
        {
            var qlbhContext = _context.TblHangs.Include(t => t.MaChatLieuNavigation);
            return View(await qlbhContext.ToListAsync());
        }

        // GET: TblHangs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblHang = await _context.TblHangs
                .Include(t => t.MaChatLieuNavigation)
                .FirstOrDefaultAsync(m => m.MaHang == id);
            if (tblHang == null)
            {
                return NotFound();
            }

            return View(tblHang);
        }

        // GET: TblHangs/Create
        public IActionResult Create()
        {
            ViewData["MaChatLieu"] = new SelectList(_context.TblChatlieus, "MaChatLieu", "MaChatLieu");
            return View();
        }

        // POST: TblHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaHang,TenHang,MaChatLieu,SoLuong,DonGiaNhap,DonGiaBan,Anh,GhiChu")] TblHang tblHang, IFormFile AnhFile)
        {
            if (ModelState.IsValid)
            {
                if (AnhFile != null && AnhFile.Length > 0)
                {
                    // Lấy tên file
                    var fileName = Path.GetFileName(AnhFile.FileName);

                    // Đường dẫn lưu file: wwwroot/images/[filename]
                    var uploadPath = Path.Combine(_hostEnvironment.WebRootPath, "images", "Hang");

                    // Tạo thư mục nếu chưa có
                    if (!Directory.Exists(uploadPath))
                    {
                        Directory.CreateDirectory(uploadPath);
                    }

                    var filePath = Path.Combine(uploadPath, fileName);

                    // Lưu file
                    
                    if (!System.IO.File.Exists(filePath))
                    {
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await AnhFile.CopyToAsync(stream);
                        }
                    }
                    // Lưu tên file vào DB (chỉ lưu tên, không lưu full path)
                    tblHang.Anh = fileName;
                }
                _context.Add(tblHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaChatLieu"] = new SelectList(_context.TblChatlieus, "MaChatLieu", "MaChatLieu", tblHang.MaChatLieu);
            return View(tblHang);
        }

        // GET: TblHangs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblHang = await _context.TblHangs.FindAsync(id);
            if (tblHang == null)
            {
                return NotFound();
            }
            ViewData["MaChatLieu"] = new SelectList(_context.TblChatlieus, "MaChatLieu", "MaChatLieu", tblHang.MaChatLieu);
            return View(tblHang);
        }

        // POST: TblHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaHang,TenHang,MaChatLieu,SoLuong,DonGiaNhap,DonGiaBan,Anh,GhiChu")] TblHang tblHang, IFormFile AnhFile)
        {
            if (id != tblHang.MaHang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var hangCu = await _context.TblHangs.AsNoTracking().FirstOrDefaultAsync(h => h.MaHang == id);
                    if (hangCu == null)
                    {
                        return NotFound();
                    }

                    if (AnhFile != null && AnhFile.Length > 0)
                    {
                        var fileName = Path.GetFileName(AnhFile.FileName);
                        var uploadPath = Path.Combine(_hostEnvironment.WebRootPath, "images", "Hang");

                        if (!Directory.Exists(uploadPath))
                        {
                            Directory.CreateDirectory(uploadPath);
                        }

                        var filePath = Path.Combine(uploadPath, fileName);

                        // Nếu file chưa tồn tại thì mới lưu
                        if (!System.IO.File.Exists(filePath))
                        {
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await AnhFile.CopyToAsync(stream);
                            }
                        }

                        // Cập nhật tên file mới
                        tblHang.Anh = fileName;
                    }
                    else
                    {
                        // Không upload ảnh → giữ nguyên ảnh cũ
                        tblHang.Anh = hangCu.Anh;
                    }
                    _context.Update(tblHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblHangExists(tblHang.MaHang))
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
            ViewData["MaChatLieu"] = new SelectList(_context.TblChatlieus, "MaChatLieu", "MaChatLieu", tblHang.MaChatLieu);
            return View(tblHang);
        }

        // GET: TblHangs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblHang = await _context.TblHangs
                .Include(t => t.MaChatLieuNavigation)
                .FirstOrDefaultAsync(m => m.MaHang == id);
            if (tblHang == null)
            {
                return NotFound();
            }

            return View(tblHang);
        }

        // POST: TblHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tblHang = await _context.TblHangs.FindAsync(id);
            if (tblHang != null)
            {
                _context.TblHangs.Remove(tblHang);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblHangExists(string id)
        {
            return _context.TblHangs.Any(e => e.MaHang == id);
        }
    }
}
