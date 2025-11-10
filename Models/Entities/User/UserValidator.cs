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
            RuleFor(x => x.PositionID)
                .NotEmpty().WithMessage("Position ID required");
        }
    }
    public class UserLoginValidator : AbstractValidator<UserLoginRequest>
    {
        public UserLoginValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username required");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password required");
        }
    }
}
