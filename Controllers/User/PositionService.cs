using System.Security.Claims;
using AutoMapper;
using CSMS_API.Models;
using CSMS_API.Utils;
using Microsoft.EntityFrameworkCore;

namespace CSMS_API.Controllers
{
    public interface PositionInterface
    {
        Task<PositionOnlyResponse> CreatePositionAsync(string positionName, ClaimsPrincipal user);
        Task<PositionOnlyResponse> UpdatePositionByIDAsync(int ID, string positionName, ClaimsPrincipal user);
        Task<PositionWithDepartmentResponse> AddDepartmentToPositionByIDAsync(int positionID, int departmentID, ClaimsPrincipal user);
        Task<PositionOnlyResponse> DeletePositionByIDAsync(int ID);
        Task<PositionWithDepartmentResponse> GetPositionByIDAsync(int ID);
        Task<Paginate<PositionOnlyResponse>> PaginatedPositions(
            int pageNumber,
            int pageSize,
            string searchTerm);
        Task<Paginate<PositionWithDepartmentResponse>> PaginatedPositionsWithDepartment(
            int pageNumber,
            int pageSize,
            string searchTerm);
        Task<List<PositionOnlyResponse>> ListedPositions(string? searchTerm);
        Task<List<PositionWithDepartmentResponse>> ListedPositionsWithDepartment(string? searchTerm);
    }
    public class PositionService : PositionInterface
    {
        private readonly DB _context;
        private readonly IMapper _mapper;
        private readonly PositionQuery _positionQuery;
        public PositionService(DB context, IMapper mapper, PositionQuery positionQuery)
        {
            _context = context;
            _mapper = mapper;
            _positionQuery = positionQuery;
        }
        public async Task<PositionOnlyResponse> CreatePositionAsync(string positionName, ClaimsPrincipal user)
        {
            if (await _context.Position.AnyAsync(p => p.Name == positionName))
            {
                throw new Exception($"Position {positionName} already exist");
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

                return _mapper.Map<PositionOnlyResponse>(position);
            }
        }
        public async Task<PositionOnlyResponse> UpdatePositionByIDAsync(int ID, string positionName, ClaimsPrincipal user)
        {
            var position = await _positionQuery.PatchPositionByIDAsync(ID);

            position.Name = positionName;

            await _context.SaveChangesAsync();

            var positionLog = new PositionLog
            {
                PositionID = position.ID,
                UpdaterID = AuthenticationHelper.GetUserIDAsync(user),
                UpdatedOn = PresentDateTimeFetcher.FetchPresentDateTime()
            };

            await _context.PositionLog.AddAsync(positionLog);
            await _context.SaveChangesAsync();

            return _mapper.Map<PositionOnlyResponse>(position);
        }
        public async Task<PositionWithDepartmentResponse> AddDepartmentToPositionByIDAsync(int positionID, int departmentID, ClaimsPrincipal user)
        {
            var position = await _positionQuery.PatchPositionByIDAsync(positionID);

            position.DepartmentID = departmentID;

            await _context.SaveChangesAsync();

            var positionLog = new PositionLog
            {
                PositionID = position.ID,
                UpdaterID = AuthenticationHelper.GetUserIDAsync(user),
                UpdatedOn = PresentDateTimeFetcher.FetchPresentDateTime()
            };

            await _context.PositionLog.AddAsync(positionLog);
            await _context.SaveChangesAsync();

            return _mapper.Map<PositionWithDepartmentResponse>(position);
        }
        public async Task<PositionOnlyResponse> DeletePositionByIDAsync(int ID)
        {
            var position = await _positionQuery.PatchPositionByIDAsync(ID);

            _context.Position.Remove(position);
            await _context.SaveChangesAsync();
            return _mapper.Map<PositionOnlyResponse>(position);
        }
        public async Task<PositionWithDepartmentResponse> GetPositionByIDAsync(int ID)
        {
            var position = await _positionQuery.GetPositionByIDAsync(ID);

            return _mapper.Map<PositionWithDepartmentResponse>(position);
        }
        public async Task<Paginate<PositionOnlyResponse>> PaginatedPositions(
            int pageNumber,
            int pageSize,
            string searchTerm)
        {
            var query = _positionQuery.PaginatedPositions(searchTerm);
            return await PaginationHelper.PaginateAndMapAsync<Position, PositionOnlyResponse>(query, pageNumber, pageSize, _mapper);
        }
        public async Task<Paginate<PositionWithDepartmentResponse>> PaginatedPositionsWithDepartment(
            int pageNumber,
            int pageSize,
            string searchTerm)
        {
            var query = _positionQuery.PaginatedPositionsWithDepartment(searchTerm);
            return await PaginationHelper.PaginateAndMapAsync<Position, PositionWithDepartmentResponse>(query, pageNumber, pageSize, _mapper);
        }
        public async Task<List<PositionOnlyResponse>> ListedPositions(string? searchTerm)
        {
            var positions = await _positionQuery.ListedPositions(searchTerm);
            return _mapper.Map<List<PositionOnlyResponse>>(positions);
        }
        public async Task<List<PositionWithDepartmentResponse>> ListedPositionsWithDepartment(string? searchTerm)
        {
            var positions = await _positionQuery.ListedPositionsWithDepartment(searchTerm);
            return _mapper.Map<List<PositionWithDepartmentResponse>>(positions);
        }
    }
}