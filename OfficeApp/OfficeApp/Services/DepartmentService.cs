using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using OfficeApp.Helpers;
using OfficeApp.Models;

namespace OfficeApp.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly HttpClient _client = new HttpClient();
        
        public async Task<string> SendGetAsync()
        {
            _client.AddAuthBearer();
            return await _client.GetStringAsync(Constants.URLs.SetDepartmentUrl());
        }
        
        public async Task<HttpResponseMessage> SendPostAsync(string content)
        {
            _client.AddAuthBearer();
            using (HttpResponseMessage response = await _client.PostAsync(Constants.URLs.SetDepartmentUrl(),
                new StringContent(content, Encoding.UTF8, "application/json")))
                
            return response;
        }

        public async  Task<HttpResponseMessage> SendPutAsync(Department department, string content)
        {
           _client.AddAuthBearer();
            using (var response = await _client.PutAsync(Constants.URLs.SetDepartmentUrl() + department.Id,
                new StringContent(content, Encoding.UTF8, "application/json")))
                
            return response;
        }

        public async Task SendDeleteAsync(string id)
        {
            _client.AddAuthBearer();
            await _client.DeleteAsync(Constants.URLs.SetDepartmentUrl() + id);
        }
    }
}