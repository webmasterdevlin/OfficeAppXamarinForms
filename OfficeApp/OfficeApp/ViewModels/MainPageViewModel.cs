using Newtonsoft.Json;
using OfficeApp.Models;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using OfficeApp.Helpers;

namespace OfficeApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly HttpClient _client = new HttpClient();

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

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Settings.Jwt}");
        }

        public DelegateCommand ToNewDepPageCommand => new DelegateCommand(ToNewDep);

        private void ToNewDep()
        {
            NavigationService.NavigateAsync("NewDepartmentPage");
        }

        public override async void OnNavigatingTo(NavigationParameters parameters)
        {
            // Microsoft.Net.Http from Nuget
            var content = await _client.GetStringAsync(Constants.URLs.Department);

            // Newtonsoft.Json from Nuget
            var departments = JsonConvert.DeserializeObject<List<Department>>(content);

            ObservableDepartments = new ObservableCollection<Department>(departments);

            base.OnNavigatedTo(parameters);
        }

        public DelegateCommand<Department> EditDeleteCommand => new DelegateCommand<Department>(EditDelete);

        private void EditDelete(Department department)
        {
            var tappedCell = department;
            var variableToPass = new NavigationParameters {{"(^_^)ImTheKey", tappedCell}};

            NavigationService.NavigateAsync("EditDeleteDepartmentPage", variableToPass);
        }
    }
}