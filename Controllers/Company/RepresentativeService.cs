using AutoMapper;
using CSMS_API.Models;
using CSMS_API.Utils;
using System.Security.Claims;

namespace CSMS_API.Controllers
{
    public interface RepresentativeInterface
    {
        Task<RepresentativeOnlyResponse> CreateRepresentativeAsync(CreateRepresentativeRequest request, ClaimsPrincipal user);
        Task<RepresentativeOnlyResponse> UpdateRepresentativeByIDAsync(int ID, UpdateRepresentativeRequest request, ClaimsPrincipal user);
        Task<RepresentativeWithCompanyResponse> AddCompanyToRepresentativeByIDAsync(int representativeID, int companyID, ClaimsPrincipal user);
        Task<RepresentativeOnlyResponse> DeleteRepresentativeByIDAsync(int ID);
        Task<RepresentativeWithCompanyResponse> GetRepresentativeByIDAsync(int ID);
        Task<Paginate<RepresentativeOnlyResponse>> PaginatedRepresentatives(
            int pageNumber,
            int pageSize,
            string searchTerm);
        Task<List<RepresentativeOnlyResponse>> ListedRepresentatives(string? searchTerm);
    }
    public class RepresentativeService : RepresentativeInterface
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

            return _mapper.Map<RepresentativeOnlyResponse>(representative);
        }
        public async Task<RepresentativeOnlyResponse> UpdateRepresentativeByIDAsync(int ID, UpdateRepresentativeRequest request, ClaimsPrincipal user)
        {
            var representative = await _representativeQuery.PatchRepresentativeByIDAsync(ID);
            _mapper.Map(request, representative);

            await _context.SaveChangesAsync();

            var representativeLog = new RepresentativeLog
            {
                RepresentativeID = representative.ID,
                UpdaterID = AuthenticationHelper.GetUserIDAsync(user),
                UpdatedOn = PresentDateTimeFetcher.FetchPresentDateTime()
            };

            await _context.RepresentativeLog.AddAsync(representativeLog);
            await _context.SaveChangesAsync();

            return _mapper.Map<RepresentativeOnlyResponse>(representative);
        }
        public async Task<RepresentativeWithCompanyResponse> AddCompanyToRepresentativeByIDAsync(int representativeID, int companyID, ClaimsPrincipal user)
        {
            var representative = await _representativeQuery.PatchRepresentativeByIDAsync(representativeID);
            representative.CompanyID = companyID;

            await _context.SaveChangesAsync();

            var representativeLog = new RepresentativeLog
            {
                RepresentativeID = representative.ID,
                UpdaterID = AuthenticationHelper.GetUserIDAsync(user),
                UpdatedOn = PresentDateTimeFetcher.FetchPresentDateTime()
            };

            await _context.RepresentativeLog.AddAsync(representativeLog);
            await _context.SaveChangesAsync();
            return _mapper.Map<RepresentativeWithCompanyResponse>(representative);
        }
        public async Task<RepresentativeOnlyResponse> DeleteRepresentativeByIDAsync(int ID)
        {
            var representative = await _representativeQuery.PatchRepresentativeByIDAsync(ID);

            _context.Representative.Remove(representative);
            await _context.SaveChangesAsync();

            return _mapper.Map<RepresentativeOnlyResponse>(representative);
        }
        public async Task<RepresentativeWithCompanyResponse> GetRepresentativeByIDAsync(int ID)
        {
            var representative = await _representativeQuery.GetRepresentativeByIDAsync(ID);
            return _mapper.Map<RepresentativeWithCompanyResponse>(representative);
        }
        public async Task<Paginate<RepresentativeOnlyResponse>> PaginatedRepresentatives(
            int pageNumber,
            int pageSize,
            string searchTerm)
        {
            var query = _representativeQuery.PaginatedRepresentatives(searchTerm);
            return await PaginationHelper.PaginateAndMapAsync<Representative, RepresentativeOnlyResponse>(query, pageNumber, pageSize, _mapper);
        }
        public async Task<List<RepresentativeOnlyResponse>> ListedRepresentatives(string? searchTerm)
        {
            var representatives = await _representativeQuery.ListedRepresentatives(searchTerm);
            return _mapper.Map<List<RepresentativeOnlyResponse>>(representatives);
        }
    }
}