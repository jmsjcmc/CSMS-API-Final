namespace CSMS_API.Models
{
    public class DispatchingPlacementOnlyResponse
    {
        public int ID { get; set; }
        public int? Quantity { get; set; }
        public double? Weight { get; set; }
    }
    public class DispatchingPlacementWithReceivingPlacementDispatchingPalletAndPalletPositionResponse
    {
        public int ID { get; set; }
        public int? ReceivingPlacementID { get; set; } // RECEIVING PLACEMENT
        public int? ReceivingPlacementQuantity { get; set; } // RECEIVING PLACEMENT
        public double? ReceivingPlacementWeight { get; set; } // RECEIVING PLACEMENT
        public string? TaggingNumber { get; set; } // RECEIVING PLACEMENT
        public string? CrateNumber { get; set; } // RECEIVING PLACEMENT
        public int? DispatchingID { get; set; } // DISPATCHING
        public string? DocumentNo { get; set; } // DISPATCHING
        public DateTime? DispatchDate { get; set; } // DISPATCHING
        public string? DispatchTimeStart { get; set; } // DISPATCHING
        public string? DispatchTimeEnd { get; set; } // DISPATCHING
        public string? NMISCertificate { get; set; } // DISPATCHING
        public string? DispatchPlateNo { get; set; } // DISPATCHING
        public string? SealNo { get; set; } // DISPATCHING
        public double? OverAllWeight { get; set; } // DISPATCHING
        public int? PalletID { get; set; } // PALLET
        public string? Type { get; set; } // PALLET 
        public string? Number { get; set; } // PALLET
        public int? PalletPositionID { get; set; } // PALLET POSITION
        public int? ColdStorageID { get; set; } // PALLET POSITION, COLD STORAGE
        public string? ColdStorageNumber { get; set; } // PALLET POSITION, COLD STORAGE
        public string? Wing { get; set; } // PALLET POSITION
        public string? Floor { get; set; } // PALLET POSITION
        public string? Column { get; set; } // PALLET POSITION
        public string? Side { get; set; } // PALLET POSITION
        public int? Quantity { get; set; }
        public double? Weight { get; set; }
        public string? CreatorFullName { get; set; } // USER
        public DateTime? CreatedOn { get; set; }
        public string? ApproverFullName { get; set; } // USER
        public DateTime? ApprovedOn { get; set; }
        public DateTime? DeclinedOn { get; set; }
        public RecordStatus? RecordStatus { get; set; }
        public ApprovalStatus? ApprovalStatus { get; set; }
    }
    public class DispatchingPlacementWithReceivingPlacementDispatchingPalletAndPalletPositionObjectResponse
    {
        public int ID { get; set; }
        public ReceivingPlacementOnlyResponse? ReceivingPlacement { get; set; } // RECEIVING PLACEMENT
        public DispatchingOnlyResponse? Dispatching { get; set; } // DISPATCHING
        public PalletOnlyResponse? Pallet { get; set; } // PALLET 
        public PalletPositionOnlyResponse? PalletPosition { get; set; } // PALLET POSITION
        public int? Quantity { get; set; }
        public double? Weight { get; set; }
        public UserWithBusinessUnitAndPositionObjectResponse? Creator { get; set; } // USER
        public DateTime? CreatedOn { get; set; }
        public UserWithBusinessUnitAndPositionObjectResponse? Approver { get; set; } // USER
        public DateTime? ApprovedOn { get; set; }
        public DateTime? DeclinedOn { get; set; }
        public RecordStatus? RecordStatus { get; set; }
        public ApprovalStatus? ApprovalStatus { get; set; }
    }
}