using BackendSiteVendas.Exceptions;
using FluentAssertions;
using System.Net;
using System.Text.Json;
using UtilitiesForTests.Requests;
using Xunit;

namespace WebApi.Tests.V1.User.Register;

public class RegisterUserTest : ControllerBase
{
    private const string METHOD = "user";
    public RegisterUserTest(BackendSiteVendasWebApplicationFactory<Program> factory) : base(factory) { }

    [Fact]
    public async Task Validate_Success()
    {
        var request = UserRegisterRequestBuilder.Build();

        var response = await PostRequest(METHOD, request);

        response.StatusCode.Should().Be(HttpStatusCode.Created);

        await using var bodyResponse = await response.Content.ReadAsStreamAsync();

        var dataResponse = await JsonDocument.ParseAsync(bodyResponse);

        dataResponse.RootElement.GetProperty("token").GetString().Should().NotBeNullOrWhiteSpace();

    }

    [Fact]
    public async Task Validate_Blank_Name_Error()
    {
        var request = UserRegisterRequestBuilder.Build();
        request.Name = string.Empty;

        var response = await PostRequest(METHOD, request);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        await using var bodyResponse = await response.Content.ReadAsStreamAsync();

        var dataResponse = await JsonDocument.ParseAsync(bodyResponse);

        var errors = dataResponse.RootElement.GetProperty("messages").EnumerateArray();
        errors.Should().ContainSingle().And.Contain(err => err.GetString().Equals(ResourceCustomErrorMessages.BLANK_USER));

    }
}
