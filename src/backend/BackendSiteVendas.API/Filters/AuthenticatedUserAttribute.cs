﻿using BackendSiteVendas.Application.Services.Token;
using BackendSiteVendas.Comunication.Responses;
using BackendSiteVendas.Domain.Repositories.User;
using BackendSiteVendas.Exceptions;
using BackendSiteVendas.Exceptions.ExceptionsBase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;

namespace BackendSiteVendas.API.Filters
{
    public class AuthenticatedUserAttribute : AuthorizeAttribute, IAsyncAuthorizationFilter
    {
        private readonly TokenController _tokenController;
        private readonly IUserReadOnlyRepository _repository;

        public AuthenticatedUserAttribute(TokenController tokenController, IUserReadOnlyRepository repository)
        {
            _tokenController = tokenController;
            _repository = repository;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            try
            {
                var token = TokenInRequest(context);
                var userEmail = _tokenController.RetrieveEmail(token);

                var user = await _repository.RetrieveByEmail(userEmail);

                if (user is null)
                {
                    throw new BackendSiteVendasException(string.Empty);
                }
            } 
            catch (SecurityTokenExpiredException)
            {
                ExpiredToken(context);
            }
            catch
            {
                UserNotAllowed(context);
            }
        }

        private static string TokenInRequest(AuthorizationFilterContext context)
        {
            var authorization = context.HttpContext.Request.Headers["Authorization"].ToString();

            if (string.IsNullOrEmpty(authorization))
            {
                throw new BackendSiteVendasException(string.Empty);
            }

            return authorization["Bearer".Length..].Trim();
        }

        private static void ExpiredToken(AuthorizationFilterContext context)
        {
            context.Result = new UnauthorizedObjectResult(new ErrorResponseJson(ResourceCustomErrorMessages.EXPIRED_TOKEN));
        }

        private static void UserNotAllowed(AuthorizationFilterContext context)
        {
            context.Result = new UnauthorizedObjectResult(new ErrorResponseJson(ResourceCustomErrorMessages.INVALID_USER));
        }
    }
}
