using System.Data.Entity;
using System.Linq;

namespace Magrathea
{
    public static class DbContextExtensions
    {
        public static IQueryable<T> AsQueryable<T>(this DbContext dbContext) where T : class
        {
            return dbContext.Set<T>();
        }
    }
}