namespace CSMS_API.Models
{
     public class PositionOnlyResponse
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public RecordStatus? RecordStatus { get; set; }
    }
    public class PositionWithDepartmentResponse
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public RecordStatus? RecordStatus { get; set; }
        public int? DepartmentID { get; set; } // DEPARTMENT
        public string? DepartmentName { get; set; } // DEPARTMENT
    }
}