namespace CSMS_API.Models.Entities
{
    public class CreateBusinessUnitRequest
    {
        public string? Name { get; set; }
        public string? Location { get; set; }
    }
    public class UpdateBusinessUnitRequest
    {
        public string? Name { get; set; }
        public string? Location { get; set; }
    }
}