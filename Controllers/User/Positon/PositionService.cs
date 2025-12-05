using System.Security.Claims;
using AutoMapper;
using CSMS_API.Models;
using CSMS_API.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CSMS_API.Controllers
{
    public class PositionService : PositionServiceInterface
    {
        private readonly DB _context;
        private readonly PositionQuery _positionQuery;
        public PositionService(DB context, IMapper mapper, PositionQuery positionQuery)
        {
            _context = context;
            _positionQuery = positionQuery;
        }
        public async Task<PositionOnlyResponse> CreatePositionAsync([FromBody] string positionName, ClaimsPrincipal user)
        {
            if (await _context.Position.AnyAsync(p => p.Name == positionName))
            {
                throw new Exception($"POSITION {positionName} ALREADY EXIST");
            }
            else
            {
                var position = new Position
                {
                    Name = positionName,
                    CreatorID = AuthenticationHelper.GetUserIDAsync(user),
                    CreatedOn = PresentDateTimeFetcher.FetchPresentDateTime(),
                    RecordStatus = RecordStatus.Active
                };

                await _context.Position.AddAsync(position);
                await _context.SaveChangesAsync();

                return await _positionQuery.PositionOnlyResponseByIDAsync(position.ID);
            }
        }
        public async Task<PositionOnlyResponse> PatchPositionByIDAsync([FromQuery] int ID,[FromBody] string positionName, ClaimsPrincipal user)
        {
            var query = await _positionQuery.PatchPositionByIDAsync(ID);

            query.Name = positionName;

            await _context.SaveChangesAsync();

            var positionLog = new PositionLog
            {
                PositionID = query.ID,
                UpdaterID = AuthenticationHelper.GetUserIDAsync(user),
                UpdatedOn = PresentDateTimeFetcher.FetchPresentDateTime()
            };

            await _context.PositionLog.AddAsync(positionLog);
            await _context.SaveChangesAsync();

            return await _positionQuery.PositionOnlyResponseByIDAsync(query.ID);
        }
        public async Task<PositionWithDepartmentResponse> AddDepartmentToPositionByIDAsync([FromQuery] int positionID, int departmentID, ClaimsPrincipal user)
        {
            var query = await _positionQuery.PatchPositionByIDAsync(positionID);

            query.DepartmentID = departmentID;

            await _context.SaveChangesAsync();

            var positionLog = new PositionLog
            {
                PositionID = query.ID,
                UpdaterID = AuthenticationHelper.GetUserIDAsync(user),
                UpdatedOn = PresentDateTimeFetcher.FetchPresentDateTime()
            };

            await _context.PositionLog.AddAsync(positionLog);
            await _context.SaveChangesAsync();

            return await _positionQuery.PositionWithDepartmentResponseByIDAsync(query.ID);
        }
        public async Task<PositionOnlyResponse> PatchPositionStatusByIDAsync([FromQuery] int ID, RecordStatus status, ClaimsPrincipal user)
        {
            var query = await _positionQuery.PatchPositionByIDAsync(ID);

            query.RecordStatus = status;

            await _context.SaveChangesAsync();

            var positionLog = new PositionLog
            {
                PositionID = query.ID,
                UpdaterID = AuthenticationHelper.GetUserIDAsync(user),
                UpdatedOn = PresentDateTimeFetcher.FetchPresentDateTime()
            };

            await _context.PositionLog.AddAsync(positionLog);
            await _context.SaveChangesAsync();

            return await _positionQuery.PositionOnlyResponseByIDAsync(query.ID);
        }
        public async Task<PositionOnlyResponse> DeletePositionByIDAsync(int ID)
        {
            var query = await _positionQuery.PatchPositionByIDAsync(ID);

            _context.Position.Remove(query);
            await _context.SaveChangesAsync();

            return await _positionQuery.PositionOnlyResponseByIDAsync(query.ID);
        }
        public async Task<PositionWithDepartmentResponse> GetPositionByIDAsync(int ID)
        {
            return await _positionQuery.PositionWithDepartmentResponseByIDAsync(ID);
        }
        public async Task<Paginate<PositionOnlyResponse>> GetPaginatedPositionsAsync(
            [FromQuery] int pageNumber,
            [FromQuery] int pageSize,
            [FromQuery] string? searchTerm,
            [FromQuery] RecordStatus? status)
        {
            var query = _positionQuery.PositionOnlyResponseAsync(searchTerm, status);
            return await PaginationHelper.PaginateAndMap(query, pageNumber, pageSize);
        }
        public async Task<Paginate<PositionWithDepartmentResponse>> GetPaginatedPositionsWithDepartmentAsync(
            [FromQuery] int pageNumber,
            [FromQuery] int pageSize,
            [FromQuery] string? searchTerm,
            [FromQuery] RecordStatus? status)
        {
            var query = _positionQuery.PositionWithDepartmentResponseAsync(searchTerm, status);
            return await PaginationHelper.PaginateAndMap(query, pageNumber, pageSize);
        }
        public async Task<List<PositionOnlyResponse>> GetListedPositionsAsync([FromQuery] string? searchTerm, RecordStatus? status)
        {
            return await _positionQuery.PositionOnlyResponseAsync(searchTerm, status).ToListAsync();
        }
        public async Task<List<PositionWithDepartmentResponse>> GetListedPositionsWithDepartmentAsync([FromQuery] string? searchTerm, RecordStatus? status)
        {
            return await _positionQuery.PositionWithDepartmentResponseAsync(searchTerm, status).ToListAsync();
        }
    }
}