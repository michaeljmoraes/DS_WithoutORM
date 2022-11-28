//using Application.ViewModels;
using Application.Wrappers;
using Domain.CoreModels;
using Domain.Models;

namespace Application.Services
{

    public interface IDocumentApplicationService : IDisposable
    {
        Task<PageResult<DocumentViewModel>> GetAsync(int id);
        Task<PagedResult<IEnumerable<DocumentViewModel>>> GetAllAsync(PageFilter filter);

        Task<PageResult<DocumentViewModel>> Insert(DocumentViewModel viewModel);
        Task<PageResult<DocumentViewModel>> Update(DocumentViewModel viewModel);
        Task<PageResult<DocumentViewModel>> Delete(int id);
    }

}
