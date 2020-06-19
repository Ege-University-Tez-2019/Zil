using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Zil.Repository
{
    public interface IRepository<T> : IDisposable where T : class
    {
        T GetByID(string Id);
        IEnumerable<T> Select(Expression<Func<T, bool>> Filter = null); 
        IEnumerable<T> WhereDynamicLinqString(string query, string columnName, List<string> filterList, Func<T, bool> where);
        IEnumerable<T> WhereAndDynamicLinqString(Expression<Func<T, bool>> where, string query);
        void Insert(T Entity);
        void Update(T Entity);

        void Delete(T Entity);
        void DeleteListEntity(List<T> Entity);
        void InsertListEntity(List<T> Entity);
        ICollection<T> GetAll();
        T Find(Expression<Func<T, bool>> where);
        T SingleOrDefault(Expression<Func<T, bool>> where);
        T FirstOrDefault(Expression<Func<T, bool>> where);

        T LastOrDefault(Expression<Func<T, bool>> where);
        T Single();
        T First();

        bool Any(Expression<Func<T, bool>> where);
        List<T> GetList();
        List<T> Where(Expression<Func<T, bool>> where);

        void UpdateRange(List<T> Entities);
        void AddRange(IEnumerable<T> Entities);
        void RemoveRange(IEnumerable<T> Entities);
        IQueryable<T> OrderBy<TKey>(Expression<Func<T, TKey>> orderBy, bool isDesc);

        IMongoCollection<T> TableChanged();

        int Count(Expression<Func<T, bool>> where, FilterDefinition<T> filter);

        List<T> AsQueryable(Expression<Func<T, bool>> predicate);

        List<T> Contains(string MongoColumnName, string MongoValue, Expression<Func<T, bool>> Sqlpredicate);

    }
}
