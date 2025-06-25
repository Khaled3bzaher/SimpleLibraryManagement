using Microsoft.EntityFrameworkCore.Storage;

namespace SimpleLibraryManagement.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> Repository<T>() where T : class;
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
        Task<int> CompleteAsync();
    }
}
