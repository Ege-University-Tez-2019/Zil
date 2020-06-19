using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Newtonsoft.Json;
using Zil.Entity.Concrete;
using Zil.Repository.UnitOfWork;

namespace Zil.UI.Controllers
{
    public class SignUpController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Signing(string UserName, string Email, string Password,string Phone)
        {
            UnitOfWork _unitOfWork = new UnitOfWork();

            var userId = ObjectId.GenerateNewId().ToString();

            tbl_LoginUsers _user = new tbl_LoginUsers
            {
                _id = userId,
                UserName = UserName,
                Email = Email,
                Password = Password,
                Telephone = Phone, 
            }; 
             
            tbl_UserSettings _userSetting = new tbl_UserSettings
            {
                UserName = UserName,
                UserId = userId,   
                Telephone = Phone,
                Email = Email
            };
             
            _unitOfWork.LoginUsers.Insert(_user);
            _unitOfWork.UserSettings.Insert(_userSetting);
            _unitOfWork.Save();

            var status = new { operation = "Success" };

            return Content(JsonConvert.SerializeObject(status), "application/json");

        }
    }

}