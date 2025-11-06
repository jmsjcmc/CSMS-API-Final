using CSMS_API.Models;
using Magicodes.ExporterAndImporter.Excel;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CSMS_API.Utils
{
    public class PalletExcelService
    {
        private readonly DB _context;
        private readonly IExcelImporter _excelImporter;
        private readonly IExcelExporter _excelExporter;
        public PalletExcelService(DB context, IExcelImporter excelImporter, IExcelExporter excelExporter)
        {
            _context = context;
            _excelImporter = excelImporter;
            _excelExporter = excelExporter;
        }
        public async Task ImportPalletsAsync(Stream fileStream, ClaimsPrincipal user)
        {
            var result = await _excelImporter.Import<PalletImportRequest>(fileStream);

            var pallets = result.Data.Select(response => new Pallet
            {
                Type = response.Type,
                Number = response.Number,
                CreatorID = AuthenticationHelper.GetUserIDAsync(user),
                CreatedOn = PresentDateTimeFetcher.FetchPresentDateTime(),
                RecordStatus = RecordStatus.Active
            });
            await _context.Pallet.AddRangeAsync(pallets);
            await _context.SaveChangesAsync();
        }
        public async Task<byte[]> ExportPalletsAsync()
        {
            var pallets = await _context.Pallet
                .AsNoTracking()
                .Select(response => new PalletImportRequest
                {
                    Type = response.Type,
                    Number = response.Number,
                })
                .ToListAsync();
            var file = await _excelExporter.ExportAsByteArray(pallets);
            return file;
        }
    }
    public class PalletPositionExcelService
    {
        private readonly DB _context;
        private readonly IExcelImporter _excelImporter;
        private readonly IExcelExporter _excelExporter;
        public PalletPositionExcelService(DB context, IExcelImporter excelImporter, IExcelExporter excelExporter)
        {
            _context = context;
            _excelImporter = excelImporter;
            _excelExporter = excelExporter;
        }
        public async Task ImportPalletPositionsAsync(IFormFile file, ClaimsPrincipal user)
        {
            var result = await _excelImporter.Import<PalletPositionImportRequest>(file.OpenReadStream());
            var response = result.Data;
            var coldStorages = await _context.ColdStorage.ToListAsync();
            var palletPositions = new List<PalletPosition>();
            foreach (var row in response)
            {
                var coldStorage = coldStorages.SingleOrDefault(cs => cs.Number == row.ColdStorageNumber);
                if (coldStorage == null)
                {
                    throw new Exception($"Cold Storage {row.ColdStorageNumber} not found");
                }
                var palletPosition = new PalletPosition
                {
                    ColdStorageID = coldStorage.ID,
                    Wing = row.Wing,
                    Floor = row.Floor,
                    Column = row.Column,
                    Side = row.Side,
                    CreatorID = AuthenticationHelper.GetUserIDAsync(user),
                    CreatedOn = PresentDateTimeFetcher.FetchPresentDateTime(),
                    RecordStatus = RecordStatus.Active
                };
                palletPositions.Add(palletPosition);
            }
            await _context.PalletPosition.AddRangeAsync(palletPositions);
            await _context.SaveChangesAsync();
        }
    }
    public class ColdStorageExcelService
    {
        private readonly DB _context;
        private readonly IExcelImporter _excelImporter;
        private readonly IExcelExporter _excelExporter;
        public ColdStorageExcelService(DB context, IExcelImporter excelImporter, IExcelExporter excelExporter)
        {
            _context = context;
            _excelImporter = excelImporter;
            _excelExporter = excelExporter;
        }
        public async Task ImportColdStoragesAsync(Stream fileStream, ClaimsPrincipal user)
        {
            var result = await _excelImporter.Import<ColdStorageImportRequest>(fileStream);

            var coldStorages = result.Data.Select(response => new ColdStorage
            {
                Number = response.ColdStorageNumber,
                CreatorID = AuthenticationHelper.GetUserIDAsync(user),
                CreatedOn = PresentDateTimeFetcher.FetchPresentDateTime(),
                RecordStatus = RecordStatus.Active
            });
            await _context.ColdStorage.AddRangeAsync(coldStorages);
            await _context.SaveChangesAsync();
        }
        public async Task<byte[]> ExportColdStoragesAsync()
        {
            var coldStorages = await _context.ColdStorage
                .AsNoTracking()
                .Select(response => new ColdStorageImportRequest
                {
                    ColdStorageNumber = response.Number
                })
                .ToListAsync();
            var file = await _excelExporter.ExportAsByteArray(coldStorages);
            return file;
        }
    }
}