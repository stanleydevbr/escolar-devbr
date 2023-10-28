
using DevBr.Core.API.Identidade;
using DevBr.Escola.Infra.CrossCutting.AutoMapper.Registers;
using DevBr.Escola.Infra.CrossCutting.IoC.Configurations.Contexts;
using DevBr.Escola.WebAPI.Configuration;

namespace DevBr.Escola.WebAPI
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
            services.RegisterUserAccessor();
            services.AddJwtAuthenticationConfiguration(Configuration);
            services.AddApiConfiguration();
            services.AddSwaggerConfiguration();
            services.ResolverDependencyDomain();
            services.ResolverDependencyRepository(Configuration);
            services.AutoMapperRegister();
            services.ResolverDependencyApplication();

        }
        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            app.UseSwaggerConfiguration();
            app.UseApiConfiguration(environment);
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
