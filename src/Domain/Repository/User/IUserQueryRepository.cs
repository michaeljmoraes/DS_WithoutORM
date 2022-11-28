using Domain.Models;
using Domain.Repository.Base;

namespace Domain.Repository.User
{
    public interface IUserQueryRepository : IQueryRepository<UserProfile>
    {
        Task<UserProfile?> GetByUserNameAsync(string userName);
    }
}
