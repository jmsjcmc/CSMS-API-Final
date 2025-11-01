using System.Security.Claims;
using AutoMapper;
using CSMS_API.Models;
using CSMS_API.Models.Entities;
using CSMS_API.Utils;
using Microsoft.EntityFrameworkCore;

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
        private readonly IMapper _mapper;
        private readonly DB _context;
        public BusinessUnitService(BusinessUnitQuery businessUnitQuery, IMapper mapper, DB context)
        {
            _businessUnitQuery = businessUnitQuery;
            _mapper = mapper;
            _context = context;
        }
        public async Task<BusinessUnitResponse> CreateBusinessUnitAsync(CreateBusinessUnitRequest request, ClaimsPrincipal user)
        {
            if (await _context.BusinessUnit.AnyAsync(bu => bu.Name == request.Name))
            {
                throw new Exception($"Business Unit {request.Name} already exist");
            }
            else
            {
                var businessUnit = _mapper.Map<BusinessUnit>(request);

                businessUnit.CreatorID = AuthenticationHelper.GetUserIDAsync(user);
                businessUnit.CreatedOn = PresentDateTimeFetcher.FetchPresentDateTime();
                businessUnit.RecordStatus = RecordStatus.Active;

                await _context.BusinessUnit.AddAsync(businessUnit);
                await _context.SaveChangesAsync();
                return _mapper.Map<BusinessUnitResponse>(businessUnit);
            }
        }
        public async Task<BusinessUnitResponse> UpdateBusinessUnitByIDAsync(int ID, UpdateBusinessUnitRequest request, ClaimsPrincipal user)
        {
            var businessUnit = await _businessUnitQuery.PatchBusinessUnitByIDAsync(ID);

            _mapper.Map(request, businessUnit);

            await _context.SaveChangesAsync();

            var businessUnitLog = new BusinessUnitLog
            {
                BusinessUnitID = businessUnit.ID,
                UpdaterID = AuthenticationHelper.GetUserIDAsync(user),
                UpdatedOn = PresentDateTimeFetcher.FetchPresentDateTime()
            };

            await _context.BusinessUnitLog.AddAsync(businessUnitLog);
            await _context.SaveChangesAsync();

            return _mapper.Map<BusinessUnitResponse>(businessUnit);
        }
        public async Task<BusinessUnitResponse> DeleteBusinessUnitByIDAsync(int ID)
        {
            var businessUnit = await _businessUnitQuery.PatchBusinessUnitByIDAsync(ID);

            _context.BusinessUnit.Remove(businessUnit);

            await _context.SaveChangesAsync();

            return _mapper.Map<BusinessUnitResponse>(businessUnit);
        }
        public async Task<BusinessUnitResponse> GetBusinessUnitByIDAsync(int ID)
        {
            var businessUnit = await _businessUnitQuery.GetBusinessUnitByIDAsync(ID);
            return _mapper.Map<BusinessUnitResponse>(businessUnit);
        }
    }
}