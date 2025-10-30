using AutoMapper;

namespace CSMS_API.Models
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<CreateUserRequest, User>()
                .ForMember(d => d.Password, o => o.Ignore());
            CreateMap<User, UserWithBusinessUnitAndPositonResponse>()
                .ForMember(d => d.BusinessUnitID, o => o.MapFrom(s => s.BusinessUnit.ID))
                .ForMember(d => d.BusinessUnitName, o => o.MapFrom(s => s.BusinessUnit.Name))
                .ForMember(d => d.BusinessUnitLocation, o => o.MapFrom(s => s.BusinessUnit.Location))
                .ForMember(d => d.PositionID, o => o.MapFrom(s => s.Position.ID))
                .ForMember(d => d.PositionName, o => o.MapFrom(s => s.Position.Name))
                .ForMember(d => d.DepartmentID, o => o.MapFrom(s => s.Position.Department.ID))
                .ForMember(d => d.DepartmentName, o => o.MapFrom(s => s.Position.Department.Name));
        }
    }
}
