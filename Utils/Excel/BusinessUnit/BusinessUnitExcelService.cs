using CSMS_API.Models;
using Magicodes.ExporterAndImporter.Excel;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CSMS_API.Utils
{
    public class BusinessUnitExcelService
    {
        private readonly DB _context;
        private readonly IExcelImporter _excelImporter;
        private readonly IExcelExporter _excelExporter;
        public BusinessUnitExcelService(DB context, IExcelImporter excelImporter, IExcelExporter excelExporter)
        {
            _context = context;
            _excelImporter = excelImporter;
            _excelExporter = excelExporter;
        }
        public async Task ImportBusinessUnitsAsync(Stream fileStream, ClaimsPrincipal user)
        {
            var result = await _excelImporter.Import<BusinessUnitImportRequest>(fileStream);
            var businessUnits = result.Data.Select(response => new BusinessUnit
            {
                Name = response.Name,
                Location = response.Location,
                CreatorID = AuthenticationHelper.GetUserIDAsync(user),
                CreatedOn = PresentDateTimeFetcher.FetchPresentDateTime(),
                RecordStatus = RecordStatus.Active
            });
            await _context.BusinessUnit.AddRangeAsync(businessUnits);
            await _context.SaveChangesAsync();
        }
        public async Task<byte[]> ExportBusinessUnitsAsync()
        {
            var businessUnits = await _context.BusinessUnit
                .AsNoTracking()
                .Select(response => new BusinessUnitImportRequest
                {
                    Name = response.Name,
                    Location = response.Location
                })
                .ToListAsync();
            var file = await _excelExporter.ExportAsByteArray(businessUnits);
            return file;
        }
    }
}