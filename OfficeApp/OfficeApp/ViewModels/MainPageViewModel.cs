using Newtonsoft.Json;
using OfficeApp.Models;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using OfficeApp.Helpers;
using OfficeApp.Services;
using Prism.Services;
using System;

namespace OfficeApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly HttpClient _client = new HttpClient();
        private readonly DepartmentService _departmentService = new DepartmentService();
        private ObservableCollection<Department> _observableDepartments;

        public ObservableCollection<Department> ObservableDepartments
        {
            get => _observableDepartments;
            set
            {
                _observableDepartments = value;
                RaisePropertyChanged();
            }
        }


        public MainPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
            : base(navigationService, pageDialogService)
        {
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Settings.Jwt}");
        }

        public DelegateCommand ToNewDepPageCommand => new DelegateCommand(() =>
            NavigationService.NavigateAsync("NewDepartmentPage"));

        public override async void OnNavigatingTo(NavigationParameters parameters)
        {
            if (Settings.Jwt == "")
            {
               await NavigationService.NavigateAsync("LoginPage", useModalNavigation:true);
                return;
            }

            //if (DateTime.UtcNow > Settings.JwtExpirationDate) // FIXME
            //{
            //   await NavigationService.NavigateAsync("LoginPage", useModalNavigation:true);
            //    return;
            //}

            var contents = await _departmentService.SendGetAsync();

            // JsonConvert is from Newtonsoft Library
            var departments = JsonConvert.DeserializeObject<List<Department>>(contents);

            ObservableDepartments = new ObservableCollection<Department>(departments);

            base.OnNavigatedTo(parameters);
        }

        public DelegateCommand<Department> EditDeleteCommand => new DelegateCommand<Department>(department =>
        {
            var tappedCell = department;
            var variableToPass = new NavigationParameters {{"(^_^)ImTheKey", tappedCell}};

            NavigationService.NavigateAsync("EditDeleteDepartmentPage", variableToPass);
        });

        public DelegateCommand LogoutCommand => new DelegateCommand(async () =>
            await NavigationService.NavigateAsync("OfficeApp:///NavigationPage/LoginPage")
        );
    }
}