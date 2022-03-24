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
        [Required]
        public string Place { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public string Time { get; set; }
        [Required]
        public byte Category { get; set;}
        public IEnumerable<Category> Categories { get; set; }
        public DateTime GetDataTime()
        {        
            return DateTime.Parse(String.Format("{0: dd-MM-yyyy} {1}", Date , Time));           
        }
    }
}

