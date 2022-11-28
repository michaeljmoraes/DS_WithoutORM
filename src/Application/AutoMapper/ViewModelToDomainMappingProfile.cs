using AutoMapper;
using Domain.Models;

namespace Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CategoryViewModel, Category>()
.ConstructUsing(c => new Category
    (
        c.Id,
c.Name,
c.Description,
c.CreatedAt,
c.UpdatedAt

    )
);
            CreateMap<DocumentViewModel, Document>()
            .ConstructUsing(c => new Document
                (
                    c.Id,
            c.IdOwner,
            c.IdCategory,
            c.Name,
            c.Description,
            c.FileName,
            c.FilePath,
            c.IsPublic,
            c.CreatedAt,
            c.UpdatedAt

                )
            );
            CreateMap<DownloadHistoryViewModel, DownloadHistory>()
            .ConstructUsing(c => new DownloadHistory
                (
                    c.Id,
            c.IdDocument,
            c.IdUser,
            c.DownloadedAt

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
            CreateMap<RoleViewModel, Role>()
            .ConstructUsing(c => new Role
                (
                    c.Id,
            c.Name,
            c.Description,
            c.RoleType,
            c.Domain,
            c.Action,
            c.IsActive,
            c.Priority,
            c.CreatedAt,
            c.UpdatedAt

                )
            );
            CreateMap<UserGroupViewModel, UserGroup>()
            .ConstructUsing(c => new UserGroup
                (
                    c.Id,
            c.IdUser,
            c.IdGroup,
            c.CreatedAt,
            c.UpdatedAt

                )
            );
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
            //MappingAppendTag















        }
    }
}
