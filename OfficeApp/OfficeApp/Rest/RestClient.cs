using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OfficeApp.Helpers;

namespace OfficeApp.Rest
{
    public class RestClient<TResult> : IRestClient<TResult> where TResult : class 
    {
        private readonly HttpClient _client = new HttpClient();

        public async Task<TResult> SendApiRequestAsync(string baseUrl)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer " + $"{Settings.Jwt}");
            Debug.WriteLine(Settings.Jwt);
            return JsonConvert.DeserializeObject<TResult>(await _client.GetStringAsync(baseUrl));
        }
    }
}
