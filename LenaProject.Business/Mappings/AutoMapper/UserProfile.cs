using AutoMapper;
using LenaProject.DataAccess.Entities;

namespace LenaProject.Business.Mappings.AutoMapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User , UserListDto>().ReverseMap();
            CreateMap<User , UserLoginDto>().ReverseMap();
            CreateMap<User, UserRegisterDto>().ReverseMap();
        }
    }
}
