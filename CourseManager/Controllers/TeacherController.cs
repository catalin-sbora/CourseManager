using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        // GET: Teacher
        public ActionResult Index()
        {
            var userId = userManager.GetUserId(User);
            var teacher = teachersService.GetTeacherByUserId(userId);
            var teacherCourses = teachersService.GetTeacherCourses(userId);

            return View(new TeacherCoursesViewModel { Teacher = teacher, Courses = teacherCourses});
        }

        
       
    }
}