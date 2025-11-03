namespace CSMS_API.Models
{
    public class CreateUserRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public int? BusinessUnitID { get; set; }
        public int? PositionID { get; set; }
    }
    public class UpdateUserRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public int? BusinessUnitID { get; set; }
        public int? PositionID { get; set; }
    }
    public class UserLoginRequest
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
