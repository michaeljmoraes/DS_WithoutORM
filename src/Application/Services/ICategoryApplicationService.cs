//using Application.ViewModels;
using Application.Wrappers;
using Domain.CoreModels;
using Domain.Models;

namespace Application.Services
{

    public interface ICategoryApplicationService : IDisposable
    {
        Task<PageResult<CategoryViewModel>> GetAsync(int id);
        Task<PagedResult<IEnumerable<CategoryViewModel>>> GetAllAsync(PageFilter filter);

        Task<PageResult<CategoryViewModel>> Insert(CategoryViewModel viewModel);
        Task<PageResult<CategoryViewModel>> Update(CategoryViewModel viewModel);
        Task<PageResult<CategoryViewModel>> Delete(int id);
    }

}
