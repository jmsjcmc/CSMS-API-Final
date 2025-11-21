using FluentValidation;

namespace CSMS_API.Models
{
    public class CreateReceivingProductValidator : AbstractValidator<CreateReceivingProductRequest>
    {
        public CreateReceivingProductValidator()
        {
            RuleFor(x => x.ReceivingID)
                .NotEmpty().WithMessage("Receiving ID required");
            RuleFor(x => x.ProductID)
                .NotEmpty().WithMessage("Product ID required");
            RuleFor(x => x.TotalQuantity)
                .NotEmpty().WithMessage("Total Quantity required");
            RuleFor(x => x.TotalWeight)
                .NotEmpty().WithMessage("Total Weight required");
        }
    }
    public class CreateReceivingPlacementValidator : AbstractValidator<CreateReceivingPlacementRequest>
    {
        public CreateReceivingPlacementValidator()
        {
            RuleFor(x => x.ReceivingProductID)
                .NotEmpty().WithMessage("Receiving Product ID required");
            RuleFor(x => x.ReceivingDetailID)
                .NotEmpty().WithMessage("Receiving Detail ID required");
            RuleFor(x => x.PalletID)
                .NotEmpty().WithMessage("Pallet ID required");
            RuleFor(x => x.PalletOccupationStatus)
                .NotEmpty().WithMessage("Pallet Occupation Status required");
            RuleFor(x => x.PalletPositionID)
                .NotEmpty().WithMessage("Pallet Position ID required");
            RuleFor(x => x.Quantity)
                .NotEmpty().WithMessage("Quantity required");
            RuleFor(x => x.Weight)
                .NotEmpty().WithMessage("Weight required");
            RuleFor(x => x.TaggingNumber)
                .NotEmpty().WithMessage("Tagging Number required");
            RuleFor(x => x.CrateNumber)
                .NotEmpty().WithMessage("Crate Number required");
        }
    }
}