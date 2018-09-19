using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace OfficeApp.Helpers
{
    public static class HttpHeaders
    {
        
        public static void AddAuthBearer(this HttpClient client)
        {
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Settings.Jwt}");
        }        
    }
}