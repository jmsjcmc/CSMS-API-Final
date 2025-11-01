namespace CSMS_API.Models
{
    public class Company
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? TelephoneNumber { get; set; }
        public RecordStatus? RecordStatus { get; set; }
        public ICollection<Representative>? Representative { get; set; }
    }
    public class Representative
    {
        public int ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Position { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? TelephoneNumber { get; set; }
        public int? CompanyID { get; set; }
        public Company? Company { get; set; }
        public RecordStatus? RecordStatus { get; set; }
    }
}
