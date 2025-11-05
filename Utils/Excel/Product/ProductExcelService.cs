using CSMS_API.Models;
using Magicodes.ExporterAndImporter.Excel;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CSMS_API.Utils
{
    public class ProductExcelService
    {
        private readonly DB _context;
        private readonly IExcelImporter _excelImporter;
        private readonly IExcelExporter _excelExporter;
        public ProductExcelService(DB context, IExcelImporter excelImporter, IExcelExporter excelExporter)
        {
            _context = context;
            _excelImporter = excelImporter;
            _excelExporter = excelExporter;
        }

    }
    public class CategoryExcelService
    {
        private readonly DB _context;
        private readonly IExcelImporter _excelImporter;
        private readonly IExcelExporter _excelExporter;
        public CategoryExcelService(DB context, IExcelImporter excelImporter, IExcelExporter excelExporter)
        {
            _context = context;
            _excelImporter = excelImporter;
            _excelExporter = excelExporter;
        }
        public async Task ImportCategoriesAsync(Stream fileStream, ClaimsPrincipal user)
        {
            var result = await _excelImporter.Import<CategoryImportRequest>(fileStream);

            var categories = result.Data.Select(response => new Category
            {
                Name = response.Name,
                RecordStatus = RecordStatus.Active,
                CreatorID = AuthenticationHelper.GetUserIDAsync(user),
                CreatedOn = PresentDateTimeFetcher.FetchPresentDateTime()
            });
            await _context.Category.AddRangeAsync(categories);
            await _context.SaveChangesAsync();
        }
        public async Task<byte[]> ExportCategoriesAsync()
        {
            var categories = await _context.Category
                .AsNoTracking()
                .Select(response => new CategoryImportRequest
                {
                    Name = response.Name
                })
                .ToListAsync();
            var file = await _excelExporter.ExportAsByteArray(categories);
            return file;
        }
    }
}