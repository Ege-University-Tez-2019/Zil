using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Zil.Entity.Context.Mongo;

namespace Zil.Repository
{
    public abstract class MongoRepository<T> : IRepository<T> where T : class
    {

        protected readonly IMongoContext Context;
        protected IMongoCollection<T> DbSet;

        protected MongoRepository(IMongoContext context)
        {
            Context = context;
        }
        public T GetByID(string _id)
        {

            ConfigDbSet();
            var data = DbSet.Find(Builders<T>.Filter.Eq("_id", _id));
            return data.SingleOrDefault();
        }
        public void AddRange(IEnumerable<T> Entities)
        {

            ConfigDbSet();

            DbSet.InsertMany(Entities);

        }

        public bool Any(Expression<Func<T, bool>> where)
        {

            ConfigDbSet();
            var Data = (T)this.Where(where).FirstOrDefault();
            if (Data != null) { return true; }
            else { return false; }
        }

        public void Delete(T Entity)
        {
            ConfigDbSet();
            object _id = Entity.GetType().GetProperty("_id").GetValue(Entity);
            DbSet.DeleteOne(Builders<T>.Filter.Eq("_id", _id));

        }

        public void DeleteListEntity(List<T> Entity)
        {
            ConfigDbSet();
            if (Entity != null)
            {
                for (int i = 0; i < Entity.Count; i++)
                {
                    object _id = Entity[i].GetType().GetProperty("_id").GetValue(Entity[i]);
                    DbSet.DeleteMany(Builders<T>.Filter.Eq("_id", _id));
                }
            }

        }

        public void Dispose()
        {
            Context?.Dispose();
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            ConfigDbSet();

            return (T)this.Where(where).FirstOrDefault();
        }

        public T First()
        {
            ConfigDbSet();
            var firstOrDefault = DbSet.Find(Builders<T>.Filter.Empty).ToList();
            return (T)firstOrDefault.FirstOrDefault();
        }

        public T FirstOrDefault(Expression<Func<T, bool>> where)
        {
            ConfigDbSet();
            return (T)this.Where(where).FirstOrDefault();

        }

        public ICollection<T> GetAll()
        {
            ConfigDbSet();
            var all = DbSet.Find(Builders<T>.Filter.Empty);
            return all.ToList();
        }

        public List<T> GetList()
        {
            ConfigDbSet();
            var all = DbSet.Find(Builders<T>.Filter.Empty);
            return all.ToList();
        }

        public void Insert(T Entity)
        {

            ConfigDbSet();
            DbSet.InsertOne(Entity);
        }

        public void InsertListEntity(List<T> Entity)
        {
            ConfigDbSet();
            for (int i = 0; i < Entity.Count; i++)
            {
                DbSet.InsertOne(Entity[i]);
            }

        }

        public T LastOrDefault(Expression<Func<T, bool>> where)
        {
            ConfigDbSet();
            var firstOrDefault = DbSet.Find(where).ToList();
            return (T)firstOrDefault.LastOrDefault();
        }

        public IQueryable<T> OrderBy<TKey>(Expression<Func<T, TKey>> orderBy, bool isDesc)
        {
            ConfigDbSet();
            var all = DbSet.Find(Builders<T>.Filter.Empty).ToList();
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<T> Entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Select(Expression<Func<T, bool>> Filter = null)
        {
            throw new NotImplementedException();
        }

        public T Single()
        {

            ConfigDbSet();
            var data = DbSet.Find(Builders<T>.Filter.Empty);

            return data.SingleOrDefault();
        }

        public T SingleOrDefault(Expression<Func<T, bool>> where)
        {
            throw new NotImplementedException();
        }

        public void Update(T Entity)
        {
            ConfigDbSet();
            //Builders<T>.Update.AddToSet("_id", Entity.GetObjectId()); 
            object _id = Entity.GetType().GetProperty("_id").GetValue(Entity);
            DbSet.ReplaceOne(Builders<T>.Filter.Eq("_id", _id), Entity);

        }

        public void UpdateRange(List<T> Entities)
        {
            ConfigDbSet();

            for (int i = 0; i < Entities.Count; i++)
            {
                object _id = Entities[i].GetType().GetProperty("_id").GetValue(Entities[i]);

                DbSet.ReplaceOne(Builders<T>.Filter.Eq("_id", _id), Entities[i]);

            }
        }

        public List<T> Where(Expression<Func<T, bool>> where)
        {
            ConfigDbSet();
            var all = DbSet.Find(where);
            return all.ToList();
        }

        public IEnumerable<T> WhereAndDynamicLinqString(Expression<Func<T, bool>> where, string query)
        {
            throw new NotImplementedException();
        }
      

        public IEnumerable<T> WhereDynamicLinqString(string query, string columnName, List<string> filterList, Func<T, bool> where)
        {
            ConfigDbSet();
            //var d = DbSet.Find(where);
            //var filter = d.Filter.(columnName, filterList);
            //var all2 = d.ToList().Find(filter);
            //---------------------------------------------
            var filter = Builders<T>.Filter.In(columnName, filterList);
            var all2 = DbSet.Find(filter);
            //---------------------------------------------
            return all2.ToList().Where(where);
            //var all2 = DbSet.Find(query).ToList().Where(where);
            //var all2 = DbSet.Find(where).ToList();
            //var filter = all2.Where(Builders<T>.Filter.In(columnName, filterList)).ToList();
        }

        private void ConfigDbSet()
        {
            DbSet = Context.GetCollection<T>(typeof(T).Name);
        }

        public IMongoCollection<T> TableChanged()
        {
            ConfigDbSet();
            return DbSet;
        }

        [Obsolete]
        public int Count(Expression<Func<T, bool>> where, FilterDefinition<T> filter)
        {
            throw new NotImplementedException();
        }

        public List<T> AsQueryable(Expression<Func<T, bool>> predicate)
        {
            return DbSet.AsQueryable().Where(predicate).ToList();
        }

        public List<T> Contains(string MongoColumnName, string MongoValue, Expression<Func<T, bool>> Sqlpredicate)
        {
            throw new NotImplementedException();
        }


    }
}
