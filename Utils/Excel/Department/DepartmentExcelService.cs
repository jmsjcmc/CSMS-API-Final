using CSMS_API.Models;
using Magicodes.ExporterAndImporter.Excel;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CSMS_API.Utils
{
    public class DepartmentExcelService
    {
        private readonly DB _context;
        private readonly IExcelImporter _excelImporter;
        private readonly IExcelExporter _excelExporter;
        public DepartmentExcelService(DB context, IExcelImporter excelImporter, IExcelExporter excelExporter)
        {
            _context = context;
            _excelImporter = excelImporter;
            _excelExporter = excelExporter;
        }
        public async Task ImportDepartmentsAsync(Stream fileStream, ClaimsPrincipal user)
        {
            var result = await _excelImporter.Import<DepartmentImportRequest>(fileStream);

            var departments = result.Data.Select(response => new Department
            {
                Name = response.Name,
                CreatorID = AuthenticationHelper.GetUserIDAsync(user),
                CreatedOn = PresentDateTimeFetcher.FetchPresentDateTime(),
                RecordStatus = RecordStatus.Active
            });
            await _context.Department.AddRangeAsync(departments);
            await _context.SaveChangesAsync();
        }
        public async Task<byte[]> ExportDepartmentsAsync()
        {
            var departments = await _context.Department
                .AsNoTracking()
                .Select(response => new DepartmentImportRequest
                {
                    Name = response.Name
                })
                .ToListAsync();
            var file = await _excelExporter.ExportAsByteArray(departments);
            return file;
        }
    }
    public class PositionExcelService
    {
        private readonly DB _context;
        private readonly IExcelImporter _excelImporter;
        private readonly IExcelExporter _excelExporter;
        public PositionExcelService(DB context, IExcelImporter excelImporter, IExcelExporter excelExporter)
        {
            _context = context;
            _excelImporter = excelImporter;
            _excelExporter = excelExporter;
        }
        public async Task ImportPositionsAsync(IFormFile file, ClaimsPrincipal user)
        {
            var result = await _excelImporter.Import<PositionImportRequest>(file.OpenReadStream());
            var response = result.Data;
            var departments = await _context.Department.ToListAsync();
            var positions = new List<Position>();
            foreach (var row in response)
            {
                var department = departments.SingleOrDefault(d => d.Name == row.Name);
                if (department == null)
                {
                    throw new Exception($"Department {row.Name} was not found.");
                }
                var position = new Position
                {
                    Name = row.Name,
                    DepartmentID = department.ID,
                    CreatorID = AuthenticationHelper.GetUserIDAsync(user),
                    CreatedOn = PresentDateTimeFetcher.FetchPresentDateTime(),
                    RecordStatus = RecordStatus.Active
                };
                positions.Add(position);
            }
            await _context.Position.AddRangeAsync(positions);
            await _context.SaveChangesAsync();
        }
    }
}