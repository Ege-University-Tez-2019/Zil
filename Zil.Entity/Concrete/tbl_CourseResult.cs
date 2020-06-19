using System;
using System.Collections.Generic;
using System.Text;

namespace Zil.Entity.Concrete
{
    public class tbl_CourseResult
    {
        public int id { get; set; }
        public string KursVerenId { get; set; }
        public List<string> kursalanlarID { get; set; }
        public int Score { get; set; }
        public int hangiKurs { get; set; }
    }
}
