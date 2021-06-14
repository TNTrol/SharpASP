using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Faculty.EF;
using Faculty.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Faculty.Repositories
{
    
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationContext _db;
        private readonly DbSet<T> _entities;

        public Repository(ApplicationContext context)
        {
            _db = context;
            _entities = context.Set<T>();
        }
        public void Create(T item)
        {
            _entities.Add(item);
            _db.SaveChanges();
            
        }

        public void Delete(int id)
        {
            _entities.Remove(Get(id));
            _db.SaveChanges();
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return _entities.Where(predicate);
        }

        public T Get(int id)
        {
            return _entities.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.ToList();
        }

        public void Update(T item)
        {
            _db.Entry<T>(item).State = EntityState.Modified;
            _db.SaveChanges();
        }
        public IEnumerable<T> FindInclude(Func<T, bool> predicate, params Expression<Func<T, object>>[] includes)
        {
            var query = _entities.AsQueryable();
            return includes.Aggregate(query, (q, w) => q.Include(w)).Where(predicate);
        }
    }
}