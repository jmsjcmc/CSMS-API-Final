using FluentValidation;

namespace CSMS_API.Models
{
    public class CreateReceivingValidator : AbstractValidator<CreateReceivingRequest>
    {
        public CreateReceivingValidator()
        {
            RuleFor(x => x.DocumentNo)
                .NotEmpty().WithMessage("Document Number required");
            RuleFor(x => x.CVNumber)
                .NotEmpty().WithMessage("CV Number required");
            RuleFor(x => x.PlateNumber)
                .NotEmpty().WithMessage("Plate Number required");
            RuleFor(x => x.ArrivalDate)
                .NotEmpty().WithMessage("Arrival Date required");
            RuleFor(x => x.UnloadingStart)
                .NotEmpty().WithMessage("Unloading Start required");
            RuleFor(x => x.UnloadingEnd)
                .NotEmpty().WithMessage("Unloading End required");
        }
    }
    public class CreateReceivingDetailValidator : AbstractValidator<CreateReceivingDetailRequest>
    {
        public CreateReceivingDetailValidator()
        {
            RuleFor(x => x.ProductID)
                .NotEmpty().WithMessage("Product ID required");
            RuleFor(x => x.ExpirationDate)
                .NotEmpty().WithMessage("Expiration Date required");
            RuleFor(x => x.ProductionDate)
                .NotEmpty().WithMessage("Production Date required");
            RuleFor(x => x.QuantityInPallet)
                .NotEmpty().WithMessage("Quantity in Pallet required");
            RuleFor(x => x.DUQuantity)
                .NotEmpty().WithMessage("DU Quantity required");
            RuleFor(x => x.TotalWeight)
                .NotEmpty().WithMessage("Total Weight required");
            RuleFor(x => x.Remark)
                .NotEmpty().WithMessage("Remark required");
        }
    }
}