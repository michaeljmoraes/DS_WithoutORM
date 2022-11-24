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
    public class UserApplicationService : IUserApplicationService
    {
        private readonly IUserCommandsRepository _repositoryCommands;
        private readonly IUserQueryRepository _repositoryQueries;
        private readonly IMapper _mapper;

        public UserApplicationService(IMapper mapper,
            IUserCommandsRepository userRepositoryCommands,
            IUserQueryRepository userRepositoryQueries)
        {
            _mapper = mapper;
            _repositoryCommands = userRepositoryCommands;
            _repositoryQueries = userRepositoryQueries;
        }


        public async Task<PageResult<UserProfileViewModel>> GetAsync(int id)
        {
            IEnumerable<ModelError> errors = Enumerable.Empty<ModelError>();

            var user = await _repositoryQueries.GetAsync(id);

            if (user is null)
            {
                return new PageResult<UserProfileViewModel>
                {
                    Errors = errors.Append(new ModelError("User not found"))
                };
            }

            var userViewModel = _mapper.Map<UserProfileViewModel>(user);

            var pageResult = new PageResult<UserProfileViewModel>
            {
                Data = userViewModel
            };

            return pageResult;
        }

        public async Task<PageResult<UserProfileViewModel>> GetByUserNameAsync(string userName)
        {
            IEnumerable<ModelError> errors = Enumerable.Empty<ModelError>();

            var user = await _repositoryQueries.GetByUserNameAsync(userName);

            if (user is null)
            {
                return new PageResult<UserProfileViewModel>
                {
                    Errors = errors.Append(new ModelError("User not found"))
                };

            }

            var userViewModel = _mapper.Map<UserProfileViewModel>(user);

            var pageResult = new PageResult<UserProfileViewModel>
            {
                Data = userViewModel
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

        public Task<PageResult<UserProfileViewModel>> Insert(UserProfileViewModel userViewModel)
        {
            var pageResult = new PageResult<UserProfileViewModel>(userViewModel);
            UserProfile userProfile;
            try
            {
                userProfile = _mapper.Map<UserProfile>(userViewModel);
                pageResult.Data = _mapper.Map<UserProfileViewModel>(_repositoryCommands.Insert(userProfile));

            }
            catch (Exception ex)
            {
                pageResult.Errors = pageResult.Errors.Append(new ModelError(ex.Message));
                return Task.FromResult(pageResult);
            }

            return Task.FromResult(pageResult);
        }

        public Task<PageResult<UserProfileViewModel>> Update(UserProfileViewModel userViewModel)
        {
            var pageResult = new PageResult<UserProfileViewModel>(userViewModel);
            UserProfile userProfile;
            try
            {
                userProfile = _mapper.Map<UserProfile>(userViewModel);
                pageResult.Data = _mapper.Map<UserProfileViewModel>(_repositoryCommands.Update(userProfile));
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

