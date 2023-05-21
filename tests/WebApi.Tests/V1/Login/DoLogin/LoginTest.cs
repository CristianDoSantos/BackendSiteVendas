using BackendSiteVendas.Exceptions;
using FluentAssertions;
using System.Net;
using System.Text.Json;
using Xunit;

namespace WebApi.Tests.V1.Login.DoLogin;

public class LoginTest : ControllerBase
{
    private const string METHOD = "login";

    private BackendSiteVendas.Domain.Entities.User _user;
    private string _password;

    public LoginTest(BackendSiteVendasWebApplicationFactory<Program> factory) : base(factory) 
    {
        _user = factory.RetrieveUser();
        _password = factory.RetrievePassword();
    }

    [Fact]
    public async Task Validate_Success()
    {
        var request = new BackendSiteVendas.Comunication.Requests.LoginRequestJson()
        {
            Email= _user.Email,
            Password = _password
        };

        var response = await PostRequest(METHOD, request);
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        await using var bodyResponse = await response.Content.ReadAsStreamAsync();

        var responseData = await JsonDocument.ParseAsync(bodyResponse);

        responseData.RootElement.GetProperty("name").GetString().Should().NotBeNullOrWhiteSpace().And.Be(_user.Name);
        responseData.RootElement.GetProperty("token").GetString().Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public async Task Validate_Invalid_Email_Error()
    {
        var request = new BackendSiteVendas.Comunication.Requests.LoginRequestJson()
        {
            Email = "InvalidEmail",
            Password = _password
        };

        var response = await PostRequest(METHOD, request);
        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);

        await using var bodyResponse = await response.Content.ReadAsStreamAsync();

        var responseData = await JsonDocument.ParseAsync(bodyResponse);

        var erros = responseData.RootElement.GetProperty("messages").EnumerateArray();
        erros.Should().ContainSingle().And.Contain(err => err.GetString().Equals(ResourceCustomErrorMessages.INVALID_LOGIN));
    }

    [Fact]
    public async Task Validate_Invalid_Password_Error()
    {
        var request = new BackendSiteVendas.Comunication.Requests.LoginRequestJson()
        {
            Email = _user.Email,
            Password = "InvalidPassword"
        };

        var response = await PostRequest(METHOD, request);
        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);

        await using var bodyResponse = await response.Content.ReadAsStreamAsync();

        var responseData = await JsonDocument.ParseAsync(bodyResponse);

        var erros = responseData.RootElement.GetProperty("messages").EnumerateArray();
        erros.Should().ContainSingle().And.Contain(err => err.GetString().Equals(ResourceCustomErrorMessages.INVALID_LOGIN));
    }

    [Fact]
    public async Task Validate_Invalid_Email_And_Password_Error()
    {
        var request = new BackendSiteVendas.Comunication.Requests.LoginRequestJson()
        {
            Email = "InvalidEmail",
            Password = "InvalidPassword"
        };

        var response = await PostRequest(METHOD, request);
        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);

        await using var bodyResponse = await response.Content.ReadAsStreamAsync();

        var responseData = await JsonDocument.ParseAsync(bodyResponse);

        var erros = responseData.RootElement.GetProperty("messages").EnumerateArray();
        erros.Should().ContainSingle().And.Contain(err => err.GetString().Equals(ResourceCustomErrorMessages.INVALID_LOGIN));
    }
}
