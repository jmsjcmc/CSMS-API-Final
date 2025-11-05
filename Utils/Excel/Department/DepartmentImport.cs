using Magicodes.ExporterAndImporter.Core;
using Magicodes.ExporterAndImporter.Excel;

namespace CSMS_API.Utils
{
    [ExcelImporter(IsLabelingError = true)]
    public class DepartmentImportRequest
    {
        [ImporterHeader(Name = "Department Name")]
        public string? Name { get; set; }
    }
    public class PositionImportRequest
    {
        [ImporterHeader(Name = "Position Name")]
        public string? Name { get; set; }
        [ImporterHeader(Name = "Department Name")]
        public string? DepartmentName { get; set; }
    }
}