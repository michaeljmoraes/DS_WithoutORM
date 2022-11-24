using Core.DomainObjects;
using Application.Wrappers;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Application.Services;
using Domain.Models;
using Domain.CoreModels;
using Domain.Repository.User;
using Microsoft.Extensions.Hosting;
using AutoMapper;

namespace Application.Services
{
    public class GroupApplicationService : IGroupApplicationService
    {
        private readonly IGroupCommandsRepository _repositoryCommands;
        private readonly IGroupQueryRepository _repositoryQueries;
        private readonly IMapper _mapper;

        public GroupApplicationService(IMapper mapper,
            IGroupCommandsRepository groupRepositoryCommands,
            IGroupQueryRepository groupRepositoryQueries)
        {
            _mapper = mapper;
            _repositoryCommands = groupRepositoryCommands;
            _repositoryQueries = groupRepositoryQueries;
        }


        public async Task<PageResult<GroupViewModel>> GetAsync(int id)
        {
            IEnumerable<ModelError> errors = Enumerable.Empty<ModelError>();

            var user = await _repositoryQueries.GetAsync(id);

            if (user is null)
            {
                return new PageResult<GroupViewModel>
                {
                    Errors = errors.Append(new ModelError("Group not found"))
                };
            }

            var userViewModel = _mapper.Map<GroupViewModel>(user);

            var pageResult = new PageResult<GroupViewModel>
            {
                Data = userViewModel
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

