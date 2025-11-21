namespace CSMS_API.Models
{
    public class ManualPositionMapping
    {
        public static PositionOnlyResponse ManualPositionOnlyResponse(Position position)
        {
            return new PositionOnlyResponse
            {
                ID = position.ID,
                Name = position.Name,
                RecordStatus = position.RecordStatus,
            };
        }
        public static List<PositionOnlyResponse> ManualPositionOnlyListResponse(List<Position> positions)
        {
            return positions
                .Select(ManualPositionOnlyResponse)
                .ToList();
        }
        public static PositionWithDepartmentResponse ManualPositionWithDepartmentResponse(Position position)
        {
            return new PositionWithDepartmentResponse
            {
                ID = position.ID,
                Name = position.Name,
                RecordStatus = position.RecordStatus,
                DepartmentID = position.DepartmentID,
                DepartmentName = position.Department.Name != null
                ? position.Department.Name
                : null
            };
        }
        public static List<PositionWithDepartmentResponse> ManualPositionWithDepartmentListResponse(List<Position> positions)
        {
            return positions
                .Select(ManualPositionWithDepartmentResponse)
                .ToList();
        }
    }
}