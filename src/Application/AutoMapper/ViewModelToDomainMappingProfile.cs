using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {

            CreateMap<UserProfileViewModel, UserProfile>()
                .ConstructUsing(c => new UserProfile
                    (
                        c.Id,
                        c.IdRole,
                        c.Password,
                        c.LastLogin,
                        c.IsSuperuser,
                        c.Username,
                        c.FirstName,
                        c.LastName,
                        c.Email,
                        c.IsActive,
                        c.CreatedAt,
                        c.UpdatedAt
                    )
                );
            
            CreateMap<GroupViewModel, Group>()
                .ConstructUsing(c => new Group
                    (
                        c.Id,
                        c.IdRole,
                        c.Name,
                        c.Description,
                        c.IsActive,
                        c.CreatedAt,
                        c.UpdatedAt
                    )
                );
        }
}
}
