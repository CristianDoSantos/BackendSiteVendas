using FluentAssertions;
using System.Net;
using UtilitiesForTests.Requests;
using UtilitiesForTests.Token;
using Xunit;

namespace WebApi.Tests.V1.User.ChangePassword;

public class ChangePasswordInvalidToken : ControllerBase
{
    private const string METHOD = "user/change-password";

    private BackendSiteVendas.Domain.Entities.User.User _user;
    private string _password;
    public ChangePasswordInvalidToken(BackendSiteVendasWebApplicationFactory<Program> factory) : base(factory)
    {
        _user = factory.RetrieveUser();
        _password = factory.RetrievePassword();
    }

    [Fact]
    public async Task Validate_Blank_Token_Error()
    {
        var token = string.Empty;

        var request = ChangePasswordRequestBuilder.Build();
        request.CurrentPassword = _password;

        var response = await PutRequest(METHOD, request, token);

        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task Validate_Fake_User_Token_Error()
    {
        var token = TokenControllerBuilder.Instance().GenerateToken("user@fake.com");

        var request = ChangePasswordRequestBuilder.Build();
        request.CurrentPassword = _password;

        var response = await PutRequest(METHOD, request, token);

        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task Validate_Expired_Token_Error()
    {
        var token = TokenControllerBuilder.ExpiredToken().GenerateToken(_user.Email);
        Thread.Sleep(1000);

        var request = ChangePasswordRequestBuilder.Build();
        request.CurrentPassword = _password;

        var response = await PutRequest(METHOD, request, token);

        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }
}
