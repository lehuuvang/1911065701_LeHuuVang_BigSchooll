using _1911065701_LeHuuVang_BigSchool.Models;
using _1911065701_LeHuuVang_BigSchool.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace _1911065701_LeHuuVang_BigSchool.Controllers
{
    public class HomeController : Controller
    {

        private ApplicationDbContext _dbContext;
        
        public ActionResult Search(string timkiem)
        {
            var tk = from l in _dbContext.Courses
                     select l;
            if (!string.IsNullOrEmpty(timkiem))
            {
                tk = tk.Where(s => s.LecturerId.Contains(timkiem));
            }
            return View(tk);
        }
        public HomeController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [Authorize]
        public ActionResult Index(string timkiem)
        {
            var upcommingCourses = _dbContext.Courses
                .Include(c => c.Lecturer)
                .Include(c => c.Category)
                .Where(c => c.DateTime > DateTime.Now);
            var viewModel = new CoursesViewModel
            {
                UpcommingCourses = upcommingCourses,
                ShowAction = User.Identity.IsAuthenticated
            };
              return View(viewModel);

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}