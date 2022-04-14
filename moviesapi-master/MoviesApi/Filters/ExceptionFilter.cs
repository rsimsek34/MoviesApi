using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Movies.Core.CustomExceptions;
using Movies.Core.Generics;
using System;
using System.Net;

namespace MoviesApi.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var statusCode = HttpStatusCode.InternalServerError;
            if(context.Exception is EntityNotFoundExcepiton) 
            { statusCode = HttpStatusCode.NotFound; }

            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)statusCode;

            context.Result = new JsonResult(new ApiResponse
            {
                Success=false,
                Message = $"ExceptionMsg:{context.Exception.Message}-InnerExpMsg:{context.Exception.InnerException?.Message}"
            });
        }
    }
}
