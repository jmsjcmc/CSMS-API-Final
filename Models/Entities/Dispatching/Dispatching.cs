namespace CSMS_API.Models
{
    public class Dispatching
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
        public string? Note { get; set; }
        public int? CreatorID { get; set; }
        public User? Creator { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ApproverID { get; set; }
        public User? Approver { get; set; }
        public DateTime? ApprovedOn { get; set; }
        public DateTime? DeclinedOn { get; set; }
        public RecordStatus? RecordStatus { get; set; }
        public ICollection<DispatchingDetail>? DispatchingDetail { get; set; }
        public ICollection<DispatchingLog>? DispatchingLog { get; set; }
    }
    public class DispatchingLog
    {
        public int ID { get; set; }
        public int? DispatchingID { get; set; }
        public Dispatching? Dispatching { get; set; }
        public int? UpdaterID { get; set; }
        public DateTime? Updater { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
    public class DispatchingDetail
    {
        public int ID { get; set; }
        public int? ReceivingPlacementID { get; set; }
        public ReceivingPlacement? ReceivingPlacement { get; set; }
        public int? DispatchingID { get; set; }
        public Dispatching? Dispatching { get; set; }
        public RecordStatus? RecordStatus { get; set; }
        public ICollection<DispatchingPlacement>? DispatchingPlacement { get; set; }
        public ICollection<DispatchingDetailLog>? DispatchingDetailLog { get; set; }
    }
    public class DispatchingDetailLog
    {
        public int ID { get; set; }
        public int? DispatchingDetailID { get; set; }
        public DispatchingDetail? DispatchingDetail { get; set; }
        public int? UpdaterID { get; set; }
        public User? Updater { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}