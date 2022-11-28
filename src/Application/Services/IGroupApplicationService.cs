//using Application.ViewModels;
using Application.Wrappers;
using Domain.CoreModels;
using Domain.Models;

namespace Application.Services
{

    public interface IGroupApplicationService : IDisposable
    {
        Task<PageResult<GroupViewModel>> GetAsync(int id);
        Task<PagedResult<IEnumerable<GroupViewModel>>> GetAllAsync(PageFilter filter);

        Task<PageResult<GroupViewModel>> Insert(GroupViewModel viewModel);
        Task<PageResult<GroupViewModel>> Update(GroupViewModel viewModel);
        Task<PageResult<GroupViewModel>> Delete(int id);
    }

}
