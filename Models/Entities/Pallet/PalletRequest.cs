namespace CSMS_API.Models
{
    public class CreatePalletRequest
    {
        public string? Type { get; set; }
        public string? Number { get; set; }
    }
    public class UpdatePalletRequest
    {
        public string? Type { get; set; }
        public string? Number { get; set; }
    }
    public class CreatePalletPositionRequest
    {
        public int? ColdStorageID { get; set; }
        public string? Wing { get; set; }
        public string? Floor { get; set; }
        public string? Column { get; set; }
        public string? Side { get; set; }
    }
    public class UpdatePalletPositionRequest
    {
        public int? ColdStorageID { get; set; }
        public string? Wing { get; set; }
        public string? Floor { get; set; }
        public string? Column { get; set; }
        public string? Side { get; set; }
    }
}