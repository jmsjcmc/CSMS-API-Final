namespace CSMS_API.Models
{
    public class User
    {
        public int ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public int? BusinessUnitID { get; set; }
        public BusinessUnit? BusinessUnit { get; set; }
        public int? PositionID { get; set; }
        public Position? Position { get; set; }
        public int? CreatorID { get; set; }
        public User? Creator { get; set; }
        public DateTime? CreatedOn { get; set; }
        public RecordStatus? RecordStatus { get; set; }
        public ICollection<UserRole>? UserRole { get; set; }
        public ICollection<UserLog>? UserLog { get; set; }
    }
    public class UserLog
    {
        public int ID { get; set; }
        public int? UserID { get; set; }
        public User? User { get; set; }
        public int? UpdaterID { get; set; }
        public User? Updater { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
    public class Role
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public int? CreatorID { get; set; }
        public User? Creator { get; set; }
        public DateTime? CreatedOn { get; set; }
        public RecordStatus? RecordStatus { get; set; }
        public ICollection<UserRole>? UserRole { get; set; }
        public ICollection<RoleLog>? RoleLog { get; set; }
    }
    public class RoleLog
    {
        public int ID { get; set; }
        public int? RoleID { get; set; }
        public Role? Role { get; set; }
        public int? UpdatedID { get; set; }
        public User? Updater { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
    public class UserRole
    {
        public int ID { get; set; }
        public int? UserID { get; set; }
        public User? User { get; set; }
        public int? RoleID { get; set; }
        public Role? Role { get; set; }
        public DateTime? AssignedOn { get; set; }
    }
    public class BusinessUnit
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public int? CreatorID { get; set; }
        public User? Creator { get; set; }
        public DateTime? CreatedOn { get; set; }
        public ICollection<User>? User { get; set; }
        public ICollection<BusinessUnitLog>? BusinessUnitLog { get; set; }
    }
    public class BusinessUnitLog
    {
        public int ID { get; set; }
        public int? BusinessUnitID { get; set; }
        public BusinessUnit? BusinessUnit { get; set; }
        public int? UpdaterID { get; set; }
        public User? Updater { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
    public class Department
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public int? CreatorID { get; set; }
        public User? Creator { get; set; }
        public DateTime? CreatedOn { get; set; }
        public ICollection<Position>? Position { get; set; }
        public ICollection<DepartmentLog>? DepartmentLog { get; set; }
    }
    public class DepartmentLog
    {
        public int ID { get; set; }
        public int? DepartmentID { get; set; }
        public Department? Department { get; set; }
        public int? UpdaterID { get; set; }
        public User? Updater { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
    public class Position
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public int? DepartmentID { get; set; }
        public Department? Department { get; set; }
        public int? CreatorID { get; set; }
        public User? Creator { get; set; }
        public DateTime? CreatedOn { get; set; }
        public ICollection<PositionLog>? PositionLog { get; set; }
        public ICollection<User>? User { get; set; }
    }
    public class PositionLog
    {
        public int ID { get; set; }
        public int? PositionID { get; set; }
        public Position? Position { get; set; }
        public int? UpdaterID { get; set; }
        public User? Updater { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
