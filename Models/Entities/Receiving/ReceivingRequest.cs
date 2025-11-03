namespace CSMS_API.Models
{
    public class CreateReceivingRequest
    {
        public string? DocumentNo { get; set; }
        public string? CVNumber { get; set; }
        public string? PlateNumber { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public string? UnloadingStart { get; set; }
        public string? UnloadingEnd { get; set; }
    }
    public class UpdateReceivingRequest
    {
        public string? DocumentNo { get; set; }
        public string? CVNumber { get; set; }
        public string? PlateNumber { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public string? UnloadingStart { get; set; }
        public string? UnloadingEnd { get; set; }
        public List<CreateReceivingDetailRequest>? ReceivingDetail { get; set; }
    }
    public class CreateReceivingDetailRequest
    {
        public int? ProductID { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public DateTime? ProductionDate { get; set; }
        public int? QuantityInPallet { get; set; }
        public int? DUQuantity { get; set; }
        public double? TotalWeight { get; set; }
        public string? Remark { get; set; }
    }
    public class UpdateReceivingDetailRequest
    {
        public int? ProductID { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public DateTime? ProductionDate { get; set; }
        public int? QuantityInPallet { get; set; }
        public int? DUQuantity { get; set; }
        public double? TotalWeight { get; set; }
        public string? Remark { get; set; }
    }
}