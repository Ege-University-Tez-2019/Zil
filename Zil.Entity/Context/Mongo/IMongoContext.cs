using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Zil.Entity.Context.Mongo
{
    public interface IMongoContext
    {
        void AddCommand(Func<Task> func);
        int SaveChanges();
        IMongoCollection<T> GetCollection<T>(string name);
        void Dispose();
    }
}
