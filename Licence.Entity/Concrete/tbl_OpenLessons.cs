using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licence.Entity.Concrete
{
    [Table("tbl_OpenLessons")]
    public class tbl_OpenLessons
    {
        [Key]
        public int ID { get; set; }

        public int NumberofRecords { get; set; }
        public string LessonInfo { get; set; }
        public string LessonCreateUser { get; set; }
    }
}
