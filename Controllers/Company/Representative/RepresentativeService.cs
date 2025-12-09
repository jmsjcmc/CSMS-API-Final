using AutoMapper;
using CSMS_API.Models;
using CSMS_API.Utils;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CSMS_API.Controllers
{
    public class RepresentativeService : IRepresentativeService
    {
        private readonly RepresentativeQuery _representativeQuery;
        private readonly IMapper _mapper;
        private readonly DB _context;
        public RepresentativeService(RepresentativeQuery representativeQuery, IMapper mapper, DB context)
        {
            _representativeQuery = representativeQuery;
            _mapper = mapper;
            _context = context;
        }
        public async Task<RepresentativeOnlyResponse> CreateRepresentativeAsync(CreateRepresentativeRequest request, ClaimsPrincipal user)
        {
            var representative = _mapper.Map<Representative>(request);

            representative.CreatorID = AuthenticationHelper.GetUserIDAsync(user);
            representative.CreatedOn = PresentDateTimeFetcher.FetchPresentDateTime();
            representative.RecordStatus = RecordStatus.Active;

            await _context.Representative.AddAsync(representative);
            await _context.SaveChangesAsync();

            return await _representativeQuery.RepresentativeOnlyResponseByIDAsync(representative.ID);
        }
        public async Task<RepresentativeOnlyResponse> PatchRepresentativeByIDAsync(int ID, UpdateRepresentativeRequest request, ClaimsPrincipal user)
        {
            var query = await _representativeQuery.PatchRepresentativeByIDAsync(ID);

            _mapper.Map(request, query);

            await _context.SaveChangesAsync();

            var representativeLog = new RepresentativeLog
            {
                RepresentativeID = query.ID,
                UpdaterID = AuthenticationHelper.GetUserIDAsync(user),
                UpdatedOn = PresentDateTimeFetcher.FetchPresentDateTime()
            };

            await _context.RepresentativeLog.AddAsync(representativeLog);
            await _context.SaveChangesAsync();

            return await _representativeQuery.RepresentativeOnlyResponseByIDAsync(query.ID);
        }
        public async Task<RepresentativeOnlyResponse> PatchRepresentativeStatusByIDAsync(int ID, RecordStatus status, ClaimsPrincipal user)
        {
            var query = await _representativeQuery.PatchRepresentativeByIDAsync(ID);

            query.RecordStatus = status;

            await _context.SaveChangesAsync();

            var representativeLog = new RepresentativeLog
            {
                RepresentativeID = query.ID,
                UpdaterID = AuthenticationHelper.GetUserIDAsync(user),
                UpdatedOn = PresentDateTimeFetcher.FetchPresentDateTime()
            };

            await _context.RepresentativeLog.AddAsync(representativeLog);
            await _context.SaveChangesAsync();

            return await _representativeQuery.RepresentativeOnlyResponseByIDAsync(query.ID);
        }
        public async Task<RepresentativeWithCompanyResponse> AddCompanyToRepresentativeByIDAsync(int representativeID, int companyID, ClaimsPrincipal user)
        {
            var query = await _representativeQuery.PatchRepresentativeByIDAsync(representativeID);

            query.CompanyID = companyID;

            await _context.SaveChangesAsync();

            var representativeLog = new RepresentativeLog
            {
                RepresentativeID = query.ID,
                UpdaterID = AuthenticationHelper.GetUserIDAsync(user),
                UpdatedOn = PresentDateTimeFetcher.FetchPresentDateTime()
            };

            await _context.RepresentativeLog.AddAsync(representativeLog);
            await _context.SaveChangesAsync();

            return await _representativeQuery.RepresentativeWithCompanyResponseByIDAsync(query.ID);
        }
        public async Task<RepresentativeOnlyResponse> DeleteRepresentativeByIDAsync(int ID)
        {
            var query = await _representativeQuery.PatchRepresentativeByIDAsync(ID);

            _context.Representative.Remove(query);
            await _context.SaveChangesAsync();

            return await _representativeQuery.RepresentativeOnlyResponseByIDAsync(query.ID);
        }
        public async Task<RepresentativeOnlyResponse> GetRepresentativeByIDAsync(int ID)
        {
            return await _representativeQuery.RepresentativeOnlyResponseByIDAsync(ID);
        }
        public async Task<RepresentativeWithCompanyResponse> GetRepresentativeWithCompanyByIDAsync(int ID)
        {
            return await _representativeQuery.RepresentativeWithCompanyResponseByIDAsync(ID);
        }
        public async Task<Paginate<RepresentativeOnlyResponse>> GetPaginatedRepresentativesAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm,
            RecordStatus? status)
        {
            var query = _representativeQuery.RepresentativeOnlyResponseAsync(searchTerm, status);

            return await PaginationHelper.PaginateAndMap(query, pageNumber, pageSize);
        }
        public async Task<Paginate<RepresentativeWithCompanyResponse>> GetPaginatedRepresentativesWithCompanyAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm,
            RecordStatus? status)
        {
            var query = _representativeQuery.RepresentativeWithCompanyResponseAsync(searchTerm, status);

            return await PaginationHelper.PaginateAndMap(query, pageNumber, pageSize);
        }
        public async Task<List<RepresentativeOnlyResponse>> GetListedRepresentativesAsync(string? searchTerm, RecordStatus? status)
        {
            return await _representativeQuery.RepresentativeOnlyResponseAsync(searchTerm, status).ToListAsync();
        }
        public async Task<List<RepresentativeWithCompanyResponse>> GetListedRepresentativesWithCompanyAsync(string? searchTerm, RecordStatus? status)
        {
            return await _representativeQuery.RepresentativeWithCompanyResponseAsync(searchTerm, status).ToListAsync();
        }
    }
}