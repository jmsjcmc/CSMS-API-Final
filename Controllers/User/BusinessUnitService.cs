using System.Security.Claims;
using CSMS_API.Models.Entities;

namespace CSMS_API.Controllers
{
    public interface BusinessUnitInterface
    {
        Task<BusinessUnitResponse> CreateBusinessUnitAsync(CreateBusinessUnitRequest request, ClaimsPrincipal user);
        Task<BusinessUnitResponse> UpdateBusinessUnitByIDAsync(int ID, UpdateBusinessUnitRequest request, ClaimsPrincipal user);
        Task<BusinessUnitResponse> DeleteBusinessUnitByIDAsync(int ID);
        Task<BusinessUnitResponse> GetBusinessUnitByIDAsync(int ID);
    }
    public class BusinessUnitService : BusinessUnitInterface
    {
        private readonly BusinessUnitQuery _businessUnitQuery;
        public BusinessUnitService(BusinessUnitQuery businessUnitQuery)
        {
            _businessUnitQuery = businessUnitQuery;
        }
    }
}