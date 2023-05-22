using BackendSiteVendas.Application.UseCases.User.ChangePassword;
using BackendSiteVendas.Comunication.Requests;
using BackendSiteVendas.Exceptions;
using BackendSiteVendas.Exceptions.ExceptionsBase;
using FluentAssertions;
using UtilitiesForTests.Cryptography;
using UtilitiesForTests.Entities;
using UtilitiesForTests.LoggedUser;
using UtilitiesForTests.Repositories;
using UtilitiesForTests.Requests;
using Xunit;

namespace UseCases.Tests.User.ChangePassword;

public class ChangePasswordUseCaseTest
{
    [Fact]
    public async Task Validate_Success()
    {
        (var user, var password) = UserBuilder.Build();

        var useCase = CreateUseCase(user);

        var request = ChangePasswordRequestBuilder.Build();
        request.CurrentPassword = password;

        Func<Task> action = async () => {
            await useCase.Execute(request);
        };

        await action.Should().NotThrowAsync();
    }

    [Fact]
    public async Task Validte_Blanked_New_Password_Error()
    {
        (var user, var password) = UserBuilder.Build();

        var useCase = CreateUseCase(user);

        Func<Task> action = async () => {
            await useCase.Execute(new ChangePasswordRequestJson
            {
                CurrentPassword = password,
                NewPassword = ""
            });
        };

        await action.Should().ThrowAsync<ValidationErrorException>()
            .Where(ex => ex.ErrorMessages.Count == 1 && ex.ErrorMessages.Contains(ResourceCustomErrorMessages.BLANK_USER_PASSWORD));
    }

    [Fact]
    public async Task Validte_Invalid_Current_Password_Error()
    {
        (var user, var password) = UserBuilder.Build();

        var useCase = CreateUseCase(user);

        var request = ChangePasswordRequestBuilder.Build();
        request.CurrentPassword = "InvalidPassword";

        Func<Task> action = async () => {
            await useCase.Execute(request);
        };

        await action.Should().ThrowAsync<ValidationErrorException>()
            .Where(ex => ex.ErrorMessages.Count == 1 && ex.ErrorMessages.Contains(ResourceCustomErrorMessages.INVALID_CURRENT_PASSWORD));
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public async Task Validte_Invalid_Current_Password_Min_Characteres_Error(int passwordLength)
    {
        (var user, var password) = UserBuilder.Build();

        var useCase = CreateUseCase(user);

        var request = ChangePasswordRequestBuilder.Build(passwordLength);
        request.CurrentPassword = password;

        Func<Task> action = async () => {
            await useCase.Execute(request);
        };

        await action.Should().ThrowAsync<ValidationErrorException>()
            .Where(ex => ex.ErrorMessages.Count == 1 && ex.ErrorMessages.Contains(ResourceCustomErrorMessages.USER_PASSWORD_MIN_SIX_CHARACTERES));
    }

    private static ChangePasswordUseCase CreateUseCase(BackendSiteVendas.Domain.Entities.User user)
    {
        var userUpdateOnlyRepository = UserUpdateOnlyRepositoryBuilder.Instance().RetrieveById(user).Build();
        var loggedUser = LoggedUserBuilder.Instance().RetrieveUser(user).Build();
        var passwordScrambler = PasswordScramblerBuilder.Instance();
        var unitOfWork = UnityOfWorkBuilder.Instance().Build();

        return new ChangePasswordUseCase(userUpdateOnlyRepository, loggedUser, passwordScrambler, unitOfWork);
    }
}
