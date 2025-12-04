using CSMS_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CSMS_API.Controllers
{
    public class PositionQuery : PositionQueriesInterface
    {
        private readonly DB _context;
        public PositionQuery(DB context)
        {
            _context = context;
        }
        public async Task<Position?> PatchPositionByIDAsync(int ID)
        {
            return await _context.Position
                .SingleOrDefaultAsync(P => P.ID == ID);
        }
        public async Task<PositionOnlyResponse?> PositionOnlyResponseByIDAsync(int ID)
        {
            return await _context.Position
                .AsNoTracking()
                .Where(P => P.ID == ID)
                .Select(P => new PositionOnlyResponse
                {
                    ID = P.ID,
                    Name = P.Name,
                    RecordStatus = P.RecordStatus
                }).SingleOrDefaultAsync();
        }
        public async Task<PositionWithDepartmentResponse?> PositionWithDepartmentResponseByIDAsync(int ID)
        {
            return await _context.Position
                .AsNoTracking()
                .Where(P => P.ID == ID)
                .Select(P => new PositionWithDepartmentResponse
                {
                    ID = P.ID,
                    Name = P.Name,
                    RecordStatus = P.RecordStatus,
                    DepartmentID = P.DepartmentID,
                    DepartmentName = P.Department.Name
                }).SingleOrDefaultAsync();
        }
        public IQueryable<PositionOnlyResponse> PositionOnlyResponseAsync(string? searchTerm, RecordStatus? status)
        {
            var query = _context.Position
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(P => P.Name.Contains(searchTerm));
            }
            if (status.HasValue)
            {
                query = query.Where(P => P.RecordStatus == status);
            }

            return query
                .OrderByDescending(P => P.ID)
                .Select(P => new PositionOnlyResponse
                {
                    ID = P.ID,
                    Name = P.Name,
                    RecordStatus = P.RecordStatus
                });
        }
        public IQueryable<PositionWithDepartmentResponse> PositionWithDepartmentResponseAsync(string? searchTerm, RecordStatus? status)
        {
            var query = _context.Position
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(P => P.Name.Contains(searchTerm));
            }
            if (status.HasValue)
            {
                query = query.Where(P => P.RecordStatus == status);
            }

            return query
                .OrderByDescending(P => P.ID)
                .Select(P => new PositionWithDepartmentResponse
                {
                    ID = P.ID,
                    Name = P.Name,
                    RecordStatus = P.RecordStatus,
                    DepartmentID = P.DepartmentID,
                    DepartmentName = P.Department.Name
                });
        }
    }
}