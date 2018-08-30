using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OfficeApp.Models;

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

        public async Task<string> LoginAsync(User user)
        {
            var content = JsonConvert.SerializeObject(user);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer " + "");
            await _client.PostAsync(Constants.URLs.Login, new StringContent(content, Encoding.UTF8, "application/json"));

            return "";
        }
    }
}
