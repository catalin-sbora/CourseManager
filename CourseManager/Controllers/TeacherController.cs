using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseManager.ApplicationLogic.Exceptions;
using CourseManager.ApplicationLogic.Services;
using CourseManager.Models.Teachers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CourseManager.Controllers
{
    [Authorize]
    public class TeacherController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly TeachersService teachersService;
        public TeacherController(UserManager<IdentityUser> userManager, TeachersService teachersService)
        {
            this.userManager = userManager;
            this.teachersService = teachersService;
        }
       
        public ActionResult Index()
        {
            try
            {
                var userId = userManager.GetUserId(User);
                var teacher = teachersService.GetTeacherByUserId(userId);
                var teacherCourses = teachersService.GetTeacherCourses(userId);

                foreach (var course in teacherCourses)
                {
                    course.GetStudentsWithAverageGradeGreaterThan(9.0);
                }
                return View(new TeacherCoursesViewModel { Teacher = teacher, Courses = teacherCourses });
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest("Invalid request received ");
            }
        }

        [HttpGet]
        public IActionResult AddCourse()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCourse([FromForm]TeacherAddCourseViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var userId = userManager.GetUserId(User);
                teachersService.AddCourse(userId, model.Name, model.Description);
                return Redirect(Url.Action("Index", "Teacher"));
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }

        }

        
       
    }
}