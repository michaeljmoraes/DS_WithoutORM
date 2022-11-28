//using Application.ViewModels;
using Application.Wrappers;
using Domain.CoreModels;
using Domain.Models;

namespace Application.Services
{

    public interface IUserGroupApplicationService : IDisposable
    {
        Task<PageResult<UserGroupViewModel>> GetAsync(int id);
        Task<PagedResult<IEnumerable<UserGroupViewModel>>> GetAllAsync(PageFilter filter);

        Task<PageResult<UserGroupViewModel>> Insert(UserGroupViewModel viewModel);
        Task<PageResult<UserGroupViewModel>> Update(UserGroupViewModel viewModel);
        Task<PageResult<UserGroupViewModel>> Delete(int id);
    }

}
