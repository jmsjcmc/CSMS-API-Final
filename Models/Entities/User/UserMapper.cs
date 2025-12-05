using AutoMapper;

namespace CSMS_API.Models
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<CreateUserRequest, User>()
                .ForMember(d => d.Password, o => o.Ignore());
            CreateMap<UpdateUserRequest, User>()
                .ForMember(d => d.Password, o => o.Ignore());
        }
    }
    public class RoleMapper : Profile
    {
        public RoleMapper()
        {
            CreateMap<Role, RoleOnlyResponse>();
        }
    }
    public class UserRoleMapper : Profile
    {
        public UserRoleMapper()
        {
            CreateMap<UserRole, UserWithRoleResponse>()
                .ForMember(d => d.User, o => o.MapFrom(s => s.User))
                .ForMember(d => d.Role, o => o.MapFrom(s => s.Role));
        }
    }
}
