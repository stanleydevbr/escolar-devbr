using DevBr.Core.Mongo.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DevBr.Core.Mongo.Configuration
{
    public static class MongoCoreExtension
    {
        public static void AddConfigureMongoCore(this IServiceCollection services, IConfiguration Configuration)
        {
            //services.Configure<MongoCoreSettings>(con => Configuration.GetSection("MongoDbSettings").Bin(con));

            //services.AddSingleton<IMongoCoreSettings>(serviceProvider => serviceProvider.GetRequiredService<IOptions<IMongoCoreSettings>>().Value);
        }

        public static void AddConfigureMongoCoreDependency(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepositoryCore<>), typeof(RepositoryCore<>));
        }
    }
}
