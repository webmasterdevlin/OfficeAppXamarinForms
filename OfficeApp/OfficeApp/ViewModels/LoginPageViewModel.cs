using Prism.Commands;
using Prism.Navigation;

namespace OfficeApp.ViewModels
{
	public class LoginPageViewModel : ViewModelBase
    {
        public LoginPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }


        public DelegateCommand LoginCommand => new DelegateCommand(ToMain);

	    private void ToMain()
	    {
	        
	    }

    }
}
