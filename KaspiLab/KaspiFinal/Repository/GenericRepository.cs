using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using AdventureWorksModel;

namespace KaspiFinal.Repository
{
    class GenericRepository<T> : IRepository<T> where T : class
    {
        AdventureWorks _context;
        DbSet<T> _dbSet;

        public GenericRepository()
        {
            _context = new AdventureWorks();
            _dbSet = _context.Set<T>();
        }


        public void Create(T item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }

        public T Get(int id)
        {
            return _dbSet.Find(id);
        }

        public void Update(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IQueryable<T> GetList()
        {
            return _dbSet.AsNoTracking();
        }

        public IQueryable<T> GetList(Func<T, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).AsQueryable<T>();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Remove(T item)
        {
            _dbSet.Remove(item);
            _context.SaveChanges();
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                    _context.Dispose();
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}
