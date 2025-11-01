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
        public int? CreatorID { get; set; } 
        public User? Creator { get; set; }
        public DateTime? CreatedOn { get; set; }
        public ICollection<Representative>? Representative { get; set; }
        public ICollection<CompanyLog>? CompanyLog { get; set; }
        public ICollection<Product>? Product { get; set; }
    }
    public class CompanyLog
    {
        public int ID { get; set; }
        public int? CompanyID { get; set; }
        public Company? Company { get; set; }
        public int? UpdaterID { get; set; }
        public User? Updater { get; set; }
        public DateTime? UpdatedOn { get; set; }
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
        public int? CreatorID { get; set; } 
        public User? Creator { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CompanyID { get; set; }
        public Company? Company { get; set; }
        public RecordStatus? RecordStatus { get; set; }
        public ICollection<RepresentativeLog>? RepresentativeLog { get; set; }
    }
    public class RepresentativeLog
    {
        public int ID { get; set; }
        public int? RepresentativeID { get; set; }
        public Representative? Representative { get; set; }
        public int? UpdaterID { get; set; }
        public User? Updater { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
