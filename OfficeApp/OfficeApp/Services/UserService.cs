using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OfficeApp.Helpers;
using OfficeApp.Models;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OfficeApp.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _client = new HttpClient();

        public async Task<bool> SignupAsync(User user)
        {
            var content = JsonConvert.SerializeObject(user);

            var response = await _client.PostAsync(Constants.URLs.Signup, new StringContent(content, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> LoginAsync(User user)
        {
            string content = JsonConvert.SerializeObject(user);

            HttpResponseMessage response = await _client.PostAsync(Constants.URLs.Login, new StringContent(content, Encoding.UTF8, "application/json"));

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                return false;
            }

            string stringResponse = await response.Content.ReadAsStringAsync();

            JObject jwtJObject = JsonConvert.DeserializeObject<dynamic>(stringResponse);

            UserToken userToken = JsonConvert.DeserializeObject<UserToken>(stringResponse);
            DateTime accessTokenExpiration = jwtJObject.Value<DateTime>(".expires");

            Settings.Jwt = userToken.Token;
            Settings.JwtExpirationDate = accessTokenExpiration;

            return response.IsSuccessStatusCode;
        }
    }

    // ReSharper disable once ArrangeTypeModifiers
    internal class UserToken
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}