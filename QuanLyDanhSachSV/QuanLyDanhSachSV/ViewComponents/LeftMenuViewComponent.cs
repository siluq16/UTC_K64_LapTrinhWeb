using Microsoft.AspNetCore.Mvc;
using QuanLyDanhSachSV.Models;

namespace QuanLyDanhSachSV.ViewComponents
{
    public class LeftMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var menuItems = new List<MenuItem>
            {
                new MenuItem { Id = 1, Name = "Home", Link = Url.Action("Index", "Home") },
                new MenuItem { Id = 2, Name = "Sinh viên", Link = "/Admin/Student/List" },
                new MenuItem { Id = 3, Name = "Privacy", Link = Url.Action("Privacy", "Home") },
            };

            return View(menuItems); 
        }
    }
}
