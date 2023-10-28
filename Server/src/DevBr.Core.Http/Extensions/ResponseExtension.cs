using DevBr.Core.Http.Results;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text;

namespace DevBr.Core.Http.Extensions
{
    public static class ResponseExtension
    {
        public static IntegrationResponse<T> ToReturnSessionProperty<T>(this IntegrationResponse<object> response, string sessionProperty = default(string), JsonSerializerSettings settings = default)
        {
            var result = new IntegrationResponse<T>();
            result.Success = response.Success;
            result.StatusCode = response.StatusCode;
            result.Message = response.Message;
            result.ResponseHeaders = response.ResponseHeaders;
            result.RequestHttp = response.RequestHttp;
            if (response.StatusCode == (int)HttpStatusCode.OK)
            {
                var obj = JObject.Parse(response.Result.ToString());
                if (!string.IsNullOrEmpty(sessionProperty))
                {
                    string data = obj[sessionProperty].ToString();
                    result.Result = JsonConvert.DeserializeObject<T>(data, settings);
                }
            }
            return result;
        }

        public static byte[] ToArrayBytes(this IntegrationResponse<string> result)
        {
            return Encoding.UTF8.GetBytes(result.Result);
        }
        public static string ToBase64(this IntegrationResponse<string> result)
        {
            var base64 = Encoding.UTF8.GetBytes(result.Result);
            return Convert.ToBase64String(base64);
        }

        public static byte[] ToArrayBytes(this IntegrationResponse<Stream> result)
        {
            result.Result.Position = 0;
            using (MemoryStream ms = new MemoryStream())
            {
                result.Result.CopyTo(ms);
                return ms.ToArray();
            }
        }

        public static string ToBase64(this IntegrationResponse<Stream> result)
        {
            result.Result.Position = 0;
            using (MemoryStream ms = new MemoryStream())
            {
                result.Result.CopyTo(ms);
                return Convert.ToBase64String(ms.ToArray());
            }
        }

        public static MemoryStream ToMemoryStream(this IntegrationResponse<Stream> result)
        {
            result.Result.Position = 0;
            using (MemoryStream ms = new MemoryStream())
            {
                result.Result.CopyTo(ms);
                return ms;
            }
        }
    }
}
