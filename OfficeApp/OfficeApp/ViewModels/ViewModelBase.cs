using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;

namespace OfficeApp.ViewModels
{
    public abstract class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {
        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        protected INavigationService NavigationService { get; }
        protected IPageDialogService PageDialogService { get; }

        protected ViewModelBase(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            NavigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
            PageDialogService = pageDialogService ?? throw new ArgumentNullException(nameof(pageDialogService));
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
