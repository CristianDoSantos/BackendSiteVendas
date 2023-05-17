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

        private void TreatBackendSiteVendasException(ExceptionContext context)
        {
            if (context.Exception is ValidationErrorException)
            {
                TreatValidationErrorException(context);
            }
        }

        private void TreatValidationErrorException(ExceptionContext context)
        {
            var validationErrorException = context.Exception as ValidationErrorException;

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Result = new ObjectResult(new ErrorResponseJson(validationErrorException.ErrorMessages));
        }

        private void ThrowUnknownError(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new ObjectResult(new ErrorResponseJson(ResourceCustomErrorMessages.UNKNOWN_ERROR));
        }
    }
}
