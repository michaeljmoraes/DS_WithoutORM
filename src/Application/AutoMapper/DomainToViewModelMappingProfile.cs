using AutoMapper;
using Domain.Models;

namespace Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Category, CategoryViewModel>();

            CreateMap<Document, DocumentViewModel>();

            CreateMap<DownloadHistory, DownloadHistoryViewModel>();

            CreateMap<Group, GroupViewModel>();

            CreateMap<Role, RoleViewModel>();

            CreateMap<UserGroup, UserGroupViewModel>();

            CreateMap<UserProfile, UserProfileViewModel>();

            //MappingAppendTag














        }
    }
}
