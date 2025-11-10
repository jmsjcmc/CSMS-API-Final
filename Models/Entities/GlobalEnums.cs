using FluentValidation;

namespace CSMS_API.Models
{
    public enum RecordStatus
    {
        Active = 1,
        Inactive = 0
    }
    public enum ApprovalStatus
    {
        Pending = 1,
        Approved = 2,
        Declined = 0,
    }
    public enum PalletOccupationStatus
    {
        Full = 2,
        Partial = 1,
        Empty = 0
    }
    public enum PalletPositionStatus
    {
        Occupied = 1,
        Available = 0
    }
    public class Paginate<T>
    {
        public IEnumerable<T>? Items { get; set; }
        public int? TotalCount { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
    public class JwtSetting
    {
        public string? Key { get; set; }
        public string? Issuer { get; set; }
        public string? Audience { get; set; }
    }
    public class JwtValidator : AbstractValidator<JwtSetting>
    {
        public JwtValidator()
        {
            RuleFor(x => x.Key)
                .NotEmpty().WithMessage("Key required");
            RuleFor(x => x.Issuer)
                .NotEmpty().WithMessage("Issuer required");
            RuleFor(x => x.Audience)
                .NotEmpty().WithMessage("Audience required");
        }
    }
}
