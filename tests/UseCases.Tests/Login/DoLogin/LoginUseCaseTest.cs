using BackendSiteVendas.Application.UseCases.Login.DoLogin;
using BackendSiteVendas.Exceptions;
using BackendSiteVendas.Exceptions.ExceptionsBase;
using FluentAssertions;
using UtilitiesForTests.Cryptography;
using UtilitiesForTests.Entities;
using UtilitiesForTests.Repositories;
using UtilitiesForTests.Token;
using Xunit;

namespace UseCases.Tests.Login.DoLogin;

public class LoginUseCaseTest
{
    [Fact]
    public async Task Validate_Success()
    {
        (var user, var password) = UserBuilder.Build();

        var useCase = CreateUseCase(user);

        var resposne = await useCase.Execute(new BackendSiteVendas.Comunication.Requests.LoginRequestJson
        {
            Email = user.Email,
            Password = password
        });

        resposne.Should().NotBeNull();
        resposne.Name.Should().Be(user.Name);
        resposne.Token.Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public async Task Validate_Invalid_Login_By_Password_Error()
    {
        (var user, var password) = UserBuilder.Build();

        var useCase = CreateUseCase(user);

        Func<Task> action = async () => 
        {
            await useCase.Execute(new BackendSiteVendas.Comunication.Requests.LoginRequestJson
            {
                Email = user.Email,
                Password = "InvalidPassword"
            });
        };

        await action.Should().ThrowAsync<InvalidLoginException>()
            .Where(exception => exception.Message.Equals(ResourceCustomErrorMessages.INVALID_LOGIN));
    }

    [Fact]
    public async Task Validate_Invalid_Login_By_Email_Error()
    {
        (var user, var password) = UserBuilder.Build();

        var useCase = CreateUseCase(user);

        Func<Task> action = async () => {
            await useCase.Execute(new BackendSiteVendas.Comunication.Requests.LoginRequestJson
            {
                Email = "InvalidEmail",
                Password = password
            }); ;
        };

        await action.Should().ThrowAsync<InvalidLoginException>()
            .Where(exception => exception.Message.Equals(ResourceCustomErrorMessages.INVALID_LOGIN));
    }

    [Fact]
    public async Task Validate_Invalid_Login_By_Email_And_Password_Error()
    {
        (var user, var password) = UserBuilder.Build();

        var useCase = CreateUseCase(user);

        Func<Task> action = async () => {
            await useCase.Execute(new BackendSiteVendas.Comunication.Requests.LoginRequestJson
            {
                Email = "InvalidEmail",
                Password = "InvalidPassword"
            }); ;
        };

        await action.Should().ThrowAsync<InvalidLoginException>()
            .Where(exception => exception.Message.Equals(ResourceCustomErrorMessages.INVALID_LOGIN));
    }

    private static LoginUseCase CreateUseCase(BackendSiteVendas.Domain.Entities.User.User user)
    {
        var crypter = PasswordScramblerBuilder.Instance();
        var token = TokenControllerBuilder.Instance();
        var readOnlyRepository = UserReadOnlyRepositoryBuilder.Instance().RetrieveByEmailAndPassword(user).Build();

        return new LoginUseCase(readOnlyRepository, crypter, token);
    }
}
