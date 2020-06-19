using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Zil.Entity.Concrete;
using Zil.Repository.UnitOfWork;
using Zil.UI.Models;

namespace Zil.UI.Controllers
{
    public class HomeController : Controller
    {
        public static UnitOfWork _unitOfWork = new UnitOfWork();
        public List<Courses> model = new List<Courses>();
        public List<tbl_Courses> objectCourse = _unitOfWork.Courses.GetList().ToList();
        public List<tbl_LoginUsers> loginUsers = _unitOfWork.LoginUsers.GetList().ToList();

        public HomeController()
        {
            if (model.Count() == 0)
            {
                for (int i = 0; i < objectCourse.Count(); i++)
                {
                  
                    model.AddRange(new Courses[]
                                   {
                    new Courses()
                    {
                        CreatedUserId = objectCourse[i].CreatedUserId,
                        CourseTitle = objectCourse[i].CourseTitle,
                        CityId = objectCourse[i].CityId,
                        CountryId = objectCourse[i].CountryId,
                        CourseLevel = objectCourse[i].CourseLevel,
                        _id = objectCourse[i]._id,
                        CourseCategory = objectCourse[i].CourseCategory,
                        CourseLanguage = objectCourse[i].CourseLanguage,
                        CoursePlatform = objectCourse[i].CoursePlatform,
                        CoursePrecondition = objectCourse[i].CoursePrecondition,
                        CourseSubtitle = objectCourse[i].CourseSubtitle,
                        StateId = objectCourse[i].StateId,
                        CourseHumanCountOne = objectCourse[i].CourseHumanCountOne,
                         CourseHumanCount = objectCourse[i].CourseHumanCount,
                         CourseDescription = objectCourse[i].CourseDescription,
                         CourseAreaAdress = objectCourse[i].CourseAreaAdress,
                         CourseArea = objectCourse[i].CourseArea, 
                         CreatedUser = objectCourse[i].CreatedUserName,
                         Price = objectCourse[i].Price,
                    }

                   });

                    

                }

            }
        }

        public IActionResult Index()
        {
            return View(model);
        }

        public IActionResult Detail(string _id, string CreatedUserId)
        {
            var data = model.FirstOrDefault(Courses => Courses._id == _id);
            return View(data);
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
