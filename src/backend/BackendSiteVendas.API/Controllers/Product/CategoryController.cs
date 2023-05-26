using BackendSiteVendas.API.Filters;
using BackendSiteVendas.Application.UseCases.Product.Register.Category;
using BackendSiteVendas.Application.UseCases.User.Register;
using BackendSiteVendas.Comunication.Requests.Product;
using BackendSiteVendas.Comunication.Requests.User;
using BackendSiteVendas.Comunication.Responses.Poduct;
using BackendSiteVendas.Comunication.Responses.User;
using Microsoft.AspNetCore.Mvc;

namespace BackendSiteVendas.API.Controllers.Product
{
    [ServiceFilter(typeof(AuthenticatedUserAttribute))]
    public class CategoryController : BackendSiteVendasController
    {
        [HttpPost]
        [ProducesResponseType(typeof(ProductCategoryRegisterResponseJson), StatusCodes.Status201Created)]
        public async Task<IActionResult> RegisterCategory(
            [FromServices] IRegisterCategoryUseCase useCase,
            [FromBody] CategoryRegisterRequestJson request
            )
        {
            var result = await useCase.Execute(request);

            return Created(string.Empty, result);
        }
    }
}