using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licence.Entity.Concrete
{
    [Table("tbl_StartUserInfo")]
    public class tbl_StartUserInfo
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int Telephone { get; set; }
        public string Password { get; set; }
    }
}      