using DevBr.Core.API.Errors;
using Microsoft.Extensions.DependencyInjection;

namespace DevBr.Core.API.Extensions
{
    public static class FilterExceptionExtensions
    {
        public static IServiceCollection AddCustomFilterException(this IServiceCollection services)
        {
            services.AddControllers(opt =>
            {
                opt.Filters.Add<CustomExceptionFilterAttribute>();
            });
            return services;
        }
    }
}
