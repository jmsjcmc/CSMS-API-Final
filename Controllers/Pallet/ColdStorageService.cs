using AutoMapper;
using CSMS_API.Models;
using CSMS_API.Utils;
using System.Security.Claims;

namespace CSMS_API.Controllers
{
    public interface ColdStorageInterface
    {
        Task<ColdStorageOnlyResponse> CreateColdStorageAsync(string coldStorageNumber, ClaimsPrincipal user);
        Task<ColdStorageOnlyResponse> UpdateColdStorageByIDAsync(int ID, string coldStorageNumber, ClaimsPrincipal user);
        Task<ColdStorageOnlyResponse> DeleteColdStorageByIDAsync(int ID);
        Task<ColdStorageOnlyResponse> GetColdStorageByIDAsync(int ID);
    }
    public class ColdStorageService : ColdStorageInterface
    {
        private readonly DB _context;
        private readonly IMapper _mapper;
        private readonly ColdStorageQuery _coldStorageQuery;
        public ColdStorageService(DB context, IMapper mapper, ColdStorageQuery coldStorageQuery)
        {
            _context = context;
            _mapper = mapper;
            _coldStorageQuery = coldStorageQuery;
        }
        public async Task<ColdStorageOnlyResponse> CreateColdStorageAsync(string coldStorageNumber, ClaimsPrincipal user)
        {
            var coldStorage = new ColdStorage
            {
                Number = coldStorageNumber,
                CreatorID = AuthenticationHelper.GetUserIDAsync(user),
                CreatedOn = PresentDateTimeFetcher.FetchPresentDateTime(),
                RecordStatus = RecordStatus.Active
            };

            await _context.ColdStorage.AddAsync(coldStorage);
            await _context.SaveChangesAsync();

            return _mapper.Map<ColdStorageOnlyResponse>(coldStorage);
        }
        public async Task<ColdStorageOnlyResponse> UpdateColdStorageByIDAsync(int ID, string coldStorageNumber, ClaimsPrincipal user)
        {
            var coldStorage = await _coldStorageQuery.PatchColdStorageByIDAsync(ID);

            coldStorage.Number = coldStorageNumber;

            await _context.SaveChangesAsync();

            var coldStorageLog = new ColdStorageLog
            {
                ColdStorageID = coldStorage.ID,
                UpdaterID = AuthenticationHelper.GetUserIDAsync(user),
                UpdatedOn = PresentDateTimeFetcher.FetchPresentDateTime()
            };

            await _context.ColdStorageLog.AddAsync(coldStorageLog);
            await _context.SaveChangesAsync();

            return _mapper.Map<ColdStorageOnlyResponse>(coldStorage);
        }
        public async Task<ColdStorageOnlyResponse> DeleteColdStorageByIDAsync(int ID)
        {
            var coldStorage = await _coldStorageQuery.PatchColdStorageByIDAsync(ID);

            _context.ColdStorage.Remove(coldStorage);
            await _context.SaveChangesAsync();

            return _mapper.Map<ColdStorageOnlyResponse>(coldStorage);
        }
        public async Task<ColdStorageOnlyResponse> GetColdStorageByIDAsync(int ID)
        {
            var coldStorage = await _coldStorageQuery.GetColdStorageByIDAsync(ID);
            return _mapper.Map<ColdStorageOnlyResponse>(coldStorage);
        }
    }
}