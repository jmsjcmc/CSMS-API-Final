namespace CSMS_API.Models
{
    public class DepartmentOnlyResponse
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public RecordStatus? RecordStatus { get; set; }
    }
    public class DepartmentWithPositionResponse
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public RecordStatus? RecordStatus { get; set; }
        public List<PositionOnlyResponse>? Position { get; set; } // POSITION
    }
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