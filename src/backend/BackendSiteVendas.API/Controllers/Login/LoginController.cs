using BackendSiteVendas.Application.UseCases.Login.DoLogin;
using BackendSiteVendas.Comunication.Requests.Login.DoLogin;
using BackendSiteVendas.Comunication.Responses.Login.DoLogin;
using Microsoft.AspNetCore.Mvc;

namespace BackendSiteVendas.API.Controllers.Login
{
    public class LoginController : BackendSiteVendasController
    {
        [HttpPost]
        [ProducesResponseType(typeof(LoginResponseJson), StatusCodes.Status200OK)]
        public async Task<IActionResult> Login(
           [FromServices] ILoginUseCase useCase,
           [FromBody] LoginRequestJson request)
        {
            var response = await useCase.Execute(request);

            return Ok(response);
        }
    }
}
