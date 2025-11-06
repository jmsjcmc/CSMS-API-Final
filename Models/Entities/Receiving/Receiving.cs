namespace CSMS_API.Models
{
    public class Receiving
    {
        public int ID { get; set; }
        public string? DocumentNo { get; set; }
        public string? CVNumber { get; set; }
        public string? PlateNumber { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public string? UnloadingStart { get; set; }
        public string? UnloadingEnd { get; set; }
        public int? CreatorID { get; set; }
        public User? Creator { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ApproverID { get; set; }
        public User? Approver { get; set; }
        public DateTime? DateReceived { get; set; }
        public RecordStatus? RecordStatus { get; set; }
        public ICollection<ReceivingLog>? ReceivingLog { get; set; }
        public ICollection<ReceivingDetail>? ReceivingDetail { get; set; }
        public ICollection<ReceivingProduct>? ReceivingProduct { get; set; }
    }
    public class ReceivingLog
    {
        public int ID { get; set; }
        public int? ReceivingID { get; set; }
        public Receiving? Receiving { get; set; }
        public int? UpdaterID { get; set; }
        public User? Updater { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
    public class ReceivingDetail
    {
        public int ID { get; set; }
        public int? ReceivingID { get; set; }
        public Receiving? Receiving { get; set; }
        public int? ProductID { get; set; }
        public Product? Product { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public DateTime? ProductionDate { get; set; }
        public int? QuantityInPallet { get; set; }
        public int? DUQuantity { get; set; }
        public double? TotalWeight { get; set; }
        public string? Remark { get; set; }
        public int? CreatorID { get; set; }
        public User? Creator { get; set; }
        public DateTime? CreatedOn { get; set; }
        public ICollection<ReceivingDetailLog>? ReceivingDetailLog { get; set; }
    }
    public class ReceivingDetailLog
    {
        public int ID { get; set; }
        public int? ReceivingDetailID { get; set; }
        public ReceivingDetail? ReceivingDetail { get; set; }
        public int? UpdaterID { get; set; }
        public User? Updater { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}