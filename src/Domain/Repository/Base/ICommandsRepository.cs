using Core.DomainObjects;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository.Base
{
    public interface ICommandsRepository<T> : IDisposable where T : IAggregateRoot
    {
        T Insert(T entity);
        T Update(T entity);
        int Delete(int id);

    }

}
