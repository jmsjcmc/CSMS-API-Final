using AutoMapper;

namespace CSMS_API.Models.Entities
{
    public class DepartmentMapper : Profile
    {
        public DepartmentMapper()
        {
            CreateMap<Department, DepartmentOnlyResponse>();
            CreateMap<Department, DepartmentWithPositionResponse>()
            .ForMember(d => d.Position, o => o.MapFrom(s => s.Position));
        }
    }
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