using DevBr.Core.Http.Rest;
using DevBr.Core.Http.Results;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Polly;
using System.Net;

namespace DevBr.Core.Http.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDevBrHttpIntegration(this IServiceCollection services, IConfiguration configuration, ILogger logger = null)
        {
            services.AddSingleton<IHttpIntegration, HttpIntegration>();
            services.AddSingleton(x => x.GetRequiredService<IOptions<IntegrationHttp>>().Value);
            var config = configuration.GetSection(nameof(IntegrationHttp)) as IntegrationHttp;

            if (config == null)
            {
                _ = services.AddHttpClient(HttpIntegration.configDefault)
                    .AddPolicyHandler(RequestIntegration =>
                    Policy.WrapAsync(
                        Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromMilliseconds(HttpIntegration.timeOutDefault)),
                        Policy.Handle<Exception>()
                                .OrResult<HttpResponseMessage>(response => !response.IsSuccessStatusCode)
                                .RetryAsync(HttpIntegration.retry, (exception, retryCount, context) =>
                                 {
                                     logger?.LogError($"Retry number {retryCount}: Exception: {exception.Exception}");
                                 })
                            )
                        );
                return services;
            }


            foreach (var obj in config.Settings)
            {
                services.AddHttpClient(obj.ConfigName)
                    .ConfigurePrimaryHttpMessageHandler(() =>
                    {
                        var handler = new HttpClientHandler();
                        if (obj.Proxy != null)
                        {
                            handler.Proxy = new WebProxy(obj.Proxy.Url)
                            {
                                Credentials = new NetworkCredential(obj.Proxy.UserName, obj.Proxy.Password)
                            };
                            handler.UseProxy = true;
                        }
                        if (obj.SslIgnore)
                        {
                            handler.ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, certChain, polyErros) => true;
                        }
                        return handler;
                    })
                    .AddPolicyHandler(req =>
                        Policy.WrapAsync(
                            Policy
                                .TimeoutAsync<HttpResponseMessage>(
                                    TimeSpan.FromMilliseconds(
                                        obj.Policy?.TimeOut == null ?
                                        (double)HttpIntegration.timeOutDefault :
                                        (double)obj.Policy?.TimeOut)),
                            Policy
                                .Handle<Exception>()
                                    .OrResult<HttpResponseMessage>(response => !response.IsSuccessStatusCode)
                                    .RetryAsync(
                                        obj.Policy?.Retray == null ?
                                        HttpIntegration.retry :
                                        (int)obj.Policy?.Retray,
                                        (exception, retrayCount, context) =>
                                        {
                                            logger?.LogError($"Retry number {retrayCount}: Exception: {exception.Exception}");
                                        }
                                )
                           )
                        );
            }
            return services;

        }
    }
}
