using System.Security.Claims;
using AutoMapper;
using CSMS_API.Models;
using CSMS_API.Utils;
using Microsoft.EntityFrameworkCore;

namespace CSMS_API.Controllers
{
    public interface DepartmentInterface
    {
        Task<DepartmentOnlyResponse> CreateDepartmentAsync(string departmentName, ClaimsPrincipal user);
        Task<DepartmentOnlyResponse> UpdateDepartmentByIDAsync(int ID, string departmentName, ClaimsPrincipal user);
        Task<DepartmentOnlyResponse> DeleteDepartmentByIDAsync(int ID);
        Task<DepartmentWithPositionResponse> GetDepartmentByIDAsync(int ID);
    }
    public class DepartmentService : DepartmentInterface
    {
        private readonly DB _context;
        private readonly IMapper _mapper;
        private readonly DepartmentQuery _departmentQuery;
        public DepartmentService(DB context, IMapper mapper, DepartmentQuery departmentQuery)
        {
            _context = context;
            _mapper = mapper;
            _departmentQuery = departmentQuery;
        }
        public async Task<DepartmentOnlyResponse> CreateDepartmentAsync(string departmentName, ClaimsPrincipal user)
        {
            if (await _context.Department.AnyAsync(d => d.Name == departmentName))
            {
                throw new Exception($"Department {departmentName} already exist");
            } else
            {
                var department = new Department
                {
                    Name = departmentName,
                    CreatorID = AuthenticationHelper.GetUserIDAsync(user),
                    CreatedOn = PresentDateTimeFetcher.FetchPresentDateTime(),
                    RecordStatus = RecordStatus.Active
                };

                await _context.Department.AddAsync(department);
                await _context.SaveChangesAsync();

                return _mapper.Map<DepartmentOnlyResponse>(department);
            }
        }
        public async Task<DepartmentOnlyResponse> UpdateDepartmentByIDAsync(int ID, string departmentName, ClaimsPrincipal user)
        {
            var department = await _departmentQuery.PatchDepartmentByIDAsync(ID);

            department.Name = departmentName;

            await _context.SaveChangesAsync();

            var departmentLog = new DepartmentLog
            {
                DepartmentID = department.ID,
                UpdaterID = AuthenticationHelper.GetUserIDAsync(user),
                UpdatedOn = PresentDateTimeFetcher.FetchPresentDateTime()
            };
            await _context.DepartmentLog.AddAsync(departmentLog);
            await _context.SaveChangesAsync();
            return _mapper.Map<DepartmentOnlyResponse>(department);
        }
        public async Task<DepartmentOnlyResponse> DeleteDepartmentByIDAsync(int ID)
        {
            var department = await _departmentQuery.PatchDepartmentByIDAsync(ID);

            _context.Department.Remove(department);
            await _context.SaveChangesAsync();
            return _mapper.Map<DepartmentOnlyResponse>(department);
        }
        public async Task<DepartmentWithPositionResponse> GetDepartmentByIDAsync(int ID)
        {
            var department = await _departmentQuery.GetDepartmentByIDAsync(ID);
            return _mapper.Map<DepartmentWithPositionResponse>(department);
        }
    }
    
}