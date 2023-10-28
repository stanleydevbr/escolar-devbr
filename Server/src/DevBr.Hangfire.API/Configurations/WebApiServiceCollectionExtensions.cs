using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace DevBr.Hangfire.API.Configurations
{
    public static class WebApiServiceCollectionExtensions
    {
        public static IMvcCoreBuilder AddWebApi(this IServiceCollection service)
        {
            if (service == null) throw new ArgumentNullException(nameof(service));
            var builder = service.AddMvcCore();

            builder.AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.Converters.Add(new StringEnumConverter());
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            service.AddControllersWithViews().AddNewtonsoftJson(o =>
            {
                o.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                o.SerializerSettings.Converters.Add(new StringEnumConverter());
            });

            builder.AddApiExplorer();
            builder.AddCors();
            return builder;
        }
        public static IMvcCoreBuilder AddWebApi(this IServiceCollection services, Action<MvcOptions> setupAction)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (setupAction == null) throw new ArgumentNullException(nameof(setupAction));

            var builder = services.AddWebApi();
            builder.Services.Configure(setupAction);

            return builder;
        }
    }
}
