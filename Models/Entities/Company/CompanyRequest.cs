namespace CSMS_API.Models
{
    public class CreateCompanyRequest
    {
        public string? Name { get; set; }
        public string? Location { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? TelephoneNumber { get; set; }
    }
    public class UpdateCompanyRequest
    {
        public string? Name { get; set; }
        public string? Location { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? TelephoneNumber { get; set; }
    }
    public class CreateRepresentativeRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Position { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? TelephoneNumber { get; set; }
    }
    public class UpdateRepresentativeRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Position { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? TelephoneNumber { get; set; }
    }
}
