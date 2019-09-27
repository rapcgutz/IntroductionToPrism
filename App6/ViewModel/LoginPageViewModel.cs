using App6.EventModel;
using App6.Model;
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
    public class LoginPageViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;
        private readonly IEventAggregator _eventAggregator;

        public ICommand GotoDashboardPageCommand => new DelegateCommand(async () => await GotoDashboard());

        public LoginPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
        {
            this._navigationService = navigationService;
            this._eventAggregator = eventAggregator;

        }
       
        private async Task GotoDashboard()
        {
           await _navigationService.NavigateAsync("DashboardPage");
            _eventAggregator.GetEvent<ClientEventModel>().Publish(ClientName);
        }

        private string _clientName;
        public string ClientName
        {
            get { return _clientName; }
            set { SetProperty(ref _clientName, value); }
        }

        private string _gotoLoginText = "Login";
        public string GotoLoginText
        {
            get { return _gotoLoginText; }
            set { SetProperty(ref _gotoLoginText, value); }
        }
    }
}
