using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Zil.Client;

namespace Zil.UI.Controllers
{
    public class LogOutController : Controller
    {
        public IActionResult SignOut(bool SignOut)
        {
            if(SignOut == true)
            {
                Settings.cache.Remove("UserName");
                Settings.cache.Remove("UserId");
                Settings.cache.Remove("UserEmail");

                var status = new { operation = "Success" };

                return Content(JsonConvert.SerializeObject(status), "application/json");
            }

             

            return Content(JsonConvert.SerializeObject("Wrong"), "application/json");

        }
    }
}