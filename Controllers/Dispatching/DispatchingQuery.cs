using CSMS_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CSMS_API.Controllers
{
    public class DispatchingQuery : IDispatchingQueries
    {
        private readonly DB _context;
        public DispatchingQuery(DB context)
        {
            _context = context;
        }
        public async Task<Dispatching?> PatchDispatchingByIDAsync(int ID)
        {
            return await _context.Dispatching
                .SingleOrDefaultAsync(D => D.ID == ID);
        }
        public async Task<DispatchingWithDispatchingPlacementResponse?> DispatchingWithDispatchingPlacementResponseByIDAsync(int ID)
        {
            return await _context.Dispatching
                .AsNoTracking()
                .Where(D => D.ID == ID)
                .Select(D => new DispatchingWithDispatchingPlacementResponse
                {
                    ID = D.ID,
                    DocumentNo = D.DocumentNo,
                    DispatchDate = D.DispatchDate,
                    DispatchTimeStart = D.DispatchTimeStart,
                    DispatchTimeEnd = D.DispatchTimeEnd,
                    NMISCertificate = D.NMISCertificate,
                    DispatchPlateNo = D.DispatchPlateNo,
                    SealNo = D.SealNo,
                    OverAllWeight = D.OverAllWeight,
                    Note = D.Note,
                    CreatorFullName = $"{D.Creator.FirstName} {D.Creator.LastName}",
                    CreatedOn = D.CreatedOn,
                    ApproverFullName = $"{D.Approver.FirstName} {D.Approver.LastName}",
                    ApprovedOn = D.ApprovedOn,
                    DeclinedOn = D.DeclinedOn,
                    RecordStatus = D.RecordStatus,
                    DispatchingPlacement = D.DispatchingPlacement.Select(DP => new DispatchingPlacementOnlyResponse
                    {
                        ID = DP.ID,
                        Quantity = DP.Quantity,
                        Weight = DP.Weight,
                    }).ToList()
                }).SingleOrDefaultAsync();
        }
        public IQueryable<DispatchingWithDispatchingPlacementResponse> DispatchingWithDispatchingPlacementResponseAsync(string? searchTerm, RecordStatus? recordStatus, ApprovalStatus? approvalStatus)
        {
            var query = _context.Dispatching
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(D => D.DocumentNo.Contains(searchTerm));
            }
            if (recordStatus.HasValue)
            {
                query = query.Where(D => D.RecordStatus == recordStatus.Value);
            }
            if (approvalStatus.HasValue)
            {
                query = query.Where(D => D.ApprovalStatus == approvalStatus.Value);
            }

            return query
                .OrderByDescending(D => D.ID)
                .Select(D => new DispatchingWithDispatchingPlacementResponse
                {
                    ID = D.ID,
                    DocumentNo = D.DocumentNo,
                    DispatchDate = D.DispatchDate,
                    DispatchTimeStart = D.DispatchTimeStart,
                    DispatchTimeEnd = D.DispatchTimeEnd,
                    NMISCertificate = D.NMISCertificate,
                    DispatchPlateNo = D.DispatchPlateNo,
                    SealNo = D.SealNo,
                    OverAllWeight = D.OverAllWeight,
                    Note = D.Note,
                    CreatorFullName = $"{D.Creator.FirstName} {D.Creator.LastName}",
                    CreatedOn = D.CreatedOn,
                    ApproverFullName = $"{D.Approver.FirstName} {D.Approver.LastName}",
                    ApprovedOn = D.ApprovedOn,
                    DeclinedOn = D.DeclinedOn,
                    RecordStatus = D.RecordStatus,
                    DispatchingPlacement = D.DispatchingPlacement.Select(DP => new DispatchingPlacementOnlyResponse
                    {
                        ID = DP.ID,
                        Quantity = DP.Quantity,
                        Weight = DP.Weight,
                    }).ToList()
                });
        }
    }
}