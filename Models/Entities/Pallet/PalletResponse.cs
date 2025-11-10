namespace CSMS_API.Models
{
    public class PalletOnlyResponse
    {
        public int ID { get; set; }
        public string? Type { get; set; }
        public string? Number { get; set; }
        public DateTime? CreatedOn { get; set; }
        public RecordStatus? RecordStatus { get; set; }
        public PalletOccupationStatus? PalletOccupationStatus { get; set; }
    }
    public class PalletPositionOnlyResponse
    {
        public int ID { get; set; }
        public string? Wing { get; set; }
        public string? Floor { get; set; }
        public string? Column { get; set; }
        public string? Side { get; set; }
        public DateTime? CreatedOn { get; set; }
        public RecordStatus? RecordStatus { get; set; }
        public PalletPositionStatus? PalletPositionStatus { get; set; }
    }
    public class PalletPositionWithColdStorageResponse
    {
        public int ID { get; set; }
        public int? ColdStorageID { get; set; } // COLD STORAGE
        public string? ColdStorageNumber { get; set; } // COLD STORAGE
        public string? Wing { get; set; }
        public string? Floor { get; set; }
        public string? Column { get; set; }
        public string? Side { get; set; }
        public DateTime? CreatedOn { get; set; }
        public RecordStatus? RecordStatus { get; set; }
        public PalletPositionStatus? PalletPositionStatus { get; set; }
    }
    public class PalletPositionWithColdStorageObjectResponse
    {
        public int ID { get; set; }
        public string? Wing { get; set; }
        public string? Floor { get; set; }
        public string? Column { get; set; }
        public string? Side { get; set; }
        public DateTime? CreatedOn { get; set; }
        public RecordStatus? RecordStatus { get; set; }
        public PalletPositionStatus? PalletPositionStatus { get; set; }
        public ColdStorageOnlyResponse? ColdStorage { get; set; } // COLD STORAGE
    }
    public class ColdStorageOnlyResponse
    {
        public int ID { get; set; }
        public string? Number { get; set; }
        public DateTime? CreatedOn { get; set; }
        public RecordStatus? RecordStatus { get; set; }
    }
}