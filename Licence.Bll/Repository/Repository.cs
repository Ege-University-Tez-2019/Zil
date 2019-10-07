 
using Licence.Bll.Interfaces;
using Licence.Dal.DBContext; 
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq; 
using System.Linq.Expressions; 
using System.Linq.Dynamic;

namespace Licence.Bll.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private DatabaseContext _context;
        private DbSet<T> _dbset;

        public Repository()
        {
            _context = new DatabaseContext();
            _dbset = _context.Set<T>();
        }
        public Repository(DatabaseContext objectContext)
        {
            _context = objectContext;
            _dbset = _context.Set<T>();
        }
        public void Delete(object EntityID)
        {
            T Entity = _dbset.Find(EntityID);
            Delete(Entity);
            Save();
        }

        public void Delete(T Entity)
        {
            if (_context.Entry(Entity).State == EntityState.Detached)//Eş zamanlı işlem kontrolü
            {
                _dbset.Attach(Entity);
            }
            _dbset.Remove(Entity);
            Save();
        }

        public T GetByID(object EntityID)
        {
            return _dbset.Find(EntityID);
        }


        public void Insert(T Entity)
        {
            _dbset.Add(Entity);
            Save();
        }

        public IEnumerable<T> Select(Expression<Func<T, bool>> Filter = null)
        {
            if (Filter != null)
            {
                return _dbset.Where(Filter);
            }
            return _dbset;
        }

        public void Update(T Entity)
        {
            _dbset.Attach(Entity);
            _context.Entry(Entity).State = EntityState.Modified;
            Save();
        }

        public ICollection<T> GetAll()
        {
            return _dbset.AsEnumerable<T>().ToList();

        }
        public List<T> GetList()
        {
            return _dbset.ToList();
        }
        public void Save()
        {
            _context.SaveChanges();

        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return _dbset.FirstOrDefault(where);
        }
        public T Last(Expression<Func<T, bool>> where)
        {
            return _dbset.LastOrDefault(where);
        }

        public bool Any(Expression<Func<T, bool>> where)
        {
            return _dbset.Any(where);
        }

        public List<T> Where(Expression<Func<T, bool>> where)
        {
            return _dbset.Where(where).ToList();
        }

        public void DeleteListEntity(List<T> Entity)
        {
            _dbset.RemoveRange(Entity);
            Save();
        }

        public void InsertListEntity(List<T> Entity)
        {

            _dbset.AddRange(Entity);
            Save();
        }

        public IEnumerable<T> WhereDynamicLinq(string query, string[] filterItems)
        {
            return _dbset.Where(query, filterItems).ToList(); 
        }

        public IEnumerable<T> WhereDynamicLinqString(string query)
        {
            /*_dbset.Where(query).ToList();*/
            return _dbset.Where(query).ToList();
        }


        public T First()
        {
            return _dbset.FirstOrDefault();

        }

        public IQueryable<T> OrderBy<TKey>(Expression<Func<T, TKey>> orderBy, bool isDesc)
        {
            if (isDesc)
                return _dbset.OrderByDescending(orderBy);
            return _dbset.OrderBy(orderBy);
        }

        public IEnumerable<T> WhereAndDynamicLinqString(Expression<Func<T, bool>> where, string query)
        {
            return _dbset.Where(where).Where(query).ToList();
        }
    }
}
