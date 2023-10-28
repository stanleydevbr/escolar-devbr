using System.Net;

namespace DevBr.Core.Http.Results
{
    public class RequestIntegration : IRequestIntegration
    {
        public string NameConfig { get; set; }
        public string Address { get; set; }
        public string Method { get; set; }
        public object Body { get; set; }
        public CookieContainer CookieContainer { get; set; }
        public List<HeaderIntegration> HeadersHttp { get; set; }
        public RequestIntegration(CorrelationId correlationId = null)
        {
            HeadersHttp = new List<HeaderIntegration>();
            if (correlationId != null)
            {
                HeadersHttp.Add(new HeaderIntegration()
                {
                    Chave = correlationId.HeaderName,
                    Valor = correlationId.Value
                });
            }

        }
    }
    public class IntegrationResponse<T>
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public object ResponseHeaders { get; set; }
        public T Result { get; set; }
        public IRequestIntegration RequestHttp { get; set; }
        public IntegrationResponse()
        {
            StatusCode = (int)HttpStatusCode.InternalServerError;
        }
    }

    public interface IRequestIntegration
    {
        string NameConfig { get; set; }
        string Address { get; set; }
        string Method { get; set; }
        object Body { get; set; }
        
        CookieContainer CookieContainer { get; set; }
        List<HeaderIntegration> HeadersHttp { get; set; }

    }

    public interface IIntegrationHttp
    {
        List<HttpSettings> Settings { get; set; }
    }

    public class IntegrationHttp
    {
        public List<HttpSettings> Settings { get; set; }
    }

    public class HttpSettings
    {
        public string ConfigName { get; set; }
        public string Url { get; set; }
        public string PathCertificate { get; set; }
        public bool SslIgnore { get; set; }
        public Proxy Proxy { get; set; }
        public PolicyConfig Policy { get; set; }
    }

    public class PolicyConfig
    {
        public int Retray { get; set; }
        public int TimeOut { get; set; }
        public List<int> StatusCode { get; set; }
    }

    public class Proxy
    {
        public string Url { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
