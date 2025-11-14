using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Day13Lab_Lab3.Models;
using System.Collections.Generic;
using System.IO;         
using System.Linq;
using System;           
using System.Threading.Tasks;  

namespace Day13Lab_Lab3.Controllers
{
    [Route("Admin/Student")]
    public class StudentController : Controller
    {
        private List<Student> listStudents = new List<Student>();
        public StudentController()
        {
            if (!listStudents.Any()) 
            {
                listStudents = new List<Student>()
                {
                    new Student() { Id = 101, Name = "Hoàng Quân", Branch = Branch.IT, Gender = Gender.Male, IsRegular = true, Address = "Hà Nội", Email = "siluq.quan.1609@gmail.com", DateOfBorth = new DateTime(2005, 8, 13), ImagePath="/images/bo3baothu.jpeg" },
                    new Student() { Id = 102, Name = "Nguyễn Thị Lan", Branch = Branch.BE, Gender = Gender.Female, IsRegular = true, Address = "Hà Nội", Email = "lan@gmail.com", DateOfBorth= new DateTime(2004, 5, 21), ImagePath="/images/bo3baothu.jpeg" },
                    new Student() { Id = 103, Name = "Trần Văn Nam", Branch = Branch.CE, Gender = Gender.Male, IsRegular = false, Address = "Hà Nội", Email = "nam@gmail.com", DateOfBorth = new DateTime(2005, 3, 15), ImagePath="/images/bo3baothu.jpeg" },
                    new Student() { Id = 104, Name = "Lê Thị Hương", Branch = Branch.EE, Gender = Gender.Female, IsRegular = true, Address = "Hà Nội", Email = "huong@gmail.com", DateOfBorth = new DateTime(2004, 11, 30), ImagePath="/images/bo3baothu.jpeg" }
                };
            }
        }
        [Route("List")]
        public IActionResult Index()
        {
            return View(listStudents);
        }

        [Route("Add")]
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem { Value = "IT", Text = "Công nghệ thông tin" },
                new SelectListItem { Value = "BE", Text = "Kinh tế" },
                new SelectListItem { Value = "CE", Text = "Công trình" },
                new SelectListItem { Value = "EE", Text = "Điện, Điện tử" }
            };
            return View();
        }
        [Route("Add")]
        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
                ViewBag.AllBranches = new List<SelectListItem>()
                {
                    new SelectListItem { Value = "IT", Text = "Công nghệ thông tin" },
                    new SelectListItem { Value = "BE", Text = "Kinh tế" },
                    new SelectListItem { Value = "CE", Text = "Công trình" },
                    new SelectListItem { Value = "EE", Text = "Điện, Điện tử" }
                };

                return View(student);
            }

            // Nếu có upload ảnh
            if (student.Avatar != null)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                var filePath = Path.Combine(uploadsFolder, student.Avatar.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await student.Avatar.CopyToAsync(stream);
                }

                student.ImagePath = "/images/" + student.Avatar.FileName;
            }

            student.Id = listStudents.Max(st => st.Id) + 1;
            listStudents.Add(student);

            return RedirectToAction("Index");
        }
    }
}
