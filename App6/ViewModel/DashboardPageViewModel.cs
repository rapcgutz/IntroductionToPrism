using App6.EventModel;
using Prism.AppModel;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace App6.ViewModel
{
    public class DashboardPageViewModel : BindableBase
    { 
        private readonly INavigationService _navigationService;
        private readonly IEventAggregator _eventAggregator;
        public ICommand NavigateToLoginCommand => new DelegateCommand(async () => { await NavigateToLogin(); });

        public DashboardPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
        {
            this._navigationService = navigationService;
            this._eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<ClientEventModel>().Subscribe(GetClientName);
        }

        private async Task NavigateToLogin()
        {

          await _navigationService.NavigateAsync("LoginPopupPage");
        }

        private void GetClientName(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                ClientName = $"Welcome to Dashboard \n page {name}";
                ShowLoginButton = false;
            }
            else
            {
                ClientName = string.Empty;
                ShowLoginButton = true;
            }
        }

        private string _clientName;
        public string ClientName
        {
            get { return _clientName; }
            set { SetProperty(ref _clientName, value); }
        }

        private bool _showLoginButton = true;

        public bool ShowLoginButton
        {
            get { return _showLoginButton; }
            set { SetProperty(ref _showLoginButton, value); }
        }

    }
}
