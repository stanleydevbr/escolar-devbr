using DevBr.Core.API.Identidade;
using DevBr.Identidade.API.Configuration;
using DevBr.Identidade.API.Data;
using NetDevPack.Security.JwtSigningCredentials;
using NetDevPack.Security.JwtSigningCredentials.AspNetCore;

namespace DevBr.Identidade.API
{
    public class Startup : IStartup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ResolveDependencies();

            services.AddApiConfiguration();
            services.AddSwaggerConfiguration();

            var appSettingsSection = Configuration.GetSection("AppTokenSettings");
            services.Configure<AppTokenSettings>(appSettingsSection);

            services.AddIdentityConfiguration(Configuration);

            services.AddJwksManager(options => options.Algorithm = Algorithm.ES256)
                 .PersistKeysToDatabaseStore<IdentidadeContext>();

        }
        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            app.UseSwaggerConfiguration();
            app.UseApiConfiguration(environment);
            app.UseJwksDiscovery();
        }
    }

    public interface IStartup
    {
        IConfiguration Configuration { get; }
        void Configure(WebApplication app, IWebHostEnvironment environment);
        void ConfigureServices(IServiceCollection services);
    }

    public static class StartupExtensions
    {
        public static WebApplicationBuilder UseStartup<TSetup>(this WebApplicationBuilder WebAppBuilder) where TSetup : IStartup
        {
            var startup = Activator.CreateInstance(typeof(TSetup), WebAppBuilder.Configuration) as IStartup;
            if (startup == null) throw new ArgumentException("Classe Startup.cs inválida!");

            startup.ConfigureServices(WebAppBuilder.Services);
            var app = WebAppBuilder.Build();
            startup.Configure(app, app.Environment);
            app.Run();
            return WebAppBuilder;
        }
    }
}
