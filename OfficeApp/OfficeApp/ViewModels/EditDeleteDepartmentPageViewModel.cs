using Newtonsoft.Json;
using OfficeApp.Helpers;
using OfficeApp.Models;
using Prism.Commands;
using Prism.Navigation;
using System.Net.Http;
using System.Text;

namespace OfficeApp.ViewModels
{
    public class EditDeleteDepartmentPageViewModel : ViewModelBase
    {
        private readonly HttpClient _client = new HttpClient();

        private Department _currentDepartment;

        public Department CurrentDepartment
        {
            get => _currentDepartment;
            set
            {
                _currentDepartment = value;
                RaisePropertyChanged();
            }
        }

        public EditDeleteDepartmentPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("(^_^)ImTheKey"))
            {
                CurrentDepartment = (Department)parameters["(^_^)ImTheKey"];
            }

            base.OnNavigatingTo(parameters);
        }

        public DelegateCommand UpdateCommand => new DelegateCommand(Update);

        private async void Update()
        {
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Settings.Jwt}");

            var content = JsonConvert.SerializeObject(CurrentDepartment);
            await _client.PutAsync(Constants.URLs.Department + CurrentDepartment.Id, new StringContent(content, Encoding.UTF8, "application/json"));

            await NavigationService.GoBackAsync();
        }

        public DelegateCommand DeleteCommand => new DelegateCommand(Delete);

        private async void Delete()
        {
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Settings.Jwt}");
            await _client.DeleteAsync(Constants.URLs.Department + CurrentDepartment.Id);

            await NavigationService.GoBackAsync();
        }
    }
}