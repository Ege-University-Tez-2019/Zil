using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Zil.Client;
using Zil.Entity.Concrete;
using Zil.Repository.UnitOfWork;
using Zil.UI.Models;

namespace Zil.UI.Controllers
{
    public class UserSettingController : Controller
    {
        UnitOfWork _unitOfWork = new UnitOfWork();
        public IActionResult Index()
        {


            return View();
        }

        public IActionResult UserSetting()
        {
            var tempUserId = Settings.cache.Get("UserId");

            var userSettingInfo = _unitOfWork.UserSettings.Find(x => x.UserId == tempUserId);

            ViewData.Model = new UserSettingModel
            {
                UserId = userSettingInfo.UserId,
                UserName = userSettingInfo.UserName,
                UserDescription = userSettingInfo.UserDescription,
                UserAdress = userSettingInfo.UserAdress,
                UserCountry = userSettingInfo.UserCountry,
                UserJob = userSettingInfo.UserJob,
                UserLinkedin = userSettingInfo.UserLinkedin,
                UserSchool = userSettingInfo.UserSchool,
                UserTwitter = userSettingInfo.UserTwitter,
                UserWebSite = userSettingInfo.UserWebSite,
                UserYoutube = userSettingInfo.UserYoutube,
                BirthDay = userSettingInfo.BirthDay,
                Email = userSettingInfo.Email,
                Gender = userSettingInfo.Gender,
                Telephone = userSettingInfo.Telephone,
            };




            return View();
        }


        public IActionResult UserUpdate(string UserName, string Job, string Telephone, string Email, string DateOfBirth, string Gender, string About, string School, string Country, string Address, string Site, string Twitter, string Linkedin, string Youtube)
        {

            try
            {

                var tempUserId = Settings.cache.Get("UserId");
                  
                tbl_UserSettings user = _unitOfWork.UserSettings.Find(x => x.UserId == tempUserId);

                user.UserName = UserName;
                user.UserJob = Job;
                user.Telephone = Telephone;
                user.BirthDay = DateOfBirth;
                user.Gender = Gender;
                user.Email = Email;
                user.UserAdress = Address;
                user.UserDescription = About;
                user.UserCountry = Country;
                user.UserLinkedin = Linkedin;
                user.UserSchool = School;
                user.UserTwitter = Twitter;
                user.UserWebSite = Site;
                user.UserYoutube = Youtube;


                     

                _unitOfWork.UserSettings.Update(user);
                _unitOfWork.Save();

                var status = new { operation = "Success" };

                return Content(JsonConvert.SerializeObject(status), "application/json");








            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}