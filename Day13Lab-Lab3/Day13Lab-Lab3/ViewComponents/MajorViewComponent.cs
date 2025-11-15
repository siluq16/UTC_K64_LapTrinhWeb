using Microsoft.AspNetCore.Mvc;
using Day13Lab_Lab3.Models;
namespace Day13Lab_Lab3.ViewComponents
{
    public class MajorViewComponent : ViewComponent
    {
        private readonly Models.SchoolDbContext _context;
        List<Major> majors;
        public MajorViewComponent(Models.SchoolDbContext context)
        {
            _context = context;
            majors = context.Majors.ToList();
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var majors = await Task.FromResult(_context.Majors.ToList());
            return View(majors);
        }
    }
}
