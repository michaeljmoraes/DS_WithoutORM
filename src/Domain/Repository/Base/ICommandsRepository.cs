using Core.DomainObjects;

namespace Domain.Repository.Base
{
    public interface ICommandsRepository<T> : IDisposable where T : IAggregateRoot
    {
        T Insert(T entity);
        T Update(T entity);
        int Delete(int id);

    }

}
