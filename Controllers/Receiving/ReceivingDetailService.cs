using AutoMapper;
using CSMS_API.Models;
using CSMS_API.Utils;
using System.Security.Claims;

namespace CSMS_API.Controllers
{
    public interface ReceivingDetailInterface
    {
        Task<ReceivingDetailOnlyResponse> CreateReceivingDetailAsync(CreateReceivingDetailRequest request, ClaimsPrincipal user);
        Task<ReceivingDetailWithReceivingAndProductObjectResponse> UpdateReceivingDetailByIDAsync(int ID, UpdateReceivingDetailRequest request, ClaimsPrincipal user);
        Task<ReceivingDetailOnlyResponse> DeleteReceivingDetailByIDAsync(int ID);
        Task<ReceivingDetailWithReceivingAndProductObjectResponse> GetReceivingDetailByIDAsync(int ID);
    }
    public class ReceivingDetailService : ReceivingDetailInterface
    {
        private readonly DB _context;
        private readonly IMapper _mapper;
        private readonly ReceivingDetailQuery _receivingDetailQuery;
        public ReceivingDetailService(DB context, IMapper mapper, ReceivingDetailQuery receivingDetailQuery)
        {
            _context = context;
            _mapper = mapper;
            _receivingDetailQuery = receivingDetailQuery;
        }
        public async Task<ReceivingDetailOnlyResponse> CreateReceivingDetailAsync(CreateReceivingDetailRequest request, ClaimsPrincipal user)
        {
            var receivingDetail = _mapper.Map<ReceivingDetail>(request);
            receivingDetail.CreatorID = AuthenticationHelper.GetUserIDAsync(user);
            receivingDetail.CreatedOn = PresentDateTimeFetcher.FetchPresentDateTime();

            await _context.ReceivingDetail.AddAsync(receivingDetail);
            await _context.SaveChangesAsync();

            return _mapper.Map<ReceivingDetailOnlyResponse>(receivingDetail);
        }
        public async Task<ReceivingDetailWithReceivingAndProductObjectResponse> UpdateReceivingDetailByIDAsync(int ID, UpdateReceivingDetailRequest request, ClaimsPrincipal user)
        {
            var receivingDetail = await _receivingDetailQuery.PatchReceivingDetailByIDAsync(ID);
            _mapper.Map(request, receivingDetail);

            await _context.ReceivingDetail.AddAsync(receivingDetail);

            var receivingDetailLog = new ReceivingDetailLog
            {
                ReceivingDetailID = receivingDetail.ID,
                UpdaterID = AuthenticationHelper.GetUserIDAsync(user),
                UpdatedOn = PresentDateTimeFetcher.FetchPresentDateTime()
            };

            await _context.ReceivingDetailLog.AddAsync(receivingDetailLog);
            await _context.SaveChangesAsync();

            return _mapper.Map<ReceivingDetailWithReceivingAndProductObjectResponse>(receivingDetail);
        }
        public async Task<ReceivingDetailOnlyResponse> DeleteReceivingDetailByIDAsync(int ID)
        {
            var receivingDetail = await _receivingDetailQuery.PatchReceivingDetailByIDAsync(ID);
            return _mapper.Map<ReceivingDetailOnlyResponse>(receivingDetail);
        }
        public async Task<ReceivingDetailWithReceivingAndProductObjectResponse> GetReceivingDetailByIDAsync(int ID)
        {
            var receivingDetail = await _receivingDetailQuery.GetReceivingDetailByIDAsync(ID);
            return _mapper.Map<ReceivingDetailWithReceivingAndProductObjectResponse>(receivingDetail);
        }
    }
}