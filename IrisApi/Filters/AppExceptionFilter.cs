using Iris.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace IrisApi.Filters;

public class AppExceptionFilter:ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        if (context!= null)
        {
            context.HttpContext.Response.StatusCode = context.Exception switch
            {
                UserUnRegisteredException => (int)HttpStatusCode.Unauthorized,
                AppException => (int) HttpStatusCode.BadRequest,
                _=> (int) HttpStatusCode.InternalServerError
            };
            context.Result = new ObjectResult(new { message = context.Exception.Message });
        }
    }
}
