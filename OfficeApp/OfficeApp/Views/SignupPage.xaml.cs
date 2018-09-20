using Xamarin.Forms;
using Page = Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page;

namespace OfficeApp.Views
{
    public partial class SignupPage : ContentPage
    {
        public SignupPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);      
        }
    }
}
