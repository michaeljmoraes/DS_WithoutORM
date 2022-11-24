using AutoMapper;

namespace DocumentStorage.Api.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Post, PostViewModel>().ReverseMap();
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<Relationship, RelationshipViewModel>().ReverseMap();
        }
    }
}
