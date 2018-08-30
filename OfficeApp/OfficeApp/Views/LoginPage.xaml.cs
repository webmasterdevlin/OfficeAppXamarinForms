using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OfficeApp.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SignupPage());
        }
    }
}
