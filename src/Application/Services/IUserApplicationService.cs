//using Application.ViewModels;
using Application.Services.Base;
using Application.Wrappers;
using Domain.CoreModels;
using Domain.Models;
using Domain.Repository.Base;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IUserApplicationService : IDisposable
    {

        Task<PageResult<UserProfileViewModel>> GetByUserNameAsync(string userName);

        Task<PageResult<UserProfileViewModel>> GetAsync(int id);
        Task<PagedResult<IEnumerable<UserProfileViewModel>>> GetAllAsync(PageFilter filter);

        Task<PageResult<UserProfileViewModel>> Insert(UserProfileViewModel userProfile);
        Task<PageResult<UserProfileViewModel>> Update(UserProfileViewModel userProfile);
        Task<PageResult<UserProfileViewModel>> Delete(int id);
    }

}
