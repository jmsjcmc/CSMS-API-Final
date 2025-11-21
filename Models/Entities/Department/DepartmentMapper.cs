namespace CSMS_API.Models
{
    public static class ManualDepartmentMapping
    {
        public static DepartmentOnlyResponse ManualDepartmentOnlyResponse(Department department)
        {
            return new DepartmentOnlyResponse
            {
                ID = department.ID,
                Name = department.Name,
                RecordStatus = department.RecordStatus
            };
        }
        public static List<DepartmentOnlyResponse> ManualDepartmentOnlyListResponse(List<Department> departments)
        {
            return departments
                .Select(ManualDepartmentOnlyResponse)
                .ToList();
        }
        public static DepartmentWithPositionResponse ManualDepartmentWithPositionResponse(Department department)
        {
            return new DepartmentWithPositionResponse
            {
                ID = department.ID,
                Name = department.Name,
                RecordStatus = department.RecordStatus,
                Position = department.Position != null
                ? ManualPositionMapping.ManualPositionOnlyListResponse(department.Position.ToList())
                : null
            };
        }
        public static List<DepartmentWithPositionResponse> ManualDepartmentWithPositionListResponse(List<Department> departments)
        {
            return departments
                .Select(ManualDepartmentWithPositionResponse)
                .ToList();
        }
    }
}