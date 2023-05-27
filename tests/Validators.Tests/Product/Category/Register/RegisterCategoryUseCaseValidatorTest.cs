using BackendSiteVendas.Application.UseCases.Product.Register.Category;
using BackendSiteVendas.Exceptions;
using FluentAssertions;
using UtilitiesForTests.Requests.Product.Category;
using Xunit;

namespace Validators.Tests.Product.Category.Register;

public  class RegisterCategoryUseCaseValidatorTest
{
    [Fact]
    public void Validate_Success()
    {
        var validator = new RegisterCategoryValidator();

        var request = CategoryRegisterRequestBuilder.Build();

        var result = validator.Validate(request);

        result.IsValid.Should().BeTrue();
    }

    [Fact]
    public void Validate_Blank_Name_Error()
    {
        var validator = new RegisterCategoryValidator();

        var request = CategoryRegisterRequestBuilder.Build();
        request.Name = string.Empty;

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(err => err.ErrorMessage.Equals(ResourceCustomErrorMessages.BLANK_CATEGORY_NAME));
    }

    [Fact]
    public void Validate_Blank_Description_Error()
    {
        var validator = new RegisterCategoryValidator();

        var request = CategoryRegisterRequestBuilder.Build();
        request.Description = string.Empty;

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should()
            .Contain(err => err.ErrorMessage.Equals(ResourceCustomErrorMessages.BLANK_CATEGORY_DESCRIPTION))
            .And.Contain(err => err.ErrorMessage.Equals(ResourceCustomErrorMessages.SHORT_CATEGORY_DESCRIPTION));
    }
}