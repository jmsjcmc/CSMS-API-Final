using AutoMapper;

namespace CSMS_API.Models
{
    public class PositionMapper : Profile
    {
        public PositionMapper()
        {
            CreateMap<Position, PositionOnlyResponse>();
            CreateMap<Position, PositionWithDepartmentResponse>()
            .ForMember(d => d.DepartmentID, o => o.MapFrom(s => s.Department.ID))
            .ForMember(d => d.DepartmentName, o => o.MapFrom(s => s.Department.Name));
        }
    }
}