using _1911065701_LeHuuVang_BigSchool.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _1911065701_LeHuuVang_BigSchool.ViewModels
{
    public class CourseViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Place { get; set; }
        [Required]
        [FutureDate]
        public string Date { get; set; }
        [Required]
        [ValidTime]
        public string Time { get; set; }
        [Required]
        public byte Category { get; set;}
        public IEnumerable<Category> Categories { get; set; }
        public string Heading { get; set; }
        public string Action
        {
            get { return (Id != 0) ? "Update" : "Create"; }
        }
        //public IEnumerable<Course> UpcommingCourses { get; set; }
        //public bool ShowAction { get; set; }
       // public IEnumerable<Following> Followings { get; set; }
       // public IEnumerable<Attendance> Attendances { get; set; }
        public DateTime GetDataTime()
        {        
            return DateTime.Parse(String.Format("{0} {1}", Date , Time));           
        }
    }
}

