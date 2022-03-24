using _1911065701_LeHuuVang_BigSchool.Models;
using _1911065701_LeHuuVang_BigSchool.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Windows.Forms;

namespace _1911065701_LeHuuVang_BigSchool.Controllers
{

    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public CoursesController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Courses
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new CourseViewModel { Categories = _dbContext.Categories.ToList() };
            return View(viewModel);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Create(CourseViewModel viewModel)
        {
            try
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
                    Place = viewModel.Place
                };
                _dbContext.Courses.Add(course);
                _dbContext.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            catch(Exception EX)
            {
                return this.Create();
            }
            
        }
    }
}