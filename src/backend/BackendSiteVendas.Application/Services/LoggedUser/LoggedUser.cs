using BackendSiteVendas.Application.Services.Token;
using BackendSiteVendas.Domain.Entities;
using BackendSiteVendas.Domain.Repositories.User;
using Microsoft.AspNetCore.Http;

namespace BackendSiteVendas.Application.Services.LoggedUser;

public class LoggedUser : ILoggedUser
{
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly TokenController _tokenController;
    private readonly IUserReadOnlyRepository _repository;
    public LoggedUser(IHttpContextAccessor httpContextAccessor, TokenController tokenController, IUserReadOnlyRepository userReadOnlyRepository)
    {
        _contextAccessor = httpContextAccessor;
        _tokenController = tokenController;
        _repository = userReadOnlyRepository;
    }

    public async Task<User> RetrieveUser()
    {
        var authorization = _contextAccessor.HttpContext.Request.Headers["Authorization"].ToString();

        var token = authorization["Bearer".Length..].Trim();

        var userEmail = _tokenController.RetrieveEmail(token);

        var user = await _repository.RetrieveByEmail(userEmail);

        return user;
    }
}
