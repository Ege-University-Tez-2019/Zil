using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Licence.Bll.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T GetByID(object EntityID);
        IEnumerable<T> Select(Expression<Func<T, bool>> Filter = null);
        T First();


        void Insert(T Entity);
        void Update(T Entity);
        void Delete(object EntityID);
        void Delete(T Entity);
        void DeleteListEntity(List<T> Entity);
        void InsertListEntity(List<T> Entity);
        ICollection<T> GetAll();
        T Find(Expression<Func<T, bool>> where);
        T Last(Expression<Func<T, bool>> where);
        bool Any(Expression<Func<T, bool>> where);
        List<T> GetList();
        List<T> Where(Expression<Func<T, bool>> where);
        IEnumerable<T> WhereDynamicLinq(string query, string[] filterItems);
        IEnumerable<T> WhereDynamicLinqString(string query);
        IEnumerable<T> WhereAndDynamicLinqString(Expression<Func<T, bool>> where, string query);

        IQueryable<T> OrderBy<TKey>(Expression<Func<T, TKey>> orderBy, bool isDesc);
    }
}
