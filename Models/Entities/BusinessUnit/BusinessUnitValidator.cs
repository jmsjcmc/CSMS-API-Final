using FluentValidation;

namespace CSMS_API.Models.Entities
{
    public class CreateBusinessUnitValidator : AbstractValidator<CreateBusinessUnitRequest>
    {
        public CreateBusinessUnitValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Business Unit Name required");
            RuleFor(x => x.Location)
            .NotEmpty().WithMessage("Business Unit Location required");
        }
    }
}