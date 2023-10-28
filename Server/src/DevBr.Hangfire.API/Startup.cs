using DevBr.Hangfire.API.Configurations;
using Hangfire;

namespace DevBr.Hangfire.API
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
            services.AddWebApi();
            services.AddSwaggerGen();
            services.AddHangfireConfiguration();
            services.AddTransient<IBackgroundJobClient, BackgroundJobClient>();
        }
        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                //Authorization = new[] { new AuthorizationFilter() }
            });
            app.UseSwaggerConfiguration();
            new BackgroundJobClient().Enqueue(() => Console.WriteLine("Hello world from Hangfire!"));
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
