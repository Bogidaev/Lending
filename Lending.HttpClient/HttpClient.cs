using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lending.HttpClient
{
    public static class HttpClient
    {
        private static readonly System.Net.Http.HttpClient _client = new System.Net.Http.HttpClient();

        public static Task<string> GetAsync(string url)
        {
            _client.GetAsync
            return "";
        }
    }
}
