using Application.Wrappers;
using AutoMapper;
using Domain.CoreModels;
using Domain.Models;
using Domain.Repository;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Application.Services
{
    public class RoleApplicationService : IRoleApplicationService
    {
        private readonly IRoleCommandsRepository _repositoryCommands;
        private readonly IRoleQueryRepository _repositoryQueries;
        private readonly IMapper _mapper;

        public RoleApplicationService(IMapper mapper,
            IRoleCommandsRepository repositoryCommands,
            IRoleQueryRepository repositoryQueries)
        {
            _mapper = mapper;
            _repositoryCommands = repositoryCommands;
            _repositoryQueries = repositoryQueries;
        }


        public async Task<PageResult<RoleViewModel>> GetAsync(int id)
        {
            IEnumerable<ModelError> errors = Enumerable.Empty<ModelError>();

            var entity = await _repositoryQueries.GetAsync(id);

            if (entity is null)
            {
                return new PageResult<RoleViewModel>
                {
                    Errors = errors.Append(new ModelError("Role not found"))
                };
            }

            var entityViewModel = _mapper.Map<RoleViewModel>(entity);

            var pageResult = new PageResult<RoleViewModel>
            {
                Data = entityViewModel
            };

            return pageResult;
        }

        public async Task<PagedResult<IEnumerable<RoleViewModel>>> GetAllAsync(PageFilter filter)
        {
            var data = _mapper.Map<IEnumerable<RoleViewModel>>(await _repositoryQueries.GetAllAsync());
            var totalResult = data.Count();
            var pagedResult = new PagedResult<IEnumerable<RoleViewModel>>(data, totalResult, filter);
            return pagedResult;
        }

        public Task<PageResult<RoleViewModel>> Insert(RoleViewModel viewModel)
        {
            var pageResult = new PageResult<RoleViewModel>(viewModel);
            Role entity;
            try
            {
                entity = _mapper.Map<Role>(viewModel);
                pageResult.Data = _mapper.Map<RoleViewModel>(_repositoryCommands.Insert(entity));

            }
            catch (Exception ex)
            {
                pageResult.Errors = pageResult.Errors.Append(new ModelError(ex.Message));
                return Task.FromResult(pageResult);
            }

            return Task.FromResult(pageResult);
        }

        public Task<PageResult<RoleViewModel>> Update(RoleViewModel viewModel)
        {
            var pageResult = new PageResult<RoleViewModel>(viewModel);
            Role identity;
            try
            {
                identity = _mapper.Map<Role>(viewModel);
                pageResult.Data = _mapper.Map<RoleViewModel>(_repositoryCommands.Update(identity));
            }
            catch (Exception ex)
            {
                pageResult.Errors = pageResult.Errors.Append(new ModelError(ex.Message));
                return Task.FromResult(pageResult);
            }
            return Task.FromResult(pageResult);
        }

        public Task<PageResult<RoleViewModel>> Delete(int id)
        {
            var pageResult = new PageResult<RoleViewModel>();
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

