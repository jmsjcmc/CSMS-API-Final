using Magicodes.ExporterAndImporter.Core;
using Magicodes.ExporterAndImporter.Excel;

namespace CSMS_API.Utils
{
    [ExcelImporter(IsLabelingError = true)]
    public class PalletImportRequest
    {
        [ImporterHeader(Name = "Pallet Type")]
        public string? Type { get; set; }
        [ImporterHeader(Name = "Pallet Number")]
        public string? Number { get; set; }
    }
    public class PalletPositionImportRequest
    {
        [ImporterHeader(Name = "CS Number")]
        public string? ColdStorageNumber { get; set; }
        [ImporterHeader(Name = "Wing")]
        public string? Wing { get; set; }
        [ImporterHeader(Name = "Floor")]
        public string? Floor { get; set; }
        [ImporterHeader(Name = "Column")]
        public string? Column { get; set; }
        [ImporterHeader(Name = "Side")]
        public string? Side { get; set; }
    }
    public class ColdStorageImportRequest
    {
        [ImporterHeader(Name = "CS Number")]
        public string? ColdStorageNumber { get; set; }
    }
}