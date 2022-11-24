﻿using Domain.CoreModels;
using Domain.Models;
using Domain.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository.User
{
    public interface IUserQueryRepository : IQueryRepository<UserProfile>
    {
        Task<UserProfile?> GetByUserNameAsync(string userName);
    }
}