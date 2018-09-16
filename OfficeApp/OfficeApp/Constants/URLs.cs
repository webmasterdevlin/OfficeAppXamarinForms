using Xamarin.Forms;

namespace OfficeApp.Constants
{
    public static class URLs
    {
        //// Replace localhost with 10.0.2.2 on Android emulator
        //public const string Department_iOS = "http://localhost:5000/api/departments/";
        //public const string Signup_iOS = "http://localhost:5000/api/register/";
        //public const string Login_iOS = "http://localhost:5000/api/auth/login/";

        //public const string Department_Android = "http://10.0.2.2:5000/api/departments/";
        //public const string Signup_Android = "http://10.0.2.2:5000/api/register/";
        //public const string Login_Android = "http://10.0.2.2:5000/api/auth/login/";

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