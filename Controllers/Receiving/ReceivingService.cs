using AutoMapper;
using CSMS_API.Models;
using CSMS_API.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CSMS_API.Controllers
{
    public interface ReceivingInterface
    {
        Task<ReceivingOnlyResponse> CreateReceivingAsync(CreateReceivingRequest request, ClaimsPrincipal user);
        Task<ReceivingWithReceivingDetailResponse> AddReceivingDetailToReceivingByIDAsync(int ID, UpdateReceivingRequest request, ClaimsPrincipal user);
        Task<ReceivingWithReceivingDetailResponse> UpdateReceivingByIDAsync(int ID, UpdateReceivingRequest request, ClaimsPrincipal user);
        Task<ReceivingWithReceivingDetailResponse> ApproveReceivingByIDAsync(int ID, ClaimsPrincipal user);
        Task<ReceivingOnlyResponse> DeleteReceivingByIDAsync(int ID);
        Task<ReceivingWithReceivingDetailResponse> GetReceivingByIDAsync(int ID);
    }
    public class ReceivingService : ReceivingInterface
    {
        private readonly DB _context;
        private readonly IMapper _mapper;
        private readonly ReceivingQuery _receivingQuery;
        public ReceivingService(DB context, IMapper mapper, ReceivingQuery receivingQuery)
        {
            _context = context;
            _mapper = mapper;
            _receivingQuery = receivingQuery;
        }
        public async Task<ReceivingOnlyResponse> CreateReceivingAsync(CreateReceivingRequest request, ClaimsPrincipal user)
        {
            var receiving = _mapper.Map<Receiving>(request);

            receiving.CreatorID = AuthenticationHelper.GetUserIDAsync(user);
            receiving.CreatedOn = PresentDateTimeFetcher.FetchPresentDateTime();
            receiving.RecordStatus = RecordStatus.Active;

            await _context.Receiving.AddAsync(receiving);
            await _context.SaveChangesAsync();

            return _mapper.Map<ReceivingOnlyResponse>(receiving);
        }
        public async Task<ReceivingWithReceivingDetailResponse> AddReceivingDetailToReceivingByIDAsync(int ID, UpdateReceivingRequest request, ClaimsPrincipal user)
        {
            var receiving = await _receivingQuery.PatchReceivingByIDAsync(ID);
            _mapper.Map(request, receiving);

            await _context.SaveChangesAsync();

            var receivingLog = new ReceivingLog
            {
                ReceivingID = receiving.ID,
                UpdaterID = AuthenticationHelper.GetUserIDAsync(user),
                UpdatedOn = PresentDateTimeFetcher.FetchPresentDateTime()
            };

            await _context.ReceivingLog.AddAsync(receivingLog);
            await _context.SaveChangesAsync();

            return _mapper.Map<ReceivingWithReceivingDetailResponse>(receiving);
        }
        public async Task<ReceivingWithReceivingDetailResponse> UpdateReceivingByIDAsync(int ID, UpdateReceivingRequest request, ClaimsPrincipal user)
        {
            var receiving = await _receivingQuery.PatchReceivingByIDAsync(ID);

            _mapper.Map(request, receiving);

            await _context.SaveChangesAsync();

            var receivingLog = new ReceivingLog
            {
                ReceivingID = receiving.ID,
                UpdaterID = AuthenticationHelper.GetUserIDAsync(user),
                UpdatedOn = PresentDateTimeFetcher.FetchPresentDateTime()
            };

            await _context.ReceivingLog.AddAsync(receivingLog);
            await _context.SaveChangesAsync();

            return _mapper.Map<ReceivingWithReceivingDetailResponse>(receiving);
        }
        public async Task<ReceivingWithReceivingDetailResponse> ApproveReceivingByIDAsync(int ID, ClaimsPrincipal user)
        {
            var receiving = await _receivingQuery.PatchReceivingByIDAsync(ID);
            receiving.DateReceived = PresentDateTimeFetcher.FetchPresentDateTime();
            receiving.ApproverID = AuthenticationHelper.GetUserIDAsync(user);

            await _context.SaveChangesAsync();

            var receivingLog = new ReceivingLog
            {
                ReceivingID = receiving.ID,
                UpdaterID = AuthenticationHelper.GetUserIDAsync(user),
                UpdatedOn = PresentDateTimeFetcher.FetchPresentDateTime()
            };

            await _context.ReceivingLog.AddAsync(receivingLog);
            await _context.SaveChangesAsync();

            return _mapper.Map<ReceivingWithReceivingDetailResponse>(receiving);
        }
        public async Task<ReceivingOnlyResponse> DeleteReceivingByIDAsync(int ID)
        {
            var receiving = await _receivingQuery.PatchReceivingByIDAsync(ID);

            _context.Receiving.Remove(receiving);
            await _context.SaveChangesAsync();

            return _mapper.Map<ReceivingOnlyResponse>(receiving);
        }
        public async Task<ReceivingWithReceivingDetailResponse> GetReceivingByIDAsync(int ID)
        {
            var receiving = await _receivingQuery.GetReceivingByIDAsync(ID);
            return _mapper.Map<ReceivingWithReceivingDetailResponse>(receiving);
        }
    }
}