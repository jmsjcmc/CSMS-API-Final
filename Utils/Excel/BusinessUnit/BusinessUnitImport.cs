using Magicodes.ExporterAndImporter.Core;
using Magicodes.ExporterAndImporter.Excel;

namespace CSMS_API.Utils
{
    [ExcelImporter(IsLabelingError = true)]
    public class BusinessUnitImportRequest
    {
        [ImporterHeader(Name = "Business Unit Name")]
        public string? Name { get; set; }
        [ImporterHeader(Name = "Business Unit Location")]
        public string? Location { get; set; }
    }
}