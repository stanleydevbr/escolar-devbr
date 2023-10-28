using Amazon.S3;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DevBr.Core.Storage.Amazon
{
    public class AWSConfiguration
    {
        public static void AWSS3ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            var authorization = (AWSCredentials)configuration.GetSection(nameof(AWSCredentials));

            services.AddDefaultAWSOptions(configuration.GetAWSOptions());
            services.AddAWSService<IAmazonS3>();
            //services.AddAWSService<IAmazonDynamoDB>();
        }
    }
}
