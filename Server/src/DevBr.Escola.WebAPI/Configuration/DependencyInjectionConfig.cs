using DevBr.Core.API.Usuario;
using DevBr.Escola.Infra.Data.Context;
using DevBr.Identidade.API.Extensions;
using Microsoft.AspNetCore.Identity;

namespace DevBr.Escola.WebAPI.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterUserAccessor(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();
            services.AddDefaultIdentity<IdentityUser>()
             .AddRoles<IdentityRole>()
             .AddEntityFrameworkStores<EscolaContext>()
             .AddErrorDescriber<IdentityMensagensPtBr>()
             .AddDefaultTokenProviders();

        }
    }
}
