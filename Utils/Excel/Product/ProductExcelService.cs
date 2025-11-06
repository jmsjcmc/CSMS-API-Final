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
        public async Task ImportProductsAsync(IFormFile file, ClaimsPrincipal user)
        {
            var result = await _excelImporter.Import<ProductImportRequest>(file.OpenReadStream());
            var response = result.Data;
            var companies = await _context.Company.ToListAsync();
            var categories = await _context.Category.ToListAsync();
            var products = new List<Product>();
            foreach (var row in response)
            {
                var company = companies.SingleOrDefault(c => c.Name == row.CompanyName);
                if (company == null)
                {
                    throw new Exception($"Company {row.CompanyName} not found");
                }
                var category = categories.SingleOrDefault(c => c.Name == row.CategoryName);
                if (category == null)
                {
                    throw new Exception($"Category {row.CategoryName} not found");
                }
                var product = new Product
                {
                    CategoryID = category.ID,
                    CompanyID = company.ID,
                    ProductCode = row.ProductCode,
                    ProductName = row.ProductName,
                    Variant = row.Variant,
                    SKU = row.SKU,
                    ProductPackaging = row.ProductPackaging,
                    DeliveryUnit = row.DeliveryUnit,
                    UOM = row.UOM,
                    Unit = row.Unit,
                    Quantity = row.Quantity,
                    Weight = row.Weight,
                    CreatorID = AuthenticationHelper.GetUserIDAsync(user),
                    CreatedOn = PresentDateTimeFetcher.FetchPresentDateTime(),
                    RecordStatus = RecordStatus.Active
                };
                products.Add(product);
            }
            _context.Product.AddRange(products);
            await _context.SaveChangesAsync();
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