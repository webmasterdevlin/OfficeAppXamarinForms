using System.Net.Http;
using System.Threading.Tasks;
using OfficeApp.Models;

namespace OfficeApp.Services
{
    public interface IDepartmentService
    {
        Task<string> SendGetAsync();
        Task<HttpResponseMessage> SendPostAsync(string content);
        Task<HttpResponseMessage> SendPutAsync(Department department, string content);
        Task SendDeleteAsync(string id);
    }
}