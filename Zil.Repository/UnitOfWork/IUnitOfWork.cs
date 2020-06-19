using System;
using System.Collections.Generic;
using System.Text;
using Zil.Repository.Interfaces;

namespace Zil.Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        object Entity<T>();

        ILoginUsers LoginUsers { get; }
        ICourses Courses { get; }
        IInstructors Instructors { get; }
        IUserSettings UserSettings { get; }

        int Save();
    }
}
