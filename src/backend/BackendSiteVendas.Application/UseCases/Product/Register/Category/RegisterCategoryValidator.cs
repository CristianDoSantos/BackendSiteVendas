using BackendSiteVendas.Comunication.Requests.Product;
using BackendSiteVendas.Exceptions;
using FluentValidation;

namespace BackendSiteVendas.Application.UseCases.Product.Register.Category;

public class RegisterCategoryValidator : AbstractValidator<CategoryRegisterRequestJson>
{
    public RegisterCategoryValidator()
    {
        RuleFor(c => c.Name).NotEmpty().WithMessage(ResourceCustomErrorMessages.BLANK_CATEGORY_NAME);
        RuleFor(c => c.Description)
            .NotEmpty().When(c => c.Description != null).WithMessage(ResourceCustomErrorMessages.BLANK_CATEGORY_DESCRIPTION)
            .MinimumLength(2).When(c => c.Description != null).WithMessage(ResourceCustomErrorMessages.SHORT_CATEGORY_DESCRIPTION);
    }
}
