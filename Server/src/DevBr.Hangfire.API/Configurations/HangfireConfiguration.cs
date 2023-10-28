using Hangfire;
using Hangfire.Mongo;
using Hangfire.Mongo.Migration.Strategies;
using Hangfire.Mongo.Migration.Strategies.Backup;
using MongoDB.Driver;

namespace DevBr.Hangfire.API.Configurations
{
    public static class HangfireConfiguration
    {
        public static IServiceCollection AddHangfireConfiguration(this IServiceCollection services)
        {
            var builder = new MongoUrlBuilder(@"mongodb://localhost:27017/Hangfire_db");
            var client = new MongoClient(builder.ToMongoUrl());

            var migrationOptions = new MongoMigrationOptions
            {
                MigrationStrategy = new DropMongoMigrationStrategy(),
                BackupStrategy = new CollectionMongoBackupStrategy(),
            };

            services.AddHangfire(config => config
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseRecommendedSerializerSettings()
                .UseMongoStorage(client, builder.DatabaseName, new MongoStorageOptions { MigrationOptions = migrationOptions, CheckConnection = true })
            );

            services.AddHangfireServer();
            return services;
        }
    }
}
