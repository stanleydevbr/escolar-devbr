using DevBr.Core.Http.Results;
using Newtonsoft.Json;
using System.Net;

namespace DevBr.Core.Http.Extensions
{
    public static class IRequestExtension
    {
        public static IRequestIntegration AddHeader(this IRequestIntegration request, string key, string value)
        {
            request.HeadersHttp.Add(new HeaderIntegration() { Chave = key, Valor = value });
            return request;
        }

        public static IRequestIntegration AddBody(this IRequestIntegration request, object body, JsonSerializerSettings settings)
        {
            request.Body = body == null ? body : JsonConvert.SerializeObject(body, settings);
            return request;
        }

        public static IRequestIntegration AddBody(this IRequestIntegration request, object body)
        {
            request.Body = body == null ? body : JsonConvert.SerializeObject(body);
            return request;
        }
        public static IRequestIntegration AddBody(this IRequestIntegration request, MultipartFormDataContent body)
        {
            request.Body = body == body;
            return request;
        }

        public static IRequestIntegration AddBaseUrl(this IRequestIntegration request, string url)
        {
            if (string.IsNullOrEmpty(request.Address))
                request.Address = url;
            else
            {
                var urlBase = url.EndsWith("/") ? url.Remove(url.Length - 1) : url;
                var route = request.Address.StartsWith("/") ? request.Address.Remove(0, 1) : request.Address;
                request.Address = $"{urlBase}/{route}";
            }
            return request;
        }

        public static IRequestIntegration AddRoute(this IRequestIntegration request, string route)
        {
            request.Address = request.Address.EndsWith("/") ? request.Address.Remove(request.Address.Length - 1) : request.Address;
            route = route.StartsWith("/") ? route.Remove(0, 1) : route;
            request.Address = $"{request.Address}/{route}";

            return request;
        }

        public static IRequestIntegration AddQueryParams(this IRequestIntegration request, string key, string value)
        {
            if (!string.IsNullOrEmpty(request.Address) && request.Address.Contains("?"))
            {
                var urlParams = request.Address.Split("?");
                var urlBase = urlParams.FirstOrDefault();
                var urlQueryParams = urlParams.LastOrDefault(); ;
                urlQueryParams = $"{urlQueryParams}&{key}={value}";
                request.Address = $"{urlBase}?{urlQueryParams}";
            }
            else
            {
                request.Address = $"{ request.Address }?{key}={value}";
            }

            return request;
        }

        public static IRequestIntegration AddRouteParams(this IRequestIntegration request, string[] paramters)
        {
            if (paramters.Count() == 0)
                return request;
            var values = string.Join("/", paramters);
            if (request.Address.EndsWith("/"))
                request.Address = request.Address.Remove(request.Address.Length - 1);
            request.Address = $"{request.Address}/{values}";

            return request;
        }

        public static IRequestIntegration AddMethod(this IRequestIntegration request, HttpMethod method)
        {
            request.Method = method.ToString();
            return request;
        }

        public static IRequestIntegration AddConfiguration(this IRequestIntegration request, string config)
        {
            request.NameConfig = config;
            return request;
        }

        public static IRequestIntegration AddCookieContainer(this IRequestIntegration request, CookieContainer cookie)
        {
            request.CookieContainer = cookie;
            return request;
        }
    }
}
