using Prism.Commands;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using OfficeApp.Models;
using Prism.Navigation;

namespace OfficeApp.ViewModels
{
    public class EditDeleteDepartmentPageViewModel : ViewModelBase
    {
        private const string Url = "http://10.0.2.2:3000/departments/"; // For Android Emulators

        private readonly HttpClient _client = new HttpClient();

        private Department _currentDepartment;

        public Department CurrentDepartment
        {
            get { return _currentDepartment; }
            set
            {
                _currentDepartment = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="navigationService"></param>
        public EditDeleteDepartmentPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        /// <summary>
        /// Runs before you can see the application on the screen
        /// </summary>
        /// <param name="parameters"></param>
        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("(^_^)keyAko"))
            {
                CurrentDepartment = (Department)parameters["(^_^)keyAko"];
            }
            base.OnNavigatingTo(parameters);
        }

        public DelegateCommand UpdateCommand => new DelegateCommand(Update);

        private async void Update()
        {
            var content = JsonConvert.SerializeObject(CurrentDepartment);

            await _client.PutAsync(Url + CurrentDepartment.Id, new StringContent(content, Encoding.UTF8, "application/json"));
            await NavigationService.GoBackAsync();
        }

        public DelegateCommand DeleteCommand => new DelegateCommand(Delete);

        private async void Delete()
        {
            await _client.DeleteAsync(Url + CurrentDepartment.Id);
            await NavigationService.GoBackAsync();
        }
    }
}
