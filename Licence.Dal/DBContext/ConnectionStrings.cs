using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licence.Dal.DBContext
{
    public class ConnectionStrings
    {
        public static string MyComputerLocal(string IpAdress = "DESKTOP-E7UQEPA", string DatabaseName = "db_LicencePage", string UserName = "sa", string Password = "Mersin.acer33")
        {
            return @"Data Source=" + IpAdress + "; Initial Catalog=" + DatabaseName + "; Persist Security Info=True;User ID=" + UserName + "; Password=" + Password + "";
        } 
    }
}
