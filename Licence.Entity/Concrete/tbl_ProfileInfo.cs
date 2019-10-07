using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licence.Entity.Concrete
{
    [Table("tbl_ProfileInfo")]
    public class tbl_ProfileInfo
    {
        [Key]
        public int ID { get; set; }

        //Uzmanlık Alanı
        public string Expertise { get; set; }
        //İlgi Alanı
        public string Interest { get; set; }

        public string SchoolInfo { get; set; }

        public string BusinessInfo { get; set; }
        public float Balance { get; set; }

        public bool IsBanned { get; set; }

    }
}
