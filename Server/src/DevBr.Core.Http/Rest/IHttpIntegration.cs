using DevBr.Core.Http.Extensions;
using DevBr.Core.Http.Results;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text;

namespace DevBr.Core.Http.Rest
{
    public interface IHttpIntegration
    {
        IntegrationResponse<T> Send<T>(IRequestIntegration request);
        IntegrationResponse<Stream> SendStream(IRequestIntegration request);
    }

    public class HttpIntegration : IHttpIntegration
    {
        public const string configDefault = "Default";
        public const int timeOutDefault = 30000;
        public const int retry = 0;

        private readonly ILogger logger;
        private readonly IHttpClientFactory clientFactory;

        public HttpIntegration(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public HttpIntegration(ILogger logger, IHttpClientFactory clientFactory)
        {
            this.logger = logger;
            this.clientFactory = clientFactory;
        }

        public IntegrationResponse<T> Send<T>(IRequestIntegration request)
        {
            return SendIntegration<T>(request).Result;
        }

        public IntegrationResponse<Stream> SendStream(IRequestIntegration request)
        {
            return SendStreamIntegration<Stream>(request).Result;
        }

        private async Task<IntegrationResponse<Stream>> SendStreamIntegration<T>(IRequestIntegration request)
        {
            HttpResponseMessage result = await CallIntegrationAsync<T>(request);
            return await ReturnHandleAsyncStream(result, request);
        }

        private async Task<IntegrationResponse<Stream>> ReturnHandleAsyncStream(HttpResponseMessage result, IRequestIntegration request)
        {
            var response = new IntegrationResponse<Stream>();
            response.RequestHttp = request;
            Stream stream = await result.Content.ReadAsStreamAsync();
            response.Result = stream;
            response.StatusCode = (int)result.StatusCode;
            response.Success = result.IsSuccessStatusCode;
            response.ResponseHeaders = JsonConvert.SerializeObject(result.Headers);
            return response;
        }

        private async Task<IntegrationResponse<T>> SendIntegration<T>(IRequestIntegration request)
        {
            HttpResponseMessage response = await CallIntegrationAsync<T>(request);
            return await ReturnHandleAsync<T>(response, request);
        }

        private async Task<IntegrationResponse<T>> ReturnHandleAsync<T>(HttpResponseMessage response, IRequestIntegration request)
        {
            var result = new IntegrationResponse<T>();
            result.RequestHttp = request;
            string responseResult = await response.Content.ReadAsStringAsync();

            result.StatusCode = (int)response.StatusCode;
            result.Success = response.IsSuccessStatusCode;
            result.ResponseHeaders = response.Headers;

            LoggingCall<T>(response, result, responseResult);

            if (typeof(T) == typeof(string))
                result.Result = (T)Convert.ChangeType(responseResult, typeof(string));
            else
                result.Result = JsonConvert.DeserializeObject<T>(responseResult);

            return result;
        }

        private void LoggingCall<T>(HttpResponseMessage response, IntegrationResponse<T> result, string responseResult)
        {
            string allHeaders = null;
            try
            {
                if (logger != null)
                {
                    allHeaders = Enumerable
                        .Empty<(string name, string value)>()
                        .Concat(response.Headers
                        .SelectMany(kvp => kvp.Value
                            .Select(v => (name: kvp.Key, value: v))
                            )
                        )
                        .Concat(response.Content.Headers
                        .SelectMany(kvp => kvp.Value
                            .Select(v => (name: kvp.Key, value: v))
                            )
                        )
                        .Aggregate(seed: new StringBuilder(),
                        func: (sb, pair) => sb.Append(pair.name).Append(": ").Append(pair.value).Append("; "),
                        resultSelector: sb => sb.ToString());
                }
            }
            catch (Exception e)
            {
                logger.LogError(e.ToString());
                allHeaders = "An error occurred while retrieving and concatenating the headers";
                result.Message = e.Message;
            }
            finally
            {
                logger.LogInformation($"Answer: [HTTP StatusCode: {result.StatusCode}] [Headers: {allHeaders}] [Body: [{responseResult}]");
            }
        }

        private async Task<HttpResponseMessage> CallIntegrationAsync<T>(IRequestIntegration request)
        {
            logger?.LogInformation($"Start request: {request.Method} - {request.Address}");
            var result = new IntegrationResponse<T>();
            result.RequestHttp = request;

            Uri uri = GetAddress(string.Empty, request.Address);

            logger?.LogInformation($"Address last request: {uri.ToString()}");
            HttpClient httpClient = InstanceHttpClient(request);

            logger?.LogInformation($"Request {JsonConvert.SerializeObject(request, Formatting.Indented)} sending request");

            HttpContent httpContent = BuildHttContent(request);

            var req = new HttpRequestMessage()
            {
                RequestUri = uri,
                Method = SetMethod(request.Method)
            };

            foreach (var item in request.HeadersHttp)
            {
                if (item.Chave != "Content-Type")
                    req.Headers.Add(item.Chave, item.Valor);
            }

            req.Content = httpContent;
            return await httpClient.SendAsync(req);

        }

        private HttpMethod SetMethod(string method)
        {
            switch (method?.ToUpper())
            {
                default:
                case "GET":
                    return HttpMethod.Get;
                case "POST":
                    return HttpMethod.Post;
                case "PUT":
                    return HttpMethod.Put;
                case "DELETE":
                    return HttpMethod.Delete;
                case "PATCH":
                    return new HttpMethod("PATCH");

            }
        }

        private HttpContent BuildHttContent(IRequestIntegration request)
        {
            HttpContent content = null;
            if (request.Body == null)
                return content;
            if (request.Body is Stream bodyStream)
                content = new StreamContent(bodyStream);
            else if (request.Body is MultipartFormDataContent)
                content = (MultipartFormDataContent)request.Body;
            else
                content = BuildStringContent(request);

            return content;
        }

        private HttpContent? BuildStringContent(IRequestIntegration request)
        {
            var contentType = request.HeadersHttp
                .Where(x => x.Chave == "Content-Type")
                .Select(x => x.Valor)
                .FirstOrDefault();

            string entrada;
            if (request.Body is string)
                entrada = (string)request.Body;
            else
                entrada = JsonConvert.SerializeObject(request.Body);

            if (string.IsNullOrWhiteSpace(contentType))
                contentType = "application/json";

            return new StringContent(entrada, Encoding.UTF8, contentType);
        }

        private HttpClient InstanceHttpClient(IRequestIntegration request)
        {
            var httpClient = clientFactory.CreateClient(string.IsNullOrWhiteSpace(request.NameConfig) ? configDefault : request.NameConfig);
            return httpClient;
        }

        private async Task<IntegrationResponse<Stream>> BuildResponseStreamAsync(HttpResponseMessage response, IRequestIntegration request)
        {
            var retorno = new IntegrationResponse<Stream>();
            retorno.RequestHttp = request;
            Stream retornoResponse = await response.Content.ReadAsStreamAsync();
            retorno.Result = retornoResponse;
            retorno.StatusCode = (int)response.StatusCode;
            retorno.Success = response.IsSuccessStatusCode;
            retorno.ResponseHeaders = response.Headers;

            LogRequest<Stream>(response, retorno, retorno.ToBase64());
            //TODO: Utilizar cache

            return retorno;
        }

        private void LogRequest<T>(HttpResponseMessage response, IntegrationResponse<T> retorno, string result)
        {
            string allHeaders = null;
            try
            {
                if (logger != null)
                {
                    allHeaders = Enumerable
                        .Empty<(string name, string value)>()
                        .Concat(
                            response.Headers
                                .SelectMany(kvp => kvp.Value
                                    .Select(v => (name: kvp.Key, value: v))
                               )
                         )
                        .Concat(
                            response.Content.Headers
                            .SelectMany(kvp => kvp.Value
                                .Select(v => (name: kvp.Key, value: v))
                            )
                         )
                        .Aggregate(
                                seed: new StringBuilder(),
                                func: (sb, pair) => sb.Append(pair.name).Append(": ").Append(pair.value).Append("; "),
                                resultSelector: sb => sb.ToString()
                        );
                }
            }
            catch (Exception e)
            {
                logger?.LogError(e.ToString());
                allHeaders = "Ocorreu um erro ao recuperar e concatenar os headers.";
            }
            finally
            {
                logger?.LogInformation($"Resposta: [HTTP Status Code: {retorno.StatusCode}] [Headers: {allHeaders}] [Body {result}]");
            }
        }

        private Uri GetAddress(string url, string address)
        {
            if (!string.IsNullOrEmpty(url))
                return url.Contains(address) ? new Uri(url) : new Uri($"{url}/{address}");
            return new Uri(address);
        }

    }
}
