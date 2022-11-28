using Application.Wrappers;
using AutoMapper;
using Domain.CoreModels;
using Domain.Models;
using Domain.Repository;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Application.Services
{
    public class CategoryApplicationService : ICategoryApplicationService
    {
        private readonly ICategoryCommandsRepository _repositoryCommands;
        private readonly ICategoryQueryRepository _repositoryQueries;
        private readonly IMapper _mapper;

        public CategoryApplicationService(IMapper mapper,
            ICategoryCommandsRepository repositoryCommands,
            ICategoryQueryRepository repositoryQueries)
        {
            _mapper = mapper;
            _repositoryCommands = repositoryCommands;
            _repositoryQueries = repositoryQueries;
        }


        public async Task<PageResult<CategoryViewModel>> GetAsync(int id)
        {
            IEnumerable<ModelError> errors = Enumerable.Empty<ModelError>();

            var entity = await _repositoryQueries.GetAsync(id);

            if (entity is null)
            {
                return new PageResult<CategoryViewModel>
                {
                    Errors = errors.Append(new ModelError("Category not found"))
                };
            }

            var entityViewModel = _mapper.Map<CategoryViewModel>(entity);

            var pageResult = new PageResult<CategoryViewModel>
            {
                Data = entityViewModel
            };

            return pageResult;
        }

        public async Task<PagedResult<IEnumerable<CategoryViewModel>>> GetAllAsync(PageFilter filter)
        {
            var data = _mapper.Map<IEnumerable<CategoryViewModel>>(await _repositoryQueries.GetAllAsync());
            var totalResult = data.Count();
            var pagedResult = new PagedResult<IEnumerable<CategoryViewModel>>(data, totalResult, filter);
            return pagedResult;
        }

        public Task<PageResult<CategoryViewModel>> Insert(CategoryViewModel viewModel)
        {
            var pageResult = new PageResult<CategoryViewModel>(viewModel);
            Category entity;
            try
            {
                entity = _mapper.Map<Category>(viewModel);
                pageResult.Data = _mapper.Map<CategoryViewModel>(_repositoryCommands.Insert(entity));

            }
            catch (Exception ex)
            {
                pageResult.Errors = pageResult.Errors.Append(new ModelError(ex.Message));
                return Task.FromResult(pageResult);
            }

            return Task.FromResult(pageResult);
        }

        public Task<PageResult<CategoryViewModel>> Update(CategoryViewModel viewModel)
        {
            var pageResult = new PageResult<CategoryViewModel>(viewModel);
            Category identity;
            try
            {
                identity = _mapper.Map<Category>(viewModel);
                pageResult.Data = _mapper.Map<CategoryViewModel>(_repositoryCommands.Update(identity));
            }
            catch (Exception ex)
            {
                pageResult.Errors = pageResult.Errors.Append(new ModelError(ex.Message));
                return Task.FromResult(pageResult);
            }
            return Task.FromResult(pageResult);
        }

        public Task<PageResult<CategoryViewModel>> Delete(int id)
        {
            var pageResult = new PageResult<CategoryViewModel>();
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

