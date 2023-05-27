using BackendSiteVendas.Application.UseCases.User.Register;
using BackendSiteVendas.Exceptions;
using BackendSiteVendas.Exceptions.ExceptionsBase;
using FluentAssertions;
using UtilitiesForTests.Cryptography;
using UtilitiesForTests.Mapper;
using UtilitiesForTests.Repositories;
using UtilitiesForTests.Repositories.User;
using UtilitiesForTests.Requests.User;
using UtilitiesForTests.Token;
using Xunit;

namespace UseCases.Tests.User.Register;

public class RegisterUserUseCaseTest
{
    [Fact]
    public async Task Validate_Success()
    {
        var request = UserRegisterRequestBuilder.Build();

        var useCase = CreateUseCase();

        var response = await useCase.Execute(request);

        response.Should().NotBeNull();
        response.Token.Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public async Task Validate_Email_Already_Registered_Error()
    {
        var request = UserRegisterRequestBuilder.Build();

        var useCase = CreateUseCase(request.Email);

        Func<Task> action = async () => { await useCase.Execute(request); };

        await action.Should().ThrowAsync<ValidationErrorException>()
            .Where(exception => exception.ErrorMessages.Count == 1 && exception.ErrorMessages.Contains(ResourceCustomErrorMessages.EMAIL_ALREADY_REGISTERED));
    }

    [Fact]
    public async Task Validate_Blank_Email_Error()
    {
        var request = UserRegisterRequestBuilder.Build();
        request.Email = string.Empty;

        var useCase = CreateUseCase(request.Email);

        Func<Task> action = async () => { await useCase.Execute(request); };

        await action.Should().ThrowAsync<ValidationErrorException>()
            .Where(exception => exception.ErrorMessages.Count == 1 && exception.ErrorMessages.Contains(ResourceCustomErrorMessages.BLANK_USER_EMAIL));
    }

    private static RegisterUserUseCase CreateUseCase(string email = "")
    {
        var mapper = MapperBuilder.Instance();
        var repository = UserWriteOnlyRepositoryBuilder.Instance().Build();
        var unityOfWork = UnityOfWorkBuilder.Instance().Build();
        var passwordScrambler = PasswordScramblerBuilder.Instance();
        var token = TokenControllerBuilder.Instance();
        var userReadonlyRepository = UserReadOnlyRepositoryBuilder.Instance().ExistUserWithEmail(email).Build();


        return new RegisterUserUseCase(userReadonlyRepository, repository, mapper, unityOfWork, passwordScrambler, token);
    }
}
