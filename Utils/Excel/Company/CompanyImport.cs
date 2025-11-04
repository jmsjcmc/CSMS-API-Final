using Magicodes.ExporterAndImporter.Core;
using Magicodes.ExporterAndImporter.Excel;

namespace CSMS_API.Utils
{
    [ExcelImporter(IsLabelingError = true)]
    public class CompanyImportRequest
    {
        [ImporterHeader(Name = "Company Name")]
        public string? Name { get; set; }
        [ImporterHeader(Name = "Location")]
        public string? Location { get; set; }
        [ImporterHeader(Name = "Email")]
        public string? Email { get; set; }
        [ImporterHeader(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }
        [ImporterHeader(Name = "Telephone Number")]
        public string? TelephoneNumber { get; set; }
    }
}