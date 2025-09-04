using Microsoft.AspNetCore.Mvc;

namespace WebApp22_08.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Customers = new List<string> { "Nguyễn Văn A", "Nguyễn Thị B", "Lê Văn C" };
            return View();
        }

        public IActionResult Detail(int id)
        {
            ViewBag.Customer = "Thông tin chi tiết khách hàng có ID = " + id;
            return View();
        }
    }
}
