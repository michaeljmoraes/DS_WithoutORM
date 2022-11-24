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

    public interface IGroupApplicationService: IDisposable
    {


        Task<PageResult<GroupViewModel>> GetAsync(int id);
        Task<PagedResult<IEnumerable<GroupViewModel>>> GetAllAsync(PageFilter filter);

        Task<PageResult<GroupViewModel>> Insert(GroupViewModel userProfile);
        Task<PageResult<GroupViewModel>> Update(GroupViewModel userProfile);
        Task<PageResult<GroupViewModel>> Delete(int id);
    }

}
