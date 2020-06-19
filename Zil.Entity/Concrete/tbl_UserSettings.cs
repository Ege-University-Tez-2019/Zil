using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Zil.Entity.Concrete
{
    [Table("tbl_UserSettings")]
    public class tbl_UserSettings
    {
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string _id { get; set; } = ObjectId.GenerateNewId().ToString();
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserJob { get; set; }
        public string UserDescription { get; set; }
        public string UserWebSite { get; set; }
        public string UserTwitter { get; set; }
        public string UserLinkedin { get; set; }
        public string UserYoutube { get; set; }
        public string UserAdress { get; set; }
        public string UserSchool { get; set; }
        public string UserCountry { get; set; } 
        public string Telephone { get; set; }  
        public string Email { get; set; }  
        public string Gender { get; set; }  
        public string BirthDay { get; set; }  


    }
}
