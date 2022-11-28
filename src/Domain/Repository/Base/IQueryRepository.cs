using Core.DomainObjects;

namespace Domain.Repository.Base
{
    public interface IQueryRepository<T> : IDisposable where T : IAggregateRoot
    {
        Task<T?> GetAsync(int id);
        Task<IEnumerable<T>?> GetAllAsync();
    }

}
