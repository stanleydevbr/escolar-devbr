using DevBr.Core.Http.Rest;

namespace DevBr.Core.Http
{
    public class HttpIntegrationService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public HttpIntegrationService(IHttpClientFactory httpClientFactory)
        {
            this._httpClientFactory = httpClientFactory;
        }
        public IHttpIntegration GetHttpIntegration()
        {
            return new HttpIntegration(this._httpClientFactory);
        }
    }
}
