using Newtonsoft.Json;
using OfficeApp.Helpers;
using OfficeApp.Models;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using OfficeApp.Services;

namespace OfficeApp.ViewModels
{
    public class EditDeleteDepartmentPageViewModel : ViewModelBase
    {
        private readonly HttpClient _client = new HttpClient();
        private readonly DepartmentService _departmentService = new DepartmentService();
        
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

        public DelegateCommand UpdateCommand => new DelegateCommand(async () =>
        {
            var content = JsonConvert.SerializeObject(CurrentDepartment);

            var response = await _departmentService.SendPutAsync(CurrentDepartment, content);

            if (response.IsSuccessStatusCode)
            {
                await NavigationService.GoBackAsync();
                return;
            }

            await PageDialogService.DisplayAlertAsync("Error updating", "Please check your internet", "OK");
        });

        public DelegateCommand DeleteCommand => new DelegateCommand(async () =>
        {
            var userResponse = await PageDialogService.DisplayAlertAsync("Deleting an entry",
                "You sure you want to delete this?", "Yes", "Cancel");
            if (!userResponse) return;

            await _departmentService.SendDeleteAsync(CurrentDepartment.Id);
            await NavigationService.GoBackAsync();
        });
        
        public DelegateCommand LogoutCommand => new DelegateCommand(async () =>
            await NavigationService.NavigateAsync("OfficeApp:///NavigationPage/LoginPage")
        );
    }
}