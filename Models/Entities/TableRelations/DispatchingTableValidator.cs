using FluentValidation;

namespace CSMS_API.Models
{
    public class CreateDispatchingPlacementValidator : AbstractValidator<CreateDispatchingPlacementRequest>
    {
        public CreateDispatchingPlacementValidator()
        {
            RuleFor(x => x.ReceivingPlacementID)
                .NotEmpty().WithMessage("Receiving Placement ID required");
            RuleFor(x => x.DispatchingDetailID)
                .NotEmpty().WithMessage("Dispatching Detail ID required");
            RuleFor(x => x.PalletID)
                .NotEmpty().WithMessage("Pallet ID required");
            RuleFor(x => x.PalletPositionID)
                .NotEmpty().WithMessage("Pallet Position ID required");
            RuleFor(x => x.Quantity)
                .NotEmpty().WithMessage("Quantity required");
            RuleFor(x => x.Weight)
                .NotEmpty().WithMessage("Weight required");
        }
    }
}