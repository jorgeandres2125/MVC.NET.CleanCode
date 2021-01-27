using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Mvc.Controllers
{
    public class CourseController : Controller
    {
        private ICourseService _courseService;

        public CourseController(ICourseService courseService) 
        {
            _courseService = courseService;
        }

        private string GetHost(Microsoft.AspNetCore.Http.HttpContext context)
        {
            var host = $"{context.Request.Scheme}://{context.Request.Host}";
            return host;
        }

        public IActionResult Index()
        {
            ViewData["CurrentHost"] = GetHost(HttpContext);
            CourseViewModel model = _courseService.GetCourses();
            return View(model);
        }
    }
}