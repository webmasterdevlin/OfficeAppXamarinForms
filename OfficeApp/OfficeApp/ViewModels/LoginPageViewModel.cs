using Prism.Commands;
using Prism.Navigation;

namespace OfficeApp.ViewModels
{
	public class LoginPageViewModel : ViewModelBase
    {
	    public DelegateCommand ToMainCommand => new DelegateCommand(ToMain);

	    private void ToMain()
	    {
	        NavigationService.NavigateAsync("MainPage");
	    }

	    public LoginPageViewModel(INavigationService navigationService) : base(navigationService)
	    {
	    }
    }
}
