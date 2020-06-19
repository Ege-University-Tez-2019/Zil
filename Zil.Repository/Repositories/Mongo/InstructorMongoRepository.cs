using System;
using System.Collections.Generic;
using System.Text;
using Zil.Entity.Concrete;
using Zil.Entity.Context.Mongo;
using Zil.Repository.Interfaces;

namespace Zil.Repository.Repositories.Mongo
{
    public class InstructorMongoRepository : MongoRepository<tbl_Instructor>, IInstructors
    {
        public InstructorMongoRepository(IMongoContext context) : base(context)
        { 
        }
    }
}

 
