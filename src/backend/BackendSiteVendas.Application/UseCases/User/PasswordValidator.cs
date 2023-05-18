using BackendSiteVendas.Exceptions;
using FluentValidation;

namespace BackendSiteVendas.Application.UseCases.User;

internal class PasswordValidator : AbstractValidator<string>
{
    public PasswordValidator()
    {
        RuleFor(password => password).NotEmpty().WithMessage(ResourceCustomErrorMessages.BLANK_USER_PASSWORD);
        When(password => !string.IsNullOrWhiteSpace(password), () => {
            RuleFor(password => password.Length).GreaterThanOrEqualTo(6).WithMessage(ResourceCustomErrorMessages.USER_PASSWORD_MIN_SIX_CHARACTERES);
        });
    }
    
}
