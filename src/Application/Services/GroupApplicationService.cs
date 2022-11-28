using Application.Wrappers;
using AutoMapper;
using Domain.CoreModels;
using Domain.Models;
using Domain.Repository;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Application.Services
{
    public class GroupApplicationService : IGroupApplicationService
    {
        private readonly IGroupCommandsRepository _repositoryCommands;
        private readonly IGroupQueryRepository _repositoryQueries;
        private readonly IMapper _mapper;

        public GroupApplicationService(IMapper mapper,
            IGroupCommandsRepository repositoryCommands,
            IGroupQueryRepository repositoryQueries)
        {
            _mapper = mapper;
            _repositoryCommands = repositoryCommands;
            _repositoryQueries = repositoryQueries;
        }


        public async Task<PageResult<GroupViewModel>> GetAsync(int id)
        {
            IEnumerable<ModelError> errors = Enumerable.Empty<ModelError>();

            var entity = await _repositoryQueries.GetAsync(id);

            if (entity is null)
            {
                return new PageResult<GroupViewModel>
                {
                    Errors = errors.Append(new ModelError("Group not found"))
                };
            }

            var entityViewModel = _mapper.Map<GroupViewModel>(entity);

            var pageResult = new PageResult<GroupViewModel>
            {
                Data = entityViewModel
            };

            return pageResult;
        }

        public async Task<PagedResult<IEnumerable<GroupViewModel>>> GetAllAsync(PageFilter filter)
        {
            var data = _mapper.Map<IEnumerable<GroupViewModel>>(await _repositoryQueries.GetAllAsync());
            var totalResult = data.Count();
            var pagedResult = new PagedResult<IEnumerable<GroupViewModel>>(data, totalResult, filter);
            return pagedResult;
        }

        public Task<PageResult<GroupViewModel>> Insert(GroupViewModel viewModel)
        {
            var pageResult = new PageResult<GroupViewModel>(viewModel);
            Group entity;
            try
            {
                entity = _mapper.Map<Group>(viewModel);
                pageResult.Data = _mapper.Map<GroupViewModel>(_repositoryCommands.Insert(entity));

            }
            catch (Exception ex)
            {
                pageResult.Errors = pageResult.Errors.Append(new ModelError(ex.Message));
                return Task.FromResult(pageResult);
            }

            return Task.FromResult(pageResult);
        }

        public Task<PageResult<GroupViewModel>> Update(GroupViewModel viewModel)
        {
            var pageResult = new PageResult<GroupViewModel>(viewModel);
            Group identity;
            try
            {
                identity = _mapper.Map<Group>(viewModel);
                pageResult.Data = _mapper.Map<GroupViewModel>(_repositoryCommands.Update(identity));
            }
            catch (Exception ex)
            {
                pageResult.Errors = pageResult.Errors.Append(new ModelError(ex.Message));
                return Task.FromResult(pageResult);
            }
            return Task.FromResult(pageResult);
        }

        public Task<PageResult<GroupViewModel>> Delete(int id)
        {
            var pageResult = new PageResult<GroupViewModel>();
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

