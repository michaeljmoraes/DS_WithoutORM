//using Application.ViewModels;
using Application.Wrappers;
using Domain.CoreModels;
using Domain.Models;

namespace Application.Services
{

    public interface IDownloadHistoryApplicationService : IDisposable
    {
        Task<PageResult<DownloadHistoryViewModel>> GetAsync(int id);
        Task<PagedResult<IEnumerable<DownloadHistoryViewModel>>> GetAllAsync(PageFilter filter);

        Task<PageResult<DownloadHistoryViewModel>> Insert(DownloadHistoryViewModel viewModel);
        Task<PageResult<DownloadHistoryViewModel>> Update(DownloadHistoryViewModel viewModel);
        Task<PageResult<DownloadHistoryViewModel>> Delete(int id);
    }

}
