using FluentValidation;

namespace CSMS_API.Models
{
    public class CreateUserValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First Name required");
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last Name required");
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username required");
            RuleFor(x => x.BusinessUnitID)
                .NotEmpty().WithMessage("Business Unit ID required");
        }
    }
}
