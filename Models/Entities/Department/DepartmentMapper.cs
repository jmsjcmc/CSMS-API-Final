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
}