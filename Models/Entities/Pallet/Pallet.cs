namespace CSMS_API.Models
{
    public class Pallet
    {
        public int ID { get; set; }
        public string? Type { get; set; }
        public string? Number { get; set; }
        public int? CreatorID { get; set; }
        public User? Creator { get; set; }
        public DateTime? CreatedOn { get; set; }
        public RecordStatus? RecordStatus { get; set; }
        public ICollection<PalletLog>? PalletLog { get; set; }
        public ICollection<ReceivingPlacement>? ReceivingPlacement { get; set; }
    }
    public class PalletLog
    {
        public int ID { get; set; }
        public int? PalletID { get; set; }
        public Pallet? Pallet { get; set; }
        public int? UpdaterID { get; set; }
        public User? Updater { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
    public class PalletPosition
    {
        public int ID { get; set; }
        public int? ColdStorageID { get; set; }
        public ColdStorage? ColdStorage { get; set; }
        public string? Wing { get; set; }
        public string? Floor { get; set; }
        public string? Column { get; set; }
        public string? Side { get; set; }
        public int? CreatorID { get; set; }
        public User? Creator { get; set; }
        public DateTime? CreatedOn { get; set; }
        public RecordStatus? RecordStatus { get; set; }
        public ICollection<PalletPositionLog>? PalletPositionLog { get; set; }
        public ICollection<ReceivingPlacement>? ReceivingPlacement { get; set; }
    }
    public class PalletPositionLog
    {
        public int ID { get; set; }
        public int? PalletPositionID { get; set; }
        public PalletPosition? PalletPosition { get; set; }
        public int? UpdaterID { get; set; }
        public User? Updater { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
    public class ColdStorage
    {
        public int ID { get; set; }
        public string? Number { get; set; }
        public int? CreatorID { get; set; }
        public User? Creator { get; set; }
        public DateTime? CreatedOn { get; set; }
        public RecordStatus? RecordStatus { get; set; }
        public ICollection<PalletPosition>? PalletPosition { get; set; }
        public ICollection<ColdStorageLog>? ColdStorageLog { get; set; }
    }
    public class ColdStorageLog
    {
        public int ID { get; set; }
        public int? ColdStorageID { get; set; }
        public ColdStorage? ColdStorage { get; set; }
        public int? UpdaterID { get; set; }
        public User? Updater { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}