using BackendSiteVendas.Comunication.Requests;
using FluentValidation;

namespace BackendSiteVendas.Application.UseCases.User.ChangePassword;

public class ChangePasswordValidator : AbstractValidator<ChangePasswordRequestJson>
{
    public ChangePasswordValidator()
    {
        RuleFor(r => r.NewPassword).SetValidator(new PasswordValidator());
    }
}
