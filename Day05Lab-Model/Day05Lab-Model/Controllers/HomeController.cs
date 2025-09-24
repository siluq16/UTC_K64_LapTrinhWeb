using System.Diagnostics;
using Day05Lab_Model.Models;
using Microsoft.AspNetCore.Mvc;


namespace Day05Lab_Model.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static List<EmployeeModel> employees = new List<EmployeeModel>
        {
            new EmployeeModel { Id = 1, FullName = "Nguyễn Văn A", Gender = "Male", Phone = "0123456789", Email = "a@gmail.com", Salary = 1000, Status = true },
            new EmployeeModel { Id = 2, FullName = "Trần Thị B", Gender = "Female", Phone = "0987654321", Email = "b@gmail.com", Salary = 1200, Status = false }
        };
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(EmployeeModel emp)
        {
            if (ModelState.IsValid)
            {
                emp.Id = employees.Max(e => e.Id) + 1;
                employees.Add(emp);
                return RedirectToAction("Index");
            }
            return View(emp);
        }

        public IActionResult Delete(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null) return NotFound();
            return View(emp);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp != null) employees.Remove(emp);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
