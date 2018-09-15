using OfficeApp.Models;
using OfficeApp.Services;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace OfficeApp.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private readonly IPageDialogService _pageDialogService;
        private readonly UserService _userService = new UserService();

        public string UserName { get; set; }
        public string Password { get; set; }

        public LoginPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService)
        {
            _pageDialogService = pageDialogService;
        }

        public DelegateCommand LoginCommand => new DelegateCommand(
            ToMain
        );

        private async void ToMain()
        {
            var login = new User { UserName = UserName, Password = Password };

            bool response = await _userService.LoginAsync(login);

            if (response)
            {

                await NavigationService.NavigateAsync("OfficeApp:///NavigationPage/MainPage"); // This reset the Navigation Stack to prevent user from going back to LoginPage

                return;
            }

            await _pageDialogService.DisplayAlertAsync("Error logging in", "Please retype your username and password", "OK");
        }

        public DelegateCommand ToSignupPageCommand => new DelegateCommand(ToSignupPage);

        private async void ToSignupPage()
        {
            await NavigationService.NavigateAsync("SignupPage");
        }
    }
}