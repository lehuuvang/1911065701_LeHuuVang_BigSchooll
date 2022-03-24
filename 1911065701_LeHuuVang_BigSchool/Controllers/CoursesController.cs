using _1911065701_LeHuuVang_BigSchool.Models;
using _1911065701_LeHuuVang_BigSchool.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1911065701_LeHuuVang_BigSchool.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public CoursesController()
        {
            _dbContext = new ApplicationDbContext();
        }
        
        [Authorize]
        public ActionResult Create(CourseViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = _dbContext.Categories.ToList();
                return View("Create", viewModel);
            }
            var course = new Course
            {
                 LecturerId = User.Identity.GetUserId(),
                 DateTime = viewModel.GetDataTime(),
                 CategoryId = viewModel.Category,
                 Place =viewModel.Place
            };
            _dbContext.Courses.Add(course);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}