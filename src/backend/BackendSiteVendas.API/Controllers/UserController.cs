﻿using BackendSiteVendas.Application.UseCases.User.Register;
using BackendSiteVendas.Comunication.Requests;
using BackendSiteVendas.Comunication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BackendSiteVendas.API.Controllers
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
    }
}