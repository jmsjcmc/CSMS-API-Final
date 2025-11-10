using FluentValidation;

namespace CSMS_API.Models
{
    public class CreatePalletValidator : AbstractValidator<CreatePalletRequest>
    {
        public CreatePalletValidator()
        {
            RuleFor(x => x.Type)
                .NotEmpty().WithMessage("Type required");
            RuleFor(x => x.Number)
                .NotEmpty().WithMessage("Number required");
        }
    }
    public class CreatePalletPositionValidator : AbstractValidator<CreatePalletPositionRequest>
    {
        public CreatePalletPositionValidator()
        {
            RuleFor(x => x.ColdStorageID)
                .NotEmpty().WithMessage("Cold Storage ID required");
            RuleFor(x => x.Wing)
                .NotEmpty().WithMessage("Wing required");
            RuleFor(x => x.Floor)
                .NotEmpty().WithMessage("Floor required");
            RuleFor(x => x.Column)
                .NotEmpty().WithMessage("Column required");
            RuleFor(x => x.Side)
                .NotEmpty().WithMessage("Side required");
        }
    }
}