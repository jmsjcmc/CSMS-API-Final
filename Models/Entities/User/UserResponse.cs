namespace CSMS_API.Models
{
    public class UserOnlyResponse
    {
        public int ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public DateTime? CreatedOn { get; set; }
        public RecordStatus? RecordStatus { get; set; }
    }
    public class UserWithBusinessUnitAndPositonResponse
    {

    }
    public class UserWithBusinessUnitAndPositionObjectResponse
    {
        public int ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public DateTime? CreatedOn { get; set; }
        public RecordStatus? RecordStatus { get; set; }
    }
    public class RoleOnlyResponse
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public DateTime? CreatedOn { get; set; }
        public RecordStatus? RecordStatus { get; set; }
    }
}
