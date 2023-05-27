using BackendSiteVendas.Exceptions;
using FluentAssertions;
using System.Net;
using System.Text.Json;
using UtilitiesForTests.Requests.Product.Category;
using UtilitiesForTests.Requests.User;
using Xunit;

namespace WebApi.Tests.V1.Product.Category.Register;

public class RegisterCategoryTest : ControllerBase
{
    private const string METHOD = "category";

    private BackendSiteVendas.Domain.Entities.User.User _user;
    private string _password;

    public RegisterCategoryTest(BackendSiteVendasWebApplicationFactory<Program> factory) : base(factory) 
    {
        _user = factory.RetrieveUser();
        _password = factory.RetrievePassword();
    }

    [Fact]
    public async Task Validate_Success()
    {
        var token = await Login(_user.Email, _password);

        var request = CategoryRegisterRequestBuilder.Build();

        var response = await PostRequest(METHOD, request, token);

        response.StatusCode.Should().Be(HttpStatusCode.Created);

        await using var bodyResponse = await response.Content.ReadAsStreamAsync();

        var dataResponse = await JsonDocument.ParseAsync(bodyResponse);

        dataResponse.RootElement.GetProperty("name").GetString().Should().Be(request.Name);
        dataResponse.RootElement.GetProperty("description").GetString().Should().Be(request.Description);
    }

    [Fact]
    public async Task Validate_Blank_Name_Error()
    {
        var token = await Login(_user.Email, _password);

        var request = CategoryRegisterRequestBuilder.Build();
        request.Name = string.Empty;

        var response = await PostRequest(METHOD, request, token);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        await using var bodyResponse = await response.Content.ReadAsStreamAsync();

        var dataResponse = await JsonDocument.ParseAsync(bodyResponse);

        var errors = dataResponse.RootElement.GetProperty("messages").EnumerateArray();
        errors.Should().ContainSingle().And.Contain(err => err.GetString().Equals(ResourceCustomErrorMessages.BLANK_CATEGORY_NAME));
    }

    [Fact]
    public async Task Validate_Blank_Description_Error()
    {
        var token = await Login(_user.Email, _password);

        var request = CategoryRegisterRequestBuilder.Build();
        request.Description = string.Empty;

        var response = await PostRequest(METHOD, request, token);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        await using var bodyResponse = await response.Content.ReadAsStreamAsync();

        var dataResponse = await JsonDocument.ParseAsync(bodyResponse);

        var errors = dataResponse.RootElement.GetProperty("messages").EnumerateArray();
        errors.Should().ContainSingle().And.Contain(err => err.GetString().Equals(ResourceCustomErrorMessages.BLANK_CATEGORY_DESCRIPTION));
    }

    [Fact]
    public async Task Validate_Minimum_Description_Characteres_Error()
    {
        var token = await Login(_user.Email, _password);

        var request = CategoryRegisterRequestBuilder.Build();
        request.Description = "a";

        var response = await PostRequest(METHOD, request, token);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        await using var bodyResponse = await response.Content.ReadAsStreamAsync();

        var dataResponse = await JsonDocument.ParseAsync(bodyResponse);

        var errors = dataResponse.RootElement.GetProperty("messages").EnumerateArray();
        errors.Should().ContainSingle().And.Contain(err => err.GetString().Equals(ResourceCustomErrorMessages.SHORT_CATEGORY_DESCRIPTION));
    }
}
