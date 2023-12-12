using AutoMapper;
using EasyAuthentication.Models.Entity;
using EasyAuthentication.Models.Request;
using EasyAuthentication.Models.Response;

namespace EasyAuthentication.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region User Mapping
            CreateMap<User,GetUserProfileDto>().ReverseMap(); 
            CreateMap<User,UpdateUserProfileDto>().ReverseMap(); 
            CreateMap<User,UserDto>().ReverseMap(); 
            #endregion 

            #region Role Mapping
            CreateMap<Role,RoleDto>().ReverseMap();  
            #endregion 
        }
    }
}
