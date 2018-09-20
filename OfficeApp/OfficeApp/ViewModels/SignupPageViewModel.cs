using System.Threading.Tasks;
using Prism.Commands;
using OfficeApp.Models;
using OfficeApp.Services;
using Prism.Navigation;
using Prism.Services;

namespace OfficeApp.ViewModels
{
	public class SignupPageViewModel : ViewModelBase
	{
	    private readonly UserService _userService = new UserService();

	    public string UserName { get; set; }
	    public string Email { get; set; }
	    public string Password { get; set; }
        public string ConfirmPassword { get; set; }


	    public SignupPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
            : base(navigationService, pageDialogService){}

		public DelegateCommand GoToLoginPageCommand => new DelegateCommand(async () => await GoToLogin());

	    private async Task GoToLogin()
	    {
            await NavigationService.GoBackAsync();
	    }

		public DelegateCommand SignupCommand => new DelegateCommand(async () =>
		{
			if (Password != ConfirmPassword)
			{
				await PageDialogService.DisplayAlertAsync("Error Signing Up",
					"Password and confirm password are not matched ", "OK");
				return;
			}

			User user = new User
			{
				UserName = UserName,
				Email = Email,
				Password = Password
			};

			var success = await _userService.SignupAsync(user);

			if (success)
				await GoToLogin();

			else
				await PageDialogService.DisplayAlertAsync("Registration Not successful. Please try again", "OK",
					"Cancel");
		});
	}
}
