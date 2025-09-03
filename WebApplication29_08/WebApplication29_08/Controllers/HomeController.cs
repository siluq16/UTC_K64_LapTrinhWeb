using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication29_08.Models;

namespace WebApplication29_08.Controllers
{
    public class HomeController : Controller
    {
        protected Product product = new Product();
        public IActionResult Index()
        {
            var products = product.GetProductsList();
            return View(products);
        }
    }
}
