using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using MongoDB.Bson;
using Newtonsoft.Json;
using Zil.Client;
using Zil.Entity.Concrete;
using Zil.Repository.UnitOfWork;
using Zil.UI.Models;

namespace Zil.UI.Controllers
{
    public class CreateCourseController : Controller
    {
        UnitOfWork _unitOfWork = new UnitOfWork();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Course(string CourseTitle, string CourseSubtitle, string CourseDescription, string CourseLanguage, string CourseCategory, string CoursePrecondition, string CourseLevel, string CoursePlatform, string CourseHumanCount, string CountryId, string StateId, string CityId, string CourseArea, string CourseAreaAdress, string CourseHumanCountOne, string CoursePrice)
        {
            try
            {
                var userId = Convert.ToString(Settings.cache.Get("UserId"));
                var tempName = _unitOfWork.LoginUsers.Find(x => x._id == userId).UserName;

                tbl_Courses _course = new tbl_Courses
                {
                    CourseTitle = CourseTitle,
                    CourseSubtitle = CourseSubtitle,
                    CourseDescription = CourseDescription,
                    CourseCategory = CourseCategory,
                    CourseLanguage = CourseLanguage,
                    CreatedUserId = userId,
                    CityId = CityId,
                    CountryId = CountryId,
                    CourseArea = CourseArea,
                    CourseAreaAdress = CourseAreaAdress,
                    CourseHumanCount = CourseHumanCount,
                    CourseHumanCountOne = CourseHumanCountOne,
                    CourseLevel = CourseLevel,
                    CoursePlatform = CoursePlatform,
                    CoursePrecondition = CoursePrecondition,
                    StateId = StateId,
                    Price = CoursePrice,
                    CreatedUserName = tempName,

                };
                _unitOfWork.Courses.Insert(_course);
                _unitOfWork.Save();



                tbl_Instructor _instructors = new tbl_Instructor
                {
                    _id = ObjectId.GenerateNewId().ToString(),
                    UserId = userId,
                };

                _unitOfWork.Instructors.Insert(_instructors);

                _unitOfWork.Save();
            }
            catch (Exception e)
            {

                throw;
            }



            var courseTitle = CourseTitle;


            var status = new { operation = "Success" };

            return Content(JsonConvert.SerializeObject(status), "application/json");
        }
    }


}