//using Application.ViewModels;
using Application.Wrappers;
using Domain.CoreModels;
using Domain.Models;

namespace Application.Services
{

    public interface IUserProfileApplicationService : IDisposable
    {
        Task<PageResult<UserProfileViewModel>> GetAsync(int id);
        Task<PagedResult<IEnumerable<UserProfileViewModel>>> GetAllAsync(PageFilter filter);

        Task<PageResult<UserProfileViewModel>> Insert(UserProfileViewModel viewModel);
        Task<PageResult<UserProfileViewModel>> Update(UserProfileViewModel viewModel);
        Task<PageResult<UserProfileViewModel>> Delete(int id);
    }

}
