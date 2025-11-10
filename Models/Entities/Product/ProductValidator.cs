using FluentValidation;

namespace CSMS_API.Models
{
    public class CreateProductValidator : AbstractValidator<CreateProductRequest>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.CategoryID)
                .NotEmpty().WithMessage("Category ID required");
            RuleFor(x => x.CompanyID)
               .NotEmpty().WithMessage("Company ID required");
            RuleFor(x => x.ProductCode)
               .NotEmpty().WithMessage("Product Code required");
            RuleFor(x => x.ProductName)
               .NotEmpty().WithMessage("Product Name required");
            RuleFor(x => x.Variant)
               .NotEmpty().WithMessage("Variant required");
            RuleFor(x => x.SKU)
               .NotEmpty().WithMessage("SKU required");
            RuleFor(x => x.ProductPackaging)
               .NotEmpty().WithMessage("Product Packaging required");
            RuleFor(x => x.DeliveryUnit)
               .NotEmpty().WithMessage("Delivery Unit required");
            RuleFor(x => x.UOM)
               .NotEmpty().WithMessage("UOM required");
            RuleFor(x => x.Unit)
               .NotEmpty().WithMessage("Unit required");
            RuleFor(x => x.Quantity)
               .NotEmpty().WithMessage("Quantity required");
            RuleFor(x => x.Weight)
               .NotEmpty().WithMessage("Weight required");
        }
    }
}