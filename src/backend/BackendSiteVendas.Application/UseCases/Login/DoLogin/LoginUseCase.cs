using BackendSiteVendas.Application.Services.Cryptography;
using BackendSiteVendas.Application.Services.Token;
using BackendSiteVendas.Comunication.Requests;
using BackendSiteVendas.Comunication.Responses;
using BackendSiteVendas.Domain.Repositories.User;
using BackendSiteVendas.Exceptions.ExceptionsBase;

namespace BackendSiteVendas.Application.UseCases.Login.DoLogin;

public class LoginUseCase : ILoginUseCase
{
    private readonly IUserReadOnlyRepository _userReadOnlyRepository;
    private readonly PasswordScrambler _passwordScrambler;
    private readonly TokenController _tokenController;

    public LoginUseCase(IUserReadOnlyRepository userReadOnlyRepository, PasswordScrambler passwordScrambler, TokenController tokenController)
    {
        _userReadOnlyRepository = userReadOnlyRepository;
        _passwordScrambler = passwordScrambler;
        _tokenController = tokenController;
    }

    public async Task<LoginResponseJson> Execute(LoginRequestJson request)
    {
        var encryptedPassword = _passwordScrambler.Encrypt(request.Password);

        var user = await _userReadOnlyRepository.RetrieveByEmailAndPassword(request.Email, encryptedPassword);

        if (user is null)
        {
            throw new InvalidLoginException();
        }

        return new LoginResponseJson
        {
            Name = user.Name,
            Token = _tokenController.GenerateToken(user.Email)
        };
    }
}
