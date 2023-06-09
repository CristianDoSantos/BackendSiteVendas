﻿using BackendSiteVendas.API.Filters;
using BackendSiteVendas.Application.UseCases.User.ChangePassword;
using BackendSiteVendas.Application.UseCases.User.Register;
using BackendSiteVendas.Comunication.Requests.User;
using BackendSiteVendas.Comunication.Responses.User;
using Microsoft.AspNetCore.Mvc;

namespace BackendSiteVendas.API.Controllers.User
{
    public class UserController : BackendSiteVendasController
    {
        [HttpPost]
        [ProducesResponseType(typeof(RegisteredUserResponseJson), StatusCodes.Status201Created)]
        public async Task<IActionResult> RegisterUser(
            [FromServices] IRegisterUserUseCase useCase,
            [FromBody] UserRegisterRequestJson request
            )
        {
            var result = await useCase.Execute(request);

            return Created(string.Empty, result);
        }

        [HttpPut]
        [Route("change-password")]
        [ServiceFilter(typeof(AuthenticatedUserAttribute))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> ChangePassword(
            [FromServices] IChangePasswordUseCase useCase,
            [FromBody] ChangePasswordRequestJson request
            )
        {
            await useCase.Execute(request);

            return NoContent();
        }
    }
}
