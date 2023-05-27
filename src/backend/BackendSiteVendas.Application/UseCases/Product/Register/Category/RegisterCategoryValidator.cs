using BackendSiteVendas.Comunication.Requests.Product;
using BackendSiteVendas.Exceptions;
using FluentValidation;

namespace BackendSiteVendas.Application.UseCases.Product.Register.Category;

public class RegisterCategoryValidator : AbstractValidator<CategoryRegisterRequestJson>
{
    public RegisterCategoryValidator()
    {
        RuleFor(c => c).SetValidator(new CategoryValidator());
    }
}
