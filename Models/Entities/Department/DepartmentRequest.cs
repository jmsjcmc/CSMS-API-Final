using FluentValidation;

namespace CSMS_API.Models
{
    public class CreateCompanyValidator : AbstractValidator<CreateCompanyRequest>
    {
        public CreateCompanyValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name required");
            RuleFor(x => x.Location)
                .NotEmpty().WithMessage("Location required");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email required");
            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone Number required");
            RuleFor(x => x.TelephoneNumber)
                .NotEmpty().WithMessage("Telephone Number required");
        }
    }
    public class CreateRepresentativeValidator : AbstractValidator<CreateRepresentativeRequest>
    {
        public CreateRepresentativeValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First Name required");
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last Name required");
            RuleFor(x => x.Position)
                .NotEmpty().WithMessage("Position required");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email required");
            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone Number required");
            RuleFor(x => x.TelephoneNumber)
                .NotEmpty().WithMessage("Telephone Number required");
        }
    }
}