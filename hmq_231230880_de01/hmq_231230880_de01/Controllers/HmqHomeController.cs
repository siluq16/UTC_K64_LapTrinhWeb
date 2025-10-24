using System.Diagnostics;
using hmq_231230880_de01.Models;
using Microsoft.AspNetCore.Mvc;

namespace hmq_231230880_de01.Controllers
{
    public class HmqHomeController : Controller
    {
        private readonly ILogger<HmqHomeController> _logger;

        public HmqHomeController(ILogger<HmqHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult HmqContact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
