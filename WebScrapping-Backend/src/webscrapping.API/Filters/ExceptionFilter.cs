using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebScrapping.Communication.Responses;
using WebScrapping.Exception;
using WebScrapping.Exception.ExceptionsBase;

namespace WebScrapping.API.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if(context.Exception is WebScrappingException exception)
        {
            HandleProjectException(context);
        }
        else
        {
            ThrowUnknownError(context);
        }
    }

    private void HandleProjectException(ExceptionContext context)
    {
        var webScrappingException = (WebScrappingException)context.Exception;
        var errorResponse = new ResponseErrorsJson(webScrappingException!.GetErrors());

        context.HttpContext.Response.StatusCode = webScrappingException.StatusCode;
        context.Result = new ObjectResult(errorResponse);
    }

    private void ThrowUnknownError(ExceptionContext context)
    {
        var errorResponse = new ResponseErrorsJson(ResourceErrorMessages.UNKNOWN_ERROR);
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(errorResponse);
    }
}
