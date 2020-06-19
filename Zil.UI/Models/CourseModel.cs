using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zil.Entity.Concrete;

namespace Zil.UI.Models
{

    public class CourseModel
    {
        public string CourseTitle { get; set; }
        public string CourseSubtitle { get; set; }
        public string CourseDescription { get; set; }
        public string CourseCategory { get; set; }
        public string CourseLanguage { get; set; } 
        
        
    }

    public class Courses
    {
        public string _id { get; set; }
        public string CourseId { get; set; }
        public string CreatedUserId { get; set; } 
        public string CourseTitle { get; set; } 
        public string CourseSubtitle { get; set; }
        public string CourseDescription { get; set; }
        public string CourseLanguage { get; set; }
        public string CourseCategory { get; set; } 
        public string CoursePrecondition { get; set; }
        public string CourseLevel { get; set; }
        public string CoursePlatform { get; set; }
        public string CourseHumanCount { get; set; }
        public string CountryId { get; set; }
        public string StateId { get; set; }
        public string CityId { get; set; }
        public string CourseArea { get; set; }
        public string CourseAreaAdress { get; set; }
        public string CourseHumanCountOne { get; set; }
        public string CreatedUser { get; set; }
        public string Price { get; set; }
    }

    public class CourseList
    {
        public List<tbl_Courses> coursesModelList { get; set; }
    }
}
