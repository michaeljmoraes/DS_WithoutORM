using Application.Wrappers;
using AutoMapper;
using Domain.CoreModels;
using Domain.Models;
using Domain.Repository;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Application.Services
{
    public class DownloadHistoryApplicationService : IDownloadHistoryApplicationService
    {
        private readonly IDownloadHistoryCommandsRepository _repositoryCommands;
        private readonly IDownloadHistoryQueryRepository _repositoryQueries;
        private readonly IMapper _mapper;

        public DownloadHistoryApplicationService(IMapper mapper,
            IDownloadHistoryCommandsRepository repositoryCommands,
            IDownloadHistoryQueryRepository repositoryQueries)
        {
            _mapper = mapper;
            _repositoryCommands = repositoryCommands;
            _repositoryQueries = repositoryQueries;
        }


        public async Task<PageResult<DownloadHistoryViewModel>> GetAsync(int id)
        {
            IEnumerable<ModelError> errors = Enumerable.Empty<ModelError>();

            var entity = await _repositoryQueries.GetAsync(id);

            if (entity is null)
            {
                return new PageResult<DownloadHistoryViewModel>
                {
                    Errors = errors.Append(new ModelError("DownloadHistory not found"))
                };
            }

            var entityViewModel = _mapper.Map<DownloadHistoryViewModel>(entity);

            var pageResult = new PageResult<DownloadHistoryViewModel>
            {
                Data = entityViewModel
            };

            return pageResult;
        }

        public async Task<PagedResult<IEnumerable<DownloadHistoryViewModel>>> GetAllAsync(PageFilter filter)
        {
            var data = _mapper.Map<IEnumerable<DownloadHistoryViewModel>>(await _repositoryQueries.GetAllAsync());
            var totalResult = data.Count();
            var pagedResult = new PagedResult<IEnumerable<DownloadHistoryViewModel>>(data, totalResult, filter);
            return pagedResult;
        }

        public Task<PageResult<DownloadHistoryViewModel>> Insert(DownloadHistoryViewModel viewModel)
        {
            var pageResult = new PageResult<DownloadHistoryViewModel>(viewModel);
            DownloadHistory entity;
            try
            {
                entity = _mapper.Map<DownloadHistory>(viewModel);
                pageResult.Data = _mapper.Map<DownloadHistoryViewModel>(_repositoryCommands.Insert(entity));

            }
            catch (Exception ex)
            {
                pageResult.Errors = pageResult.Errors.Append(new ModelError(ex.Message));
                return Task.FromResult(pageResult);
            }

            return Task.FromResult(pageResult);
        }

        public Task<PageResult<DownloadHistoryViewModel>> Update(DownloadHistoryViewModel viewModel)
        {
            var pageResult = new PageResult<DownloadHistoryViewModel>(viewModel);
            DownloadHistory identity;
            try
            {
                identity = _mapper.Map<DownloadHistory>(viewModel);
                pageResult.Data = _mapper.Map<DownloadHistoryViewModel>(_repositoryCommands.Update(identity));
            }
            catch (Exception ex)
            {
                pageResult.Errors = pageResult.Errors.Append(new ModelError(ex.Message));
                return Task.FromResult(pageResult);
            }
            return Task.FromResult(pageResult);
        }

        public Task<PageResult<DownloadHistoryViewModel>> Delete(int id)
        {
            var pageResult = new PageResult<DownloadHistoryViewModel>();
            try
            {
                _repositoryCommands.Delete(id);
            }
            catch (Exception ex)
            {
                pageResult.Errors = pageResult.Errors.Append(new ModelError(ex.Message));
                return Task.FromResult(pageResult);
            }
            return Task.FromResult(pageResult);
        }


        public void Dispose()
        {
            _repositoryCommands.Dispose();
            _repositoryQueries.Dispose();
        }
    }
}

