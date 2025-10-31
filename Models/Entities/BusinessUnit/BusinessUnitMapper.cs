using AutoMapper;

namespace CSMS_API.Models.Entities
{
    public class BusinessUnitMapper : Profile
    {
        public BusinessUnitMapper()
        {
            CreateMap<CreateBusinessUnitRequest, BusinessUnit>();
            CreateMap<UpdateBusinessUnitRequest, BusinessUnit>();
            CreateMap<BusinessUnit, BusinessUnitResponse>();
        }
    }
}