using System;
using System.Collections.Generic;
using System.Text;
using Zil.Entity.Concrete;
using Zil.Entity.Context.Mongo;
using Zil.Repository.Interfaces;

namespace Zil.Repository.Repositories.Mongo
{
    public class UserSettingsMongoRepository : MongoRepository<tbl_UserSettings>, IUserSettings
    {
        public UserSettingsMongoRepository(IMongoContext context) : base(context)
        {
        }
    }
}

 
