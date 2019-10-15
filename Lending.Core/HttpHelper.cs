using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;

namespace Lending.Core
{
    public static class HttpHelper
    {
        private static HttpClient _client;

        public static CookieContainer CookieContainer { get; }

        static HttpHelper()
        {
            CookieContainer = new CookieContainer();
            _client = new HttpClient(new HttpClientHandler() { CookieContainer = CookieContainer });
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static HttpHeaders Handler {
            get { return _client.DefaultRequestHeaders; }
        }

        public static async Task<string> Post(string url, object parms)
        {
            using (var content = new StringContent(JsonConvert.SerializeObject(parms), System.Text.Encoding.UTF8, "application/json"))
            {
                var response =  await _client.PostAsync(url, content);
                return  await response.Content.ReadAsStringAsync();
            }
        }

        public static async Task<T> Post<T>(string url, object parms)
        {
            using (var content = new StringContent(JsonConvert.SerializeObject(parms), System.Text.Encoding.UTF8, "application/json"))
            {
                var response = await _client.PostAsync(url, content);
                var result =  await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(result);
            }
        }
    }
}
