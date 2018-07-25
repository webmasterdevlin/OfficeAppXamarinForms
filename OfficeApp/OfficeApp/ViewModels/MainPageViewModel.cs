using Newtonsoft.Json;
using OfficeApp.Models;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;

namespace OfficeApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private const string Url = "http://10.0.2.2:3000/departments/"; // For Android Emulators

        private readonly HttpClient _client = new HttpClient();

        private ObservableCollection<Department> _observableDepartments;

        public ObservableCollection<Department> ObservableDepartments
        {
            get { return _observableDepartments; }
            set
            {
                _observableDepartments = value;
                RaisePropertyChanged();
            }
        }

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
        }

        public DelegateCommand ToNewDepPageCommand => new DelegateCommand(ToNewDep);

        private void ToNewDep()
        {
            NavigationService.NavigateAsync("NewDepartmentPage");
        }

        public override async void OnNavigatingTo(NavigationParameters parameters)
        {
            // Microsoft.Net.Http from Nuget
            var content = await _client.GetStringAsync(Url);

            // Newtonsoft.Json from Nuget
            var departments = JsonConvert.DeserializeObject<List<Department>>(content);

            ObservableDepartments = new ObservableCollection<Department>(departments);

            base.OnNavigatedTo(parameters);
        }

        public DelegateCommand<Department> EditDeleteCommand => new DelegateCommand<Department>(EditDelete);

        private void EditDelete(Department objectNaIpapasa)
        {
            var tappedCell = objectNaIpapasa;

            var variableToPass = new NavigationParameters();

            variableToPass.Add("(^_^)keyAko", tappedCell);

            NavigationService.NavigateAsync("EditDeleteDepartmentPage", variableToPass);
        }
    }
}