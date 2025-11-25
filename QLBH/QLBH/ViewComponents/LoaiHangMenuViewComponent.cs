using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLBH.Models;

namespace QLBH.ViewComponents
{
    public class LoaiHangMenuViewComponent : ViewComponent
    {
        private readonly QlhangHoaContext _context;
        public LoaiHangMenuViewComponent(QlhangHoaContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loaiHangs = await _context.LoaiHangs.ToListAsync();
            return View(loaiHangs);
        }
    }
}
