namespace CSMS_API.Models
{
    public class DispatchingOnlyResponse
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
        public string? CreatorFullName { get; set; } // USER
        public DateTime? CreatedOn { get; set; }
        public string? ApproverFullName { get; set; } // USER
        public DateTime? ApprovedOn { get; set; } // USER
        public DateTime? DeclinedOn { get; set; } // USER
        public RecordStatus? RecordStatus { get; set; }
    }
    public class DispatchingWithDispatchingPlacementResponse
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
        public string? CreatorFullName { get; set; } // USER
        public DateTime? CreatedOn { get; set; }
        public string? ApproverFullName { get; set; } // USER
        public DateTime? ApprovedOn { get; set; } // USER
        public DateTime? DeclinedOn { get; set; } // USER
        public RecordStatus? RecordStatus { get; set; }
        public List<DispatchingPlacementOnlyResponse>? DispatchingPlacement { get; set; } // DISPATCHING PLACEMENT
    }
}