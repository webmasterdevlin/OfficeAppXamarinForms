using Newtonsoft.Json;
using OfficeApp.Helpers;
using Prism.Commands;
using Prism.Navigation;
using System.Net.Http;
using System.Text;

namespace OfficeApp.ViewModels
{
    public class NewDepartmentPageViewModel : ViewModelBase
    {
        private readonly HttpClient _client = new HttpClient();

        public string NewName { get; set; }
        public string NewDescription { get; set; }
        public string NewHead { get; set; }
        public string NewCode { get; set; }

        public DelegateCommand SaveCommand => new DelegateCommand(Save);

        public NewDepartmentPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        private async void Save()
        {
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Settings.Jwt}");

            // Another option
            //            HttpContent content = new StringContent(content);
            //            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var content = JsonConvert.SerializeObject(
                new { Name = $"{NewName}", Description = $"{NewDescription}", Head = $"{NewHead}", Code = $"{NewCode}" }
                );

            await _client.PostAsync(Constants.URLs.Department, new StringContent(content, Encoding.UTF8, "application/json"));

            await NavigationService.GoBackAsync();
        }
    }
}