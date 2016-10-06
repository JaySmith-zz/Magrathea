using System.Collections.Generic;
using System.Threading.Tasks;

namespace Magrathea.Interfaces
{
    public interface IRepository
    {
        IEnumerable<T> Find<T>(IQuery<T> query);
        T Find<T>(IScalar<T> query);
        void Execute(ICommand command);
        Task ExecuteAsync(ICommand command);
        Task<T> FindAsync<T>(IScalar<T> query);
        Task<IEnumerable<T>> FindAsync<T>(IQuery<T> query);
        Task<IEnumerable<IProjection>> FindAsync<TSelection, IProjection>(IQuery<TSelection, IProjection> query) where TSelection : class;
        IUnitOfWork Context { get; }
    }
}