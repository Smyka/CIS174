using Microsoft.AspNetCore.Mvc;
using Student.Models;

namespace MitchellResponsiveWebAppSmyka.Controllers
{
    public class AssignmentController : Controller
    {
        public IActionResult Level(int id)
        {
            int level = id;
            if (level < 1 || level > 10)
            {
                return Content("Access level out of range");
            }
            if (level <= 2)
            {
                return Content("You do not have a sufficient access level to view this data.");
            }

            var studentsList = new List<StudentModel>
            {
                new StudentModel{FirstName = "Mitch", LastName = "Smyka", Grade = 81},
                new StudentModel{FirstName = "Johnny", LastName = "Craig", Grade = 78},
                new StudentModel{FirstName = "Terry", LastName = "Crews", Grade = 95}
            };

            ViewBag.Level = level;
            ViewBag.Students = studentsList;
            return View();
        }
    }
}
