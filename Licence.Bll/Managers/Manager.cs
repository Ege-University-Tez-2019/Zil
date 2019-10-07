using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Licence.Bll.Managers.EntityManagers;
using Licence.Entity.Concrete;

namespace Licence.Bll.Managers
{
    public class Manager
    {
        public StartUserInfo StartUserInfo;
        public ProfileInfo ProfileInfo;
        public OpenLessons OpenLessons;

        public Manager()
        {
            StartUserInfo = new StartUserInfo();
            ProfileInfo = new ProfileInfo();
            OpenLessons = new OpenLessons();
        }
    } 

} 
