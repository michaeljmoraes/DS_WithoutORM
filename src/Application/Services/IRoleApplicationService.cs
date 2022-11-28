//using Application.ViewModels;
using Application.Wrappers;
using Domain.CoreModels;
using Domain.Models;

namespace Application.Services
{

    public interface IRoleApplicationService : IDisposable
    {
        Task<PageResult<RoleViewModel>> GetAsync(int id);
        Task<PagedResult<IEnumerable<RoleViewModel>>> GetAllAsync(PageFilter filter);

        Task<PageResult<RoleViewModel>> Insert(RoleViewModel viewModel);
        Task<PageResult<RoleViewModel>> Update(RoleViewModel viewModel);
        Task<PageResult<RoleViewModel>> Delete(int id);
    }

}
