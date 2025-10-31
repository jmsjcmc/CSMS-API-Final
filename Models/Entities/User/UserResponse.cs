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
        public int ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Username { get; set; }
        public int? BusinessUnitID { get; set; } // BUSINESS UNIT
        public string? BusinessUnitName { get; set; } // BUSINESS UNIT
        public string? BusinessUnitLocation { get; set; } // BUSINESS UNIT
        public int? PositionID { get; set; } // POSITION
        public string? PositionName { get; set; } // POSITION
        public int DepartmentID { get; set; } // POSITION -> DEPARTMENT
        public string? DepartmentName { get; set; } // POSITION -> DEPARTMENT
    }
    public class UserWithBusinessUnitAndPositionObjectResponse
    {
        public int ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Username { get; set; }
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
