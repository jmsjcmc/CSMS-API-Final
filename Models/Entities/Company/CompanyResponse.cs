namespace CSMS_API.Models
{
    public class CompanyOnlyResponse
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? TelephoneNumber { get; set; }
        public RecordStatus? RecordStatus { get; set; }
    }
    public class CompanyWithRepresentativeResponse
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? TelephoneNumber { get; set; }
        public RecordStatus? RecordStatus { get; set; }
        public List<RepresentativeOnlyResponse>? Representative { get; set; }
    }
    public class RepresentativeOnlyResponse
    {
        public int ID { get; set; }
        public string? FullName { get; set; }
        public string? Position { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? TelephoneNumber { get; set; }
        public RecordStatus? RecordStatus { get; set; }
    }
    public class RepresentativeWithCompanyResponse
    {
        public int ID { get; set; }
        public string? FullName { get; set; }
        public string? Position { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? TelephoneNumber { get; set; }
        public RecordStatus? RecordStatus { get; set; }
         public string? CompanyName { get; set; } // COMPANY
        public string? CompanyLocation { get; set; } // COMPANY
    }
}
