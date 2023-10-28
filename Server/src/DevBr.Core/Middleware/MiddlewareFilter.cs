using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace DevBr.Core.Middleware
{

    /*EXEMPLO DE MIDDLEWARE*/
    public class MiddlewareFilter
    {
        private readonly RequestDelegate _next;
        private readonly MiddlewareOptions _options;
        public MiddlewareFilter(RequestDelegate next, IOptions<MiddlewareOptions> options)
        {
            _next = next;
            _options = options.Value;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await httpContext.Response.WriteAsync(_options.BeforeMessage);
            await _next(httpContext);
            await httpContext.Response.WriteAsync(_options.AfterMessage);
        }
    }

    public static class MiddlewareFilterExtensions
    {
        public static IServiceCollection AddMiddlewareFilter(this IServiceCollection service, Action<MiddlewareOptions> options)
        {
            options = options ?? (opts => { });
            service.Configure(options);
            return service;
        }
        public static IApplicationBuilder UseMiddlewareFilter(this IApplicationBuilder builder, Action<MiddlewareOptions> options)
        {
            var config = new MiddlewareOptions();
            options?.Invoke(config);
            return builder.UseMiddleware<MiddlewareFilter>();
        }
    }

    public class MiddlewareOptions
    {
        public string BeforeMessage { get; set; } = "Chamou nosso middleware (antes)";
        public string AfterMessage { get; set; } = "Chamou nosso middleware (depois)";
    }
}
