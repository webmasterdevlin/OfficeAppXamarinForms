using System.Threading.Tasks;

namespace OfficeApp.Rest
{
    public interface IRestClient<TResult> where TResult : class
    {
        Task<TResult> SendApiRequestAsync(string baseUrl);
    }
}