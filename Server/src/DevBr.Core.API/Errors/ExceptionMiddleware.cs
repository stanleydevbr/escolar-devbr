using Microsoft.AspNetCore.Http;
using System.Net;

namespace DevBr.Core.API.Errors
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var erro = string.Empty;
            erro += exception.Message != null ? exception.Message : string.Empty;
            erro += exception.InnerException != null ? exception.InnerException.Message != null ? exception.InnerException.Message : string.Empty : string.Empty;
            return context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = $"Ops, nosso servidor encontrou um problema! Tente novamente ou entre em contato com o suporte. { erro }."
            }.ToString());
        }
    }
}
