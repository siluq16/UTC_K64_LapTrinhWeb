using Day06.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace Day06.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static List<Student> listStudents = new List<Student>();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View(listStudents);
        }

        [HttpGet]
        public IActionResult Create()
        {
            LoadDataForView();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student s)
        {
            if (ModelState.IsValid)
            {
                s.Id = listStudents.LastOrDefault()?.Id + 1 ?? 1;
                listStudents.Add(s);
                return View("Index", listStudents);
            }

            LoadDataForView();
            return View(s);
        }

        private void LoadDataForView()
        {
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();

            ViewBag.AllBranches = new List<SelectListItem>
        {
            new SelectListItem { Text = "IT", Value = "1" },
            new SelectListItem { Text = "BE", Value = "2" },
            new SelectListItem { Text = "CE", Value = "3" },
            new SelectListItem { Text = "EE", Value = "4" }
        };
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
