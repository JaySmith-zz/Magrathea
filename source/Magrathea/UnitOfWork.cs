using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using Magrathea.Interfaces;

namespace Magrathea
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _context;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public T Add<T>(T item) where T : class
        {
            _context.Set<T>().Add(item);
            return item;
        }

        public T Remove<T>(T item) where T : class
        {
            _context.Set<T>().Remove(item);
            return item;
        }

        public T Update<T>(T item) where T : class
        {
            DbEntityEntry<T> entry = GetChangeTrackingEntry(item);
            if (entry == null)
            {
                throw new InvalidOperationException(
                    "Cannot Update an object that is not attacched to the current Entity Framework data context");
            }
            entry.State = EntityState.Modified;
            return item;
        }

        public T Reload<T>(T item) where T : class
        {
            DbEntityEntry<T> entry = GetChangeTrackingEntry(item);
            if (entry == null)
            {
                throw new InvalidOperationException(
                    "You cannot reload an objecct that is not in the current Entity Framework datya context");
            }
            entry.Reload();
            return item;
        }

        public int Commit()
        {
            _context.ChangeTracker.DetectChanges();
            int result = _context.SaveChanges();
            return result;
        }

        protected virtual DbEntityEntry<T> GetChangeTrackingEntry<T>(T item) where T : class
        {   
            DbEntityEntry<T> entry = _context.Entry(item);
            return entry;
        }
    }
}