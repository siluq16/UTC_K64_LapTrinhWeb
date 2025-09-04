using Microsoft.AspNetCore.Mvc;

namespace WebApp22_08.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(int id)
        {
            ViewBag.Product = "Chi tiết sản phẩm có ID = " + id;
            return View();
        }
    }
}
