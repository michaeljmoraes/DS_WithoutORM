using Application.Wrappers;
using AutoMapper;
using Domain.CoreModels;
using Domain.Models;
using Domain.Repository;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Application.Services
{
    public class UserGroupApplicationService : IUserGroupApplicationService
    {
        private readonly IUserGroupCommandsRepository _repositoryCommands;
        private readonly IUserGroupQueryRepository _repositoryQueries;
        private readonly IMapper _mapper;

        public UserGroupApplicationService(IMapper mapper,
            IUserGroupCommandsRepository repositoryCommands,
            IUserGroupQueryRepository repositoryQueries)
        {
            _mapper = mapper;
            _repositoryCommands = repositoryCommands;
            _repositoryQueries = repositoryQueries;
        }


        public async Task<PageResult<UserGroupViewModel>> GetAsync(int id)
        {
            IEnumerable<ModelError> errors = Enumerable.Empty<ModelError>();

            var entity = await _repositoryQueries.GetAsync(id);

            if (entity is null)
            {
                return new PageResult<UserGroupViewModel>
                {
                    Errors = errors.Append(new ModelError("UserGroup not found"))
                };
            }

            var entityViewModel = _mapper.Map<UserGroupViewModel>(entity);

            var pageResult = new PageResult<UserGroupViewModel>
            {
                Data = entityViewModel
            };

            return pageResult;
        }

        public async Task<PagedResult<IEnumerable<UserGroupViewModel>>> GetAllAsync(PageFilter filter)
        {
            var data = _mapper.Map<IEnumerable<UserGroupViewModel>>(await _repositoryQueries.GetAllAsync());
            var totalResult = data.Count();
            var pagedResult = new PagedResult<IEnumerable<UserGroupViewModel>>(data, totalResult, filter);
            return pagedResult;
        }

        public Task<PageResult<UserGroupViewModel>> Insert(UserGroupViewModel viewModel)
        {
            var pageResult = new PageResult<UserGroupViewModel>(viewModel);
            UserGroup entity;
            try
            {
                entity = _mapper.Map<UserGroup>(viewModel);
                pageResult.Data = _mapper.Map<UserGroupViewModel>(_repositoryCommands.Insert(entity));

            }
            catch (Exception ex)
            {
                pageResult.Errors = pageResult.Errors.Append(new ModelError(ex.Message));
                return Task.FromResult(pageResult);
            }

            return Task.FromResult(pageResult);
        }

        public Task<PageResult<UserGroupViewModel>> Update(UserGroupViewModel viewModel)
        {
            var pageResult = new PageResult<UserGroupViewModel>(viewModel);
            UserGroup identity;
            try
            {
                identity = _mapper.Map<UserGroup>(viewModel);
                pageResult.Data = _mapper.Map<UserGroupViewModel>(_repositoryCommands.Update(identity));
            }
            catch (Exception ex)
            {
                pageResult.Errors = pageResult.Errors.Append(new ModelError(ex.Message));
                return Task.FromResult(pageResult);
            }
            return Task.FromResult(pageResult);
        }

        public Task<PageResult<UserGroupViewModel>> Delete(int id)
        {
            var pageResult = new PageResult<UserGroupViewModel>();
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

