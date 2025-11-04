using CSMS_API.Models;
using Magicodes.ExporterAndImporter.Excel;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CSMS_API.Utils
{
    public class CompanyExcelService
    {
        private readonly DB _context;
        private readonly IExcelImporter _excelImporter;
        private readonly IExcelExporter _excelExporter;
        public CompanyExcelService(DB context, IExcelImporter excelImporter, IExcelExporter excelExporter)
        {
            _context = context;
            _excelImporter = excelImporter;
            _excelExporter = excelExporter;
        }
        public async Task ImportCompaniesAsync(Stream fileStream, ClaimsPrincipal user)
        {
            var result = await _excelImporter.Import<CompanyImportRequest>(fileStream);

            var companies = result.Data.Select(response => new Company
            {
                Name = response.Name,
                Location = response.Location,
                Email = response.Email,
                PhoneNumber = response.PhoneNumber,
                TelephoneNumber = response.TelephoneNumber,
                RecordStatus = RecordStatus.Active,
                CreatorID = AuthenticationHelper.GetUserIDAsync(user),
                CreatedOn = PresentDateTimeFetcher.FetchPresentDateTime()
            });
            await _context.Company.AddRangeAsync(companies);
            await _context.SaveChangesAsync();
        }
        public async Task<byte[]> ExportCompaniesAsync()
        {
            var companies = await _context.Company
                .AsNoTracking()
                .Select(response => new CompanyImportRequest
                {
                    Name = response.Name,
                    Location = response.Location,
                    Email = response.Email,
                    PhoneNumber = response.PhoneNumber,
                    TelephoneNumber = response.TelephoneNumber
                })
                .ToListAsync();
            var file = await _excelExporter.ExportAsByteArray(companies);
            return file;
        }
    }
}