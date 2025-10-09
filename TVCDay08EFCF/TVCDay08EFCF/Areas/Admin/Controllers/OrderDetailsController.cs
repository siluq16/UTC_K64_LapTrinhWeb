using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TVCDay08EFCF.Models;

namespace TVCDay08EFCF.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderDetailsController : Controller
    {
        private readonly DBContext _context;

        public OrderDetailsController(DBContext context)
        {
            _context = context;
        }

        // GET: Admin/OrderDetails
        public async Task<IActionResult> Index()
        {
            var dBContext = _context.OrderDetail.Include(o => o.Order).Include(o => o.Product);
            return View(await dBContext.ToListAsync());
        }

        // GET: Admin/OrderDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetail = await _context.OrderDetail
                .Include(o => o.Order)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            return View(orderDetail);
        }

        // GET: Admin/OrderDetails/Create
        public IActionResult Create()
        {
            ViewData["OrderId"] = new SelectList(_context.Order, "Id", "Id");
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id");
            return View();
        }

        // POST: Admin/OrderDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OrderId,ProductId,Quantity,Price")] OrderDetail orderDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderId"] = new SelectList(_context.Order, "Id", "Id", orderDetail.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", orderDetail.ProductId);
            return View(orderDetail);
        }

        // GET: Admin/OrderDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetail = await _context.OrderDetail.FindAsync(id);
            if (orderDetail == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = new SelectList(_context.Order, "Id", "Id", orderDetail.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", orderDetail.ProductId);
            return View(orderDetail);
        }

        // POST: Admin/OrderDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OrderId,ProductId,Quantity,Price")] OrderDetail orderDetail)
        {
            if (id != orderDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderDetailExists(orderDetail.Id))
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
            ViewData["OrderId"] = new SelectList(_context.Order, "Id", "Id", orderDetail.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", orderDetail.ProductId);
            return View(orderDetail);
        }

        // GET: Admin/OrderDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetail = await _context.OrderDetail
                .Include(o => o.Order)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            return View(orderDetail);
        }

        // POST: Admin/OrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderDetail = await _context.OrderDetail.FindAsync(id);
            if (orderDetail != null)
            {
                _context.OrderDetail.Remove(orderDetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderDetailExists(int id)
        {
            return _context.OrderDetail.Any(e => e.Id == id);
        }
    }
}
