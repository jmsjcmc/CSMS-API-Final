using FluentValidation;

namespace CSMS_API.Models
{
    public class CreateDispatchingValidator : AbstractValidator<CreateDispatchingRequest>
    {
        public CreateDispatchingValidator()
        {
            RuleFor(x => x.DocumentNo)
                .NotEmpty().WithMessage("Document Number required");
            RuleFor(x => x.DispatchDate)
                .NotEmpty().WithMessage("Dispatch Date required");
            RuleFor(x => x.DispatchTimeStart)
                .NotEmpty().WithMessage("Dispatch Time Start required");
            RuleFor(x => x.DispatchTimeEnd)
                .NotEmpty().WithMessage("Dispatch Time End required");
            RuleFor(x => x.NMISCertificate)
                .NotEmpty().WithMessage("NMIS Certificate required");
            RuleFor(x => x.DispatchPlateNo)
                .NotEmpty().WithMessage("Dispatch Plate Number required");
            RuleFor(x => x.SealNo)
                .NotEmpty().WithMessage("Seal Number required");
            RuleFor(x => x.OverAllWeight)
                .NotEmpty().WithMessage("Over All Weight required");
        }
    }
}