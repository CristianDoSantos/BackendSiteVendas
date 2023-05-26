using BackendSiteVendas.Comunication.Requests.User;
using BackendSiteVendas.Exceptions;
using FluentValidation;
using System.Text.RegularExpressions;

namespace BackendSiteVendas.Application.UseCases.User.Register;

public class RegisterUserValidator : AbstractValidator<UserRegisterRequestJson>
{
    public RegisterUserValidator()
    {
        RuleFor(user => user.Name).NotEmpty().WithMessage(ResourceCustomErrorMessages.BLANK_USER);
        RuleFor(user => user.Email).NotEmpty().WithMessage(ResourceCustomErrorMessages.BLANK_USER_EMAIL);
        RuleFor(user => user.Phone).NotEmpty().WithMessage(ResourceCustomErrorMessages.BLANK_USER_PHONE);
        RuleFor(user => user.Password).SetValidator(new PasswordValidator());
        When(user => !string.IsNullOrWhiteSpace(user.Email), () => {
            RuleFor(c => c.Email).EmailAddress().WithMessage(ResourceCustomErrorMessages.INVALID_USER_EMAIL);
        });
        When(user => !string.IsNullOrWhiteSpace(user.Phone), () => {
            RuleFor(user => user.Phone).Custom((phone, context) => {
                string phonePattern = "[0-9]{2} [1-9]{1} [0-9]{4}-[0-9]{4}";
                var isMatch = Regex.IsMatch(phone, phonePattern);
                if (!isMatch)
                {
                    context.AddFailure(new FluentValidation.Results.ValidationFailure(nameof(phone), ResourceCustomErrorMessages.INVALID_USER_PHONE));
                }
            });
        });
    }
}
