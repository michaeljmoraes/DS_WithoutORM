using Application.Wrappers;
using AutoMapper;
using Domain.CoreModels;
using Domain.Models;
using Domain.Repository;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Application.Services
{
    public class UserProfileApplicationService : IUserProfileApplicationService
    {
        private readonly IUserProfileCommandsRepository _repositoryCommands;
        private readonly IUserProfileQueryRepository _repositoryQueries;
        private readonly IMapper _mapper;

        public UserProfileApplicationService(IMapper mapper,
            IUserProfileCommandsRepository repositoryCommands,
            IUserProfileQueryRepository repositoryQueries)
        {
            _mapper = mapper;
            _repositoryCommands = repositoryCommands;
            _repositoryQueries = repositoryQueries;
        }


        public async Task<PageResult<UserProfileViewModel>> GetAsync(int id)
        {
            IEnumerable<ModelError> errors = Enumerable.Empty<ModelError>();

            var entity = await _repositoryQueries.GetAsync(id);

            if (entity is null)
            {
                return new PageResult<UserProfileViewModel>
                {
                    Errors = errors.Append(new ModelError("UserProfile not found"))
                };
            }

            var entityViewModel = _mapper.Map<UserProfileViewModel>(entity);

            var pageResult = new PageResult<UserProfileViewModel>
            {
                Data = entityViewModel
            };

            return pageResult;
        }

        public async Task<PagedResult<IEnumerable<UserProfileViewModel>>> GetAllAsync(PageFilter filter)
        {
            var data = _mapper.Map<IEnumerable<UserProfileViewModel>>(await _repositoryQueries.GetAllAsync());
            var totalResult = data.Count();
            var pagedResult = new PagedResult<IEnumerable<UserProfileViewModel>>(data, totalResult, filter);
            return pagedResult;
        }

        public Task<PageResult<UserProfileViewModel>> Insert(UserProfileViewModel viewModel)
        {
            var pageResult = new PageResult<UserProfileViewModel>(viewModel);
            UserProfile entity;
            try
            {
                entity = _mapper.Map<UserProfile>(viewModel);
                pageResult.Data = _mapper.Map<UserProfileViewModel>(_repositoryCommands.Insert(entity));

            }
            catch (Exception ex)
            {
                pageResult.Errors = pageResult.Errors.Append(new ModelError(ex.Message));
                return Task.FromResult(pageResult);
            }

            return Task.FromResult(pageResult);
        }

        public Task<PageResult<UserProfileViewModel>> Update(UserProfileViewModel viewModel)
        {
            var pageResult = new PageResult<UserProfileViewModel>(viewModel);
            UserProfile identity;
            try
            {
                identity = _mapper.Map<UserProfile>(viewModel);
                pageResult.Data = _mapper.Map<UserProfileViewModel>(_repositoryCommands.Update(identity));
            }
            catch (Exception ex)
            {
                pageResult.Errors = pageResult.Errors.Append(new ModelError(ex.Message));
                return Task.FromResult(pageResult);
            }
            return Task.FromResult(pageResult);
        }

        public Task<PageResult<UserProfileViewModel>> Delete(int id)
        {
            var pageResult = new PageResult<UserProfileViewModel>();
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

