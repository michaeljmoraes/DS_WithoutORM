//using Application.ViewModels;
using Application.Wrappers;
using Domain.CoreModels;
using Domain.Models;

namespace Application.Services
{
    public interface IUserApplicationService : IDisposable
    {

        Task<PageResult<UserProfileViewModel>> GetByUserNameAsync(string userName);

        Task<PageResult<UserProfileViewModel>> GetAsync(int id);
        Task<PagedResult<IEnumerable<UserProfileViewModel>>> GetAllAsync(PageFilter filter);

        Task<PageResult<UserProfileViewModel>> Insert(UserProfileViewModel userProfile);
        Task<PageResult<UserProfileViewModel>> Update(UserProfileViewModel userProfile);
        Task<PageResult<UserProfileViewModel>> Delete(int id);
    }

}
