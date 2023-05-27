using BackendSiteVendas.Comunication.Requests.Product;
using BackendSiteVendas.Exceptions;
using FluentValidation;

namespace BackendSiteVendas.Application.UseCases.Product.Register.Category
{
    public class CategoryValidator : AbstractValidator<CategoryRegisterRequestJson>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage(ResourceCustomErrorMessages.BLANK_CATEGORY_NAME);
            RuleFor(c => c.Description).NotEmpty().When(c => c.Description != null).WithMessage(ResourceCustomErrorMessages.BLANK_CATEGORY_DESCRIPTION);
            RuleFor(c => c.Description).MinimumLength(2).When(c => c.Description.Length > 0).WithMessage(ResourceCustomErrorMessages.SHORT_CATEGORY_DESCRIPTION);
        }
    }
}
