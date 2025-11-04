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
    public class RepresentativeImportRequest
    {
        [ImporterHeader(Name = "First Name")]
        public string? FirstName { get; set; }
        [ImporterHeader(Name = "Last Name")]
        public string? LastName { get; set; }
        [ImporterHeader(Name = "Position")]
        public string? Position { get; set; }
        [ImporterHeader(Name = "Email")]
        public string? Email { get; set; }
        [ImporterHeader(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }
        [ImporterHeader(Name = "Telephone Number")]
        public string? TelephoneNumber { get; set; }
        [ImporterHeader(Name = "Company Name")]
        public string? CompanyName { get; set; }
    }
}