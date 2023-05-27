using BackendSiteVendas.Application.UseCases.Product.Register.Category;
using BackendSiteVendas.Exceptions.ExceptionsBase;
using BackendSiteVendas.Exceptions;
using FluentAssertions;
using UtilitiesForTests.Mapper;
using UtilitiesForTests.Repositories;
using UtilitiesForTests.Repositories.Product.Category;
using UtilitiesForTests.Requests.Product.Category;
using Xunit;

namespace UseCases.Tests.Product.Category.Register;

public class RegisterCategoryUseCaseTest
{
    [Fact]
    public async Task Validate_Success()
    {
        var request = CategoryRegisterRequestBuilder.Build();

        var useCase = CreateUseCase();

        var response = await useCase.Execute(request);

        response.Should().NotBeNull();
        response.Name.Should().NotBeNull();
        response.Description.Should().NotBeNull();
    }

    [Fact]
    public async Task Validate_Blank_Name_Error()
    {
        var request = CategoryRegisterRequestBuilder.Build();
        request.Name = string.Empty;

        var useCase = CreateUseCase();

        Func<Task> action = async () => { await useCase.Execute(request); };

        await action.Should().ThrowAsync<ValidationErrorException>()
            .Where(exception => exception.ErrorMessages.Count == 1 && exception.ErrorMessages.Contains(ResourceCustomErrorMessages.BLANK_CATEGORY_NAME));
    }

    [Fact]
    public async Task Validate_Blank_Description_Error()
    {
        var request = CategoryRegisterRequestBuilder.Build();
        request.Description = string.Empty;

        var useCase = CreateUseCase();

        Func<Task> action = async () => { await useCase.Execute(request); };

        await action.Should().ThrowAsync<ValidationErrorException>()
            .Where(exception => exception.ErrorMessages.Count == 1 && exception.ErrorMessages.Contains(ResourceCustomErrorMessages.BLANK_CATEGORY_DESCRIPTION));
    }

    [Fact]
    public async Task Validate_Minimum_Description_Characteres_Error()
    {
        var request = CategoryRegisterRequestBuilder.Build();
        request.Description = "a";

        var useCase = CreateUseCase();

        Func<Task> action = async () => { await useCase.Execute(request); };

        await action.Should().ThrowAsync<ValidationErrorException>()
            .Where(exception => exception.ErrorMessages.Count == 1 && exception.ErrorMessages.Contains(ResourceCustomErrorMessages.SHORT_CATEGORY_DESCRIPTION));
    }

    private static RegisterCategoryUseCase CreateUseCase()
    {
        var mapper = MapperBuilder.Instance();
        var unityOfWork = UnityOfWorkBuilder.Instance().Build();
        var categoryWriteOnlyRepository = CategoryWriteOnlyRepositoryBuilder.Instance().Build();

        return new RegisterCategoryUseCase(mapper, unityOfWork, categoryWriteOnlyRepository);
    }
}
