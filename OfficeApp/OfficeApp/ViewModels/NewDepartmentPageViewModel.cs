using Newtonsoft.Json;
using OfficeApp.Helpers;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
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

        public NewDepartmentPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
            : base(navigationService, pageDialogService)
        {
        }

        private async void Save()
        {
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Settings.Jwt}");

            //            Another option for using Content-Type
            //            HttpContent httpContent = new StringContent(content);
            //            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var content = JsonConvert.SerializeObject(
                new { Name = $"{NewName}", Description = $"{NewDescription}", Head = $"{NewHead}", Code = $"{NewCode}" }
                );

          using (var response = await _client.PostAsync(Constants.URLs.SetDepartmentUrl(),
                                                        new StringContent(content, Encoding.UTF8, "application/json")))
            {
                if (response.IsSuccessStatusCode)
                {
                    await NavigationService.NavigateAsync("OfficeApp:///NavigationPage/MainPage"); // This reset the Navigation Stack to prevent user from going back to LoginPage
                    return;
                }

                await PageDialogService.DisplayAlertAsync("Error logging in", "Please retype your username and password", "OK");
            }
        }
    }
}