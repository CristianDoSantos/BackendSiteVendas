using BackendSiteVendas.Exceptions;
using FluentAssertions;
using System.Net;
using System.Text.Json;
using UtilitiesForTests.Requests;
using Xunit;

namespace WebApi.Tests.V1.User.ChangePassword;

public class ChangePasswordTest : ControllerBase
{
    private const string METHOD = "user/change-password";

    private BackendSiteVendas.Domain.Entities.User.User _user;
    private string _password;
    public ChangePasswordTest(BackendSiteVendasWebApplicationFactory<Program> factory) : base(factory)
    {
        _user = factory.RetrieveUser();
        _password = factory.RetrievePassword();
    }

    [Fact]
    public async Task A_Validate_Blank_Password_Error()
    {
        var token = await Login(_user.Email, _password);

        var request = ChangePasswordRequestBuilder.Build();
        request.CurrentPassword = _password;
        request.NewPassword = string.Empty;

        var response = await PutRequest(METHOD, request, token);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        await using var bodyResponse = await response.Content.ReadAsStreamAsync();

        var dataResponse = await JsonDocument.ParseAsync(bodyResponse);

        var errors = dataResponse.RootElement.GetProperty("messages").EnumerateArray();
        errors.Should().ContainSingle().And.Contain(err => err.GetString().Equals(ResourceCustomErrorMessages.BLANK_USER_PASSWORD));
    }

    [Fact]
    public async Task B_Validate_Success()
    {
        var token = await Login(_user.Email, _password);

        var request = ChangePasswordRequestBuilder.Build();
        request.CurrentPassword = _password;

        var response = await PutRequest(METHOD, request, token);

        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}
