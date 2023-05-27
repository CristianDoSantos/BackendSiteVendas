using BackendSiteVendas.Application.UseCases.User.ChangePassword;
using BackendSiteVendas.Exceptions;
using FluentAssertions;
using UtilitiesForTests.Requests.Password;
using Xunit;

namespace Validators.Tests.User.ChangePassword;

public class ChangePasswordValidatorTest
{
    [Fact]
    public void Validate_Success()
    {
        var validator = new ChangePasswordValidator();

        var request = ChangePasswordRequestBuilder.Build();

        var result = validator.Validate(request);

        result.IsValid.Should().BeTrue();
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public void Validate_Invalid_Password_error(int passwordLength)
    {
        var validator = new ChangePasswordValidator();

        var request = ChangePasswordRequestBuilder.Build(passwordLength);

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceCustomErrorMessages.USER_PASSWORD_MIN_SIX_CHARACTERES));
    }

    [Fact]
    public void Validate_Blank_Password_Error()
    {
        var validator = new ChangePasswordValidator();

        var request = ChangePasswordRequestBuilder.Build();
        request.NewPassword = string.Empty;

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceCustomErrorMessages.BLANK_USER_PASSWORD));
    }
}
