using System;
using System.Collections.Generic;
using System.Text;
using Zil.Entity.Concrete;
using Zil.Entity.Context.Mongo;
using Zil.Repository.Interfaces;

namespace Zil.Repository.Repositories.Mongo
{
    public class LoginUsersMongoRepository : MongoRepository<tbl_LoginUsers>, ILoginUsers
    {
        public LoginUsersMongoRepository(IMongoContext context) : base(context)
        {

        }
    }
}
