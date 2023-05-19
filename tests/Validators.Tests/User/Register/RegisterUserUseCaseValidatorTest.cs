using BackendSiteVendas.Application.UseCases.User.Register;
using BackendSiteVendas.Exceptions;
using FluentAssertions;
using UtilitiesForTests.Requests;
using Xunit;

namespace Validators.Tests.User.Register;

public class RegisterUserUseCaseValidatorTest
{
    [Fact]
    public void Validate_Success()
    {
        var validator = new RegisterUserValidator();

        var request = UserRegisterRequestBuilder.Build();

        var result = validator.Validate(request);

        result.IsValid.Should().BeTrue();
    }

    [Fact]
    public void Validate_Blank_Name_Error()
    {
        var validator = new RegisterUserValidator();

        var request = UserRegisterRequestBuilder.Build();
        request.Name = string.Empty;

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceCustomErrorMessages.BLANK_USER));
    }

    [Fact]
    public void Validate_Blank_Email_Error()
    {
        var validator = new RegisterUserValidator();

        var request = UserRegisterRequestBuilder.Build();
        request.Email = string.Empty;

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceCustomErrorMessages.BLANK_USER_EMAIL));
    }

    [Fact]
    public void Validate_Blank_Password_Error()
    {
        var validator = new RegisterUserValidator();

        var request = UserRegisterRequestBuilder.Build();
        request.Password = string.Empty;

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceCustomErrorMessages.BLANK_USER_PASSWORD));
    }

    [Fact]
    public void Validate_Blank_Phone_Error()
    {
        var validator = new RegisterUserValidator();

        var request = UserRegisterRequestBuilder.Build();
        request.Phone = string.Empty;

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceCustomErrorMessages.BLANK_USER_PHONE));
    }

    [Fact]
    public void Validate_Invalid_Email_Error()
    {
        var validator = new RegisterUserValidator();

        var request = UserRegisterRequestBuilder.Build();
        request.Email = "wrongEmail";

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceCustomErrorMessages.INVALID_USER_EMAIL));
    }

    [Fact]
    public void Validate_Invalid_Phone_Error()
    {
        var validator = new RegisterUserValidator();

        var request = UserRegisterRequestBuilder.Build();
        request.Phone = "47 9";

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceCustomErrorMessages.INVALID_USER_PHONE));
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public void Validate_Invalid_Password_Error(int passwordLength)
    {
        var validator = new RegisterUserValidator();

        var request = UserRegisterRequestBuilder.Build(passwordLength);

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceCustomErrorMessages.USER_PASSWORD_MIN_SIX_CHARACTERES));
    }
}
