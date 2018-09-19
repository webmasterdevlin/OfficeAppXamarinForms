using Newtonsoft.Json;
using OfficeApp.Helpers;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System.Net.Http;
using System.Text;
using OfficeApp.Services;

namespace OfficeApp.ViewModels
{
    public class NewDepartmentPageViewModel : ViewModelBase
    {
        private readonly HttpClient _client = new HttpClient();
        private readonly DepartmentService _departmentService = new DepartmentService();
        
        public string NewName { get; set; }
        public string NewDescription { get; set; }
        public string NewHead { get; set; }
        public string NewCode { get; set; }

        public NewDepartmentPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
            : base(navigationService, pageDialogService)
        {
        }
        
        public DelegateCommand SaveCommand => new DelegateCommand(Save);
        private async void Save()
        {
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Settings.Jwt}");

            //            Another option for using Content-Type
            //            HttpContent httpContent = new StringContent(content);
            //            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var content = JsonConvert.SerializeObject(
                new { Name = $"{NewName}", Description = $"{NewDescription}", Head = $"{NewHead}", Code = $"{NewCode}" }
                );

            var response = await _departmentService.SendPostAsync(content);
            
                if (response.IsSuccessStatusCode)
                {
                    await NavigationService.NavigateAsync("OfficeApp:///NavigationPage/MainPage"); // This reset the Navigation Stack to prevent user from going back to LoginPage
                    return;
                }

                await PageDialogService.DisplayAlertAsync("Error logging in", "Please retype your username and password", "OK");
        }
    }
}