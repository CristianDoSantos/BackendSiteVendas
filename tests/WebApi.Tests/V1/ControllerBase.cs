using BackendSiteVendas.Exceptions;
using Newtonsoft.Json;
using System.Globalization;
using System.Text;
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

    protected async Task<HttpResponseMessage> PostRequest(string method, object body)
    {
        var jsonString = JsonConvert.SerializeObject(body);

        return await _client.PostAsync(method, new StringContent(jsonString, Encoding.UTF8, "application/json"));
    }
}
