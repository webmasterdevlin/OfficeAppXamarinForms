using System.Threading.Tasks;
using OfficeApp.Models;
using OfficeApp.Services;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace OfficeApp.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private readonly UserService _userService = new UserService();

        public string Email { get; set; }
        public string Password { get; set; }

        private bool _isLogging;

        public bool IsLogging
        {
            get => _isLogging;
            set
            {
                _isLogging = value;
                RaisePropertyChanged();
            }
        }

        public LoginPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
            : base(navigationService, pageDialogService)
        {

        }

        public DelegateCommand LoginCommand => new DelegateCommand(
            ToMain
        );

        private async void ToMain()
        {
            IsLogging = !IsLogging;
            
            var login = new User { Email = Email, Password = Password };

            bool response = await _userService.LoginAsync(login);

            if (response)
            {
                IsLogging = !IsLogging;
                await NavigationService.NavigateAsync("OfficeApp:///NavigationPage/MainPage"); // This reset the Navigation Stack to prevent user from going back to LoginPage
                return;
            }

            IsLogging = !IsLogging;
            await PageDialogService.DisplayAlertAsync("Error logging in", "Please retype your username and password", "OK");
        }

        public DelegateCommand ToSignupPageCommand => new DelegateCommand(async () => await ToSignupPage());

        private async Task ToSignupPage()
        {
            await NavigationService.NavigateAsync("SignupPage");
        }
    }
}