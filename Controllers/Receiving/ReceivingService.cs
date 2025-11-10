using AutoMapper;
using CSMS_API.Models;
using CSMS_API.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CSMS_API.Controllers
{
    public interface ReceivingInterface
    {
        Task<ReceivingOnlyResponse> CreateReceivingAsync(CreateReceivingRequest request, ClaimsPrincipal user);
        Task<ReceivingWithReceivingDetailResponse> AddReceivingDetailToReceivingByIDAsync(int ID, UpdateReceivingRequest request, ClaimsPrincipal user);
        Task<ReceivingPlacementWithReceivingProductReceivingDetailPalletAndPalletPositionObjectResponse> AddPalletAndPalletPositionToReceivingDetailByIDAsync(CreateReceivingPlacementRequest request, ClaimsPrincipal user);
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
            if (await _context.Receiving.AnyAsync(r => r.DocumentNo == request.DocumentNo))
            {
                throw new Exception($"Document No {request.DocumentNo} already exist");
            }
            else
            {
                var receiving = _mapper.Map<Receiving>(request);
                receiving.CreatorID = AuthenticationHelper.GetUserIDAsync(user);
                receiving.CreatedOn = PresentDateTimeFetcher.FetchPresentDateTime();
                receiving.RecordStatus = RecordStatus.Active;

                await _context.Receiving.AddAsync(receiving);
                await _context.SaveChangesAsync();

                return _mapper.Map<ReceivingOnlyResponse>(receiving);
            }
        }
        public async Task<ReceivingWithReceivingDetailResponse> AddReceivingDetailToReceivingByIDAsync(int ID, UpdateReceivingRequest request, ClaimsPrincipal user)
        {
            var receiving = await _receivingQuery.PatchReceivingByIDAsync(ID);

            ManualReceivingMapper.ManualReceivingMapping(request, receiving);
            ManualReceivingMapper.ManualReceivingDetailMapping(request, receiving, user);

            _context.Receiving.Update(receiving);
            await _context.SaveChangesAsync();

            var groupedByProducts = receiving.ReceivingDetail
                .GroupBy(rd => rd.ProductID)
                .Select(g => new
                {
                    productID = g.Key,
                    totalQuantity = g.Sum(s => s.QuantityInPallet ?? 0),
                    totalWeight = g.Sum(s => s.TotalWeight ?? 0.0)
                })
                .ToList();

            foreach (var productGroup in groupedByProducts)
            {
                if (productGroup.productID == null) continue;

                var existingReceivingProduct = await _context.ReceivingProduct
                    .SingleOrDefaultAsync(rp => rp.ReceivingID == receiving.ID &&
                    rp.ProductID == productGroup.productID);

                if (existingReceivingProduct != null)
                {
                    existingReceivingProduct.TotalQuantity = productGroup.totalQuantity;
                    existingReceivingProduct.TotalWeight = productGroup.totalWeight;
                    existingReceivingProduct.RecordStatus = RecordStatus.Active;

                    _context.ReceivingProduct.Update(existingReceivingProduct);

                    var receivingProductLog = new ReceivingProductLog
                    {
                        ReceivingProductID = existingReceivingProduct.ID,
                        UpdaterID = AuthenticationHelper.GetUserIDAsync(user),
                        UpdatedOn = PresentDateTimeFetcher.FetchPresentDateTime()
                    };

                    await _context.ReceivingProductLog.AddAsync(receivingProductLog);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    var receivingProduct = new ReceivingProduct
                    {
                        ReceivingID = receiving.ID,
                        ProductID = productGroup.productID,
                        TotalQuantity = productGroup.totalQuantity,
                        TotalWeight = productGroup.totalWeight,
                        RecordStatus = RecordStatus.Active
                    };

                    await _context.ReceivingProduct.AddAsync(receivingProduct);
                }

            }
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
        public async Task<ReceivingPlacementWithReceivingProductReceivingDetailPalletAndPalletPositionObjectResponse> AddPalletAndPalletPositionToReceivingDetailByIDAsync(CreateReceivingPlacementRequest request, ClaimsPrincipal user)
        {
            var receivingPlacement = _mapper.Map<ReceivingPlacement>(request);
            receivingPlacement.RecordStatus = RecordStatus.Active;
            receivingPlacement.CreatorID = AuthenticationHelper.GetUserIDAsync(user);
            receivingPlacement.CreatedOn = PresentDateTimeFetcher.FetchPresentDateTime();

            await _context.ReceivingPlacement.AddAsync(receivingPlacement);
            await _context.SaveChangesAsync();

            if (request.PalletID.HasValue && request.PalletOccupationStatus.HasValue)
            {
                var pallet = await _context.Pallet.SingleOrDefaultAsync(p => p.ID == request.PalletID.Value);
                if (pallet != null)
                {
                    pallet.PalletOccupationStatus = request.PalletOccupationStatus.Value;
                }
            }

            if (request.PalletPositionID.HasValue)
            {
                var palletPosition = await _context.PalletPosition.SingleOrDefaultAsync(pp => pp.ID == request.PalletPositionID.Value);
                if (palletPosition != null)
                {
                    palletPosition.PalletPositionStatus = PalletPositionStatus.Occupied;
                }
            }

            await _context.SaveChangesAsync();

            return _mapper.Map<ReceivingPlacementWithReceivingProductReceivingDetailPalletAndPalletPositionObjectResponse>(receivingPlacement);
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