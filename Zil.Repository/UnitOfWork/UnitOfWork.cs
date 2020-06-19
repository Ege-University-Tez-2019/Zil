using System;
using System.Collections.Generic;
using System.Text;
using Zil.Entity;
using Zil.Entity.Context.Mongo;
using Zil.Repository.Interfaces;
using Zil.Repository.Repositories.Mongo;

namespace Zil.Repository.UnitOfWork
{
    public class UnitOfWork
    {
        private bool disposed = false;
        public ILoginUsers LoginUsers { get; }
        public ICourses Courses { get; }
        public IInstructors Instructors { get; }
        public IUserSettings UserSettings { get; }
        private readonly IMongoContext _mongoContext;

        public UnitOfWork()
        {
            if(DatabaseSelection.DatabaseType == DbType.Mongo())
            {
                _mongoContext = new MongoContext();
                LoginUsers = new LoginUsersMongoRepository(_mongoContext);
                Courses = new CoursesMongoRepository(_mongoContext);
                Instructors = new InstructorMongoRepository(_mongoContext);
                UserSettings = new UserSettingsMongoRepository(_mongoContext);
            }
            else
            {

            }
        }
        public void Dispose()
        {
            if (DatabaseSelection.DatabaseType == DbType.Mongo())
            {
                _mongoContext.Dispose();
            }
            else
            { 
            }


        }
        public int Save()
        {
            if (DatabaseSelection.DatabaseType == DbType.Mongo())
            {
                return 1;
            }
            else
            {
                return 0;
            }

        }

        public object Entity<T>()
        {
            throw new NotImplementedException();
        }
    }
}
