using Application.Wrappers;
using AutoMapper;
using Domain.CoreModels;
using Domain.Models;
using Domain.Repository;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Application.Services
{
    public class DocumentApplicationService : IDocumentApplicationService
    {
        private readonly IDocumentCommandsRepository _repositoryCommands;
        private readonly IDocumentQueryRepository _repositoryQueries;
        private readonly IMapper _mapper;

        public DocumentApplicationService(IMapper mapper,
            IDocumentCommandsRepository repositoryCommands,
            IDocumentQueryRepository repositoryQueries)
        {
            _mapper = mapper;
            _repositoryCommands = repositoryCommands;
            _repositoryQueries = repositoryQueries;
        }


        public async Task<PageResult<DocumentViewModel>> GetAsync(int id)
        {
            IEnumerable<ModelError> errors = Enumerable.Empty<ModelError>();

            var entity = await _repositoryQueries.GetAsync(id);

            if (entity is null)
            {
                return new PageResult<DocumentViewModel>
                {
                    Errors = errors.Append(new ModelError("Document not found"))
                };
            }

            var entityViewModel = _mapper.Map<DocumentViewModel>(entity);

            var pageResult = new PageResult<DocumentViewModel>
            {
                Data = entityViewModel
            };

            return pageResult;
        }

        public async Task<PagedResult<IEnumerable<DocumentViewModel>>> GetAllAsync(PageFilter filter)
        {
            var data = _mapper.Map<IEnumerable<DocumentViewModel>>(await _repositoryQueries.GetAllAsync());
            var totalResult = data.Count();
            var pagedResult = new PagedResult<IEnumerable<DocumentViewModel>>(data, totalResult, filter);
            return pagedResult;
        }

        public Task<PageResult<DocumentViewModel>> Insert(DocumentViewModel viewModel)
        {
            var pageResult = new PageResult<DocumentViewModel>(viewModel);
            Document entity;
            try
            {
                entity = _mapper.Map<Document>(viewModel);
                pageResult.Data = _mapper.Map<DocumentViewModel>(_repositoryCommands.Insert(entity));

            }
            catch (Exception ex)
            {
                pageResult.Errors = pageResult.Errors.Append(new ModelError(ex.Message));
                return Task.FromResult(pageResult);
            }

            return Task.FromResult(pageResult);
        }

        public Task<PageResult<DocumentViewModel>> Update(DocumentViewModel viewModel)
        {
            var pageResult = new PageResult<DocumentViewModel>(viewModel);
            Document identity;
            try
            {
                identity = _mapper.Map<Document>(viewModel);
                pageResult.Data = _mapper.Map<DocumentViewModel>(_repositoryCommands.Update(identity));
            }
            catch (Exception ex)
            {
                pageResult.Errors = pageResult.Errors.Append(new ModelError(ex.Message));
                return Task.FromResult(pageResult);
            }
            return Task.FromResult(pageResult);
        }

        public Task<PageResult<DocumentViewModel>> Delete(int id)
        {
            var pageResult = new PageResult<DocumentViewModel>();
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

