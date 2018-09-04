using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeApp.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }

        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        /// <summary>
        /// Lifecycle event that runs before you leave the page
        /// </summary>
        /// <param name="parameters"></param>
        public virtual void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        /// <summary>
        /// Lifecycle event that runs after the UI appears
        /// </summary>
        /// <param name="parameters"></param>
        public virtual void OnNavigatedTo(NavigationParameters parameters)
        {
            
        }

        /// <summary>
        /// Lifecycle event that runs before the UI appears
        /// </summary>
        /// <param name="parameters"></param>
        public virtual void OnNavigatingTo(NavigationParameters parameters)
        {
            
        }

        public virtual void Destroy()
        {
            
        }
    }
}
