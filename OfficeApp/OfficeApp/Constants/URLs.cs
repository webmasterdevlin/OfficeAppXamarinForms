using Xamarin.Forms;

namespace OfficeApp.Constants
{
    public static class URLs
    {
        const string Android = "http://10.0.2.2:5000/";
        const string iOSandUWP = "http://localhost:5000/";

        const string Department = "api/departments/";
        const string Signup = "api/register/";
        const string Login = "api/auth/login/";

        public static string SetDepartmentUrl()
        {
            return (Device.RuntimePlatform == Device.Android) ? $"{Android}{Department}" : $"{iOSandUWP}{Department}";
        }

        public static string SetLoginUrl()
        {
            return (Device.RuntimePlatform == Device.Android) ? $"{Android}{Login}" : $"{iOSandUWP}{Login}";
        }

        public static string SetSignupUrl()
        {
            return (Device.RuntimePlatform == Device.Android) ? $"{Android}{Signup}" : $"{iOSandUWP}{Signup}";
        }
    }
}