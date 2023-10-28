using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;

namespace DevBr.Escola.Infra.CrossCutting.IoC.Registers
{
    public static class BootStrapperInjector
    {
        public static void Register(IServiceCollection service)
        {
            service.AddScoped<ClaimsPrincipal>(s => s.GetService<IHttpContextAccessor>().HttpContext.User);
        }
    }
}
