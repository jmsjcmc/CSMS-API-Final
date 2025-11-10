namespace CSMS_API.Models
{
    public class CreateDispatchingRequest
    {
        public int ID { get; set; }
        public string? DocumentNo { get; set; }
        public DateTime? DispatchDate { get; set; }
        public string? DispatchTimeStart { get; set; }
        public string? DispatchTimeEnd { get; set; }
        public string? NMISCertificate { get; set; }
        public string? DispatchPlateNo { get; set; }
        public string? SealNo { get; set; }
        public double? OverAllWeight { get; set; }
        public List<CreateDispatchingPlacementRequest>? DispatchingPlacement { get; set; }
    }
    public class UpdateDispatchingRequest
    {
        public int ID { get; set; }
        public string? DocumentNo { get; set; }
        public DateTime? DispatchDate { get; set; }
        public string? DispatchTimeStart { get; set; }
        public string? DispatchTimeEnd { get; set; }
        public string? NMISCertificate { get; set; }
        public string? DispatchPlateNo { get; set; }
        public string? SealNo { get; set; }
        public double? OverAllWeight { get; set; }
        public List<CreateDispatchingPlacementRequest>? DispatchingPlacement { get; set; }
    }
}