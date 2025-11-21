using AutoMapper;

namespace CSMS_API.Models
{
    public class BusinessUnitMapper : Profile
    {
        public BusinessUnitMapper()
        {
            CreateMap<CreateBusinessUnitRequest, BusinessUnit>();
            CreateMap<UpdateBusinessUnitRequest, BusinessUnit>();
        }
    }
    public static class ManualBusinessUnitMapping
    {
        public static BusinessUnitResponse ManualBusinessUnitResponse(BusinessUnit businessUnit)
        {
            return new BusinessUnitResponse
            {
                ID = businessUnit.ID,
                Name = businessUnit.Name,
                Location = businessUnit.Location,
            };
        }
        public static List<BusinessUnitResponse> ManualBusinessUnitListResponse(List<BusinessUnit> businessUnits)
        {
            return businessUnits
                .Select(ManualBusinessUnitResponse)
                .ToList();
        }
    }
}