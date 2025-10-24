using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using hmq_231230880_de01.Models;

namespace hmq_231230880_de01.Controllers
{
    public class HmqComputersController : Controller
    {
        private readonly HoangManhQuan231230880De01Context _context;

        public HmqComputersController(HoangManhQuan231230880De01Context context)
        {
            _context = context;
        }

        // GET: HmqComputers
        public async Task<IActionResult> Index()
        {
            return View(await _context.HmqComputers.ToListAsync());
        }

        // GET: HmqComputers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hmqComputer = await _context.HmqComputers
                .FirstOrDefaultAsync(m => m.HmqComId == id);
            if (hmqComputer == null)
            {
                return NotFound();
            }

            return View(hmqComputer);
        }

        // GET: HmqComputers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HmqComputers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HmqComId,HmqComName,HmqComPrice,HmqComImage,HmqComStatus")] HmqComputer hmqComputer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hmqComputer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hmqComputer);
        }

        // GET: HmqComputers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hmqComputer = await _context.HmqComputers.FindAsync(id);
            if (hmqComputer == null)
            {
                return NotFound();
            }
            return View(hmqComputer);
        }

        // POST: HmqComputers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HmqComId,HmqComName,HmqComPrice,HmqComImage,HmqComStatus")] HmqComputer hmqComputer)
        {
            if (id != hmqComputer.HmqComId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hmqComputer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HmqComputerExists(hmqComputer.HmqComId))
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
            return View(hmqComputer);
        }

        // GET: HmqComputers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hmqComputer = await _context.HmqComputers
                .FirstOrDefaultAsync(m => m.HmqComId == id);
            if (hmqComputer == null)
            {
                return NotFound();
            }

            return View(hmqComputer);
        }

        // POST: HmqComputers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hmqComputer = await _context.HmqComputers.FindAsync(id);
            if (hmqComputer != null)
            {
                _context.HmqComputers.Remove(hmqComputer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HmqComputerExists(int id)
        {
            return _context.HmqComputers.Any(e => e.HmqComId == id);
        }
    }
}
