using BackendSiteVendas.Comunication.Requests;
using BackendSiteVendas.Comunication.Requests.Login.DoLogin;
using BackendSiteVendas.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Text;
using System.Text.Json;
using Xunit;

namespace WebApi.Tests.V1;

public class ControllerBase : IClassFixture<BackendSiteVendasWebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    public ControllerBase(BackendSiteVendasWebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
        ResourceCustomErrorMessages.Culture = CultureInfo.CurrentCulture;
    }

    protected async Task<HttpResponseMessage> PostRequest(string method, object body, string token = "")
    {
        AuthorizeRequest(token);

        var jsonString = JsonConvert.SerializeObject(body);

        return await _client.PostAsync(method, new StringContent(jsonString, Encoding.UTF8, "application/json"));
    }

    protected async Task<string> Login(string email, string password)
    {
        var request = new LoginRequestJson
        {
            Email = email,
            Password = password
        };

        var response = await PostRequest("login", request);

        await using var bodyResponse = await response.Content.ReadAsStreamAsync();

        var responseData = await JsonDocument.ParseAsync(bodyResponse);

        return responseData.RootElement.GetProperty("token").GetString();
    }

    protected async Task<HttpResponseMessage> PutRequest(string method, object body, string token = "")
    {
        AuthorizeRequest(token);

        var jsonString = JsonConvert.SerializeObject(body);

        return await _client.PutAsync(method, new StringContent(jsonString, Encoding.UTF8, "application/json"));
    }

    private void AuthorizeRequest(string token)
    {
        if (!string.IsNullOrWhiteSpace(token) && !_client.DefaultRequestHeaders.Contains("Authorization"))
        {
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
        }
    }
}
