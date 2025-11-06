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
            CreateMap<User, UserOnlyResponse>();
            CreateMap<User, UserWithBusinessUnitAndPositonResponse>()
                .ForMember(d => d.BusinessUnitID, o => o.MapFrom(s => s.BusinessUnit.ID))
                .ForMember(d => d.BusinessUnitName, o => o.MapFrom(s => s.BusinessUnit.Name))
                .ForMember(d => d.BusinessUnitLocation, o => o.MapFrom(s => s.BusinessUnit.Location))
                .ForMember(d => d.PositionID, o => o.MapFrom(s => s.Position.ID))
                .ForMember(d => d.PositionName, o => o.MapFrom(s => s.Position.Name))
                .ForMember(d => d.DepartmentID, o => o.MapFrom(s => s.Position.Department.ID))
                .ForMember(d => d.DepartmentName, o => o.MapFrom(s => s.Position.Department.Name));
            CreateMap<User, UserWithBusinessUnitAndPositionObjectResponse>()
                .ForMember(d => d.BusinessUnit, o => o.MapFrom(s => s.BusinessUnit))
                .ForMember(d => d.Position, o => o.MapFrom(s => s.Position));
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
