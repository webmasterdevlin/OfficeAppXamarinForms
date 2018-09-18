using Newtonsoft.Json;
using OfficeApp.Helpers;
using OfficeApp.Models;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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

        public EditDeleteDepartmentPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
            : base(navigationService, pageDialogService)
        {
        }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("(^_^)ImTheKey"))
                CurrentDepartment = (Department)parameters["(^_^)ImTheKey"];

            base.OnNavigatingTo(parameters);
        }

        public DelegateCommand UpdateCommand => new DelegateCommand(async () => await Update());

        private async Task Update()
        {
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Settings.Jwt}");

            var content = JsonConvert.SerializeObject(CurrentDepartment);

            using (var response = await _client.PutAsync(Constants.URLs.SetDepartmentUrl()+ CurrentDepartment.Id,
                                          new StringContent(content, Encoding.UTF8, "application/json")))
            {
                if (response.IsSuccessStatusCode)
                {
                    await NavigationService.GoBackAsync();
                    return;
                }

                await PageDialogService.DisplayAlertAsync("Error updating", "Please check your internet", "OK");
            }
        }

        public DelegateCommand DeleteCommand => new DelegateCommand(async () => await Delete());

        private async Task Delete()
        {
            var userResponse = await PageDialogService.DisplayAlertAsync("Deleting an entry", "You sure you want to delete this?", "Yes", "Cancel");
            if (!userResponse) return;

            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Settings.Jwt}");
            await _client.DeleteAsync(Constants.URLs.SetDepartmentUrl() + CurrentDepartment.Id);

            await NavigationService.GoBackAsync();
        }
    }
}