using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Zil.Entity.Concrete
{
    [Table("tbl_LoginUsers")]
    public class tbl_Courses
    {
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string _id { get; set; } = ObjectId.GenerateNewId().ToString();
        public string CreatedUserId { get; set; }
        public string CreatedUserName { get; set; }
        [StringLength(250)]
        public string CourseTitle { get; set; }
        [StringLength(250)]
        public string CourseSubtitle { get; set; }
        public string CourseDescription { get; set; }
        public string CourseLanguage { get; set; }
        public string CourseCategory { get; set; }


        public string CoursePrecondition { get; set; }
        public string CourseLevel { get; set; }
        public string CoursePlatform { get; set; }
        public string CourseHumanCount { get; set; }
        public string CountryId { get; set; }
        public string StateId { get; set; }
        public string CityId { get; set; }
        public string CourseArea { get; set; }
        public string CourseAreaAdress { get; set; }
        public string CourseHumanCountOne { get; set; }
        public string CourseLink { get; set; }
        public string Price { get; set; }
 

    }
}
