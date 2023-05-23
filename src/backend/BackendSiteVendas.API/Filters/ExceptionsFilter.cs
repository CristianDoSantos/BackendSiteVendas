using BackendSiteVendas.Comunication.Responses;
using BackendSiteVendas.Exceptions;
using BackendSiteVendas.Exceptions.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace BackendSiteVendas.API.Filters
{
    public class ExceptionsFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is BackendSiteVendasException)
            {
                TreatBackendSiteVendasException(context);
            } else
            {
                ThrowUnknownError(context);
            }
        }

        private static void TreatBackendSiteVendasException(ExceptionContext context)
        {
            if (context.Exception is ValidationErrorException)
            {
                TreatValidationErrorException(context);
            } else if (context.Exception is InvalidLoginException)
            {
                TreatLoginException(context);
            }
        }

        private static void TreatValidationErrorException(ExceptionContext context)
        {
            var validationErrorException = context.Exception as ValidationErrorException;

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Result = new ObjectResult(new ErrorResponseJson(validationErrorException.ErrorMessages));
        }

        private static void TreatLoginException(ExceptionContext context)
        {
            var loginError = context.Exception as InvalidLoginException;
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            context.Result = new ObjectResult(new ErrorResponseJson(loginError.Message));
        }

        private static void ThrowUnknownError(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new ObjectResult(new ErrorResponseJson(ResourceCustomErrorMessages.UNKNOWN_ERROR));
        }
    }
}
