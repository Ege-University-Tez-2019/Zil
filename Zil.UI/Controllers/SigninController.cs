using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Zil.Client;
using Zil.Repository.UnitOfWork;

namespace Zil.UI.Controllers
{
    public class SigninController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Logger(string Email, string Password)
        {
            UnitOfWork _unitOfWork = new UnitOfWork();

            var UserExist = _unitOfWork.LoginUsers.Find(x => x.Email == Email && x.Password == Password);



            if (UserExist != null)
            {
                Settings.cache.Set("UserName", UserExist.UserName);
                Settings.cache.Set("UserId", UserExist._id);
                Settings.cache.Set("UserEmail", UserExist.Email);
            }

            var status = new { operation = "Success" };

            return Content(JsonConvert.SerializeObject(status), "application/json");

        }
    }
}