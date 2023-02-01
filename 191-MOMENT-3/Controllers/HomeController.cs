using _191_MOMENT_3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _191_MOMENT_3.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Students()
        {
            //list
            IList<Student> studentlist = new List<Student>()
            {
                new Student() {StudentID = 1, StudentName = "A", Age = 12},
                new Student() {StudentID = 2, StudentName = "B", Age = 13},
                new Student() {StudentID = 3, StudentName = "C", Age = 15},
            };

            //LINQ query
            var teenagerStudents = studentlist.Where(s => s.Age > 12).ToList<Student>();

            //pass data
            ViewData["students"] = teenagerStudents;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}