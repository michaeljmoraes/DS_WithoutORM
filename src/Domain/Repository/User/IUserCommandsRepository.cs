using Domain.Models;
using Domain.Repository.Base;

namespace Domain.Repository.User
{
    public interface IUserCommandsRepository : ICommandsRepository<UserProfile>
    {

    }
}
