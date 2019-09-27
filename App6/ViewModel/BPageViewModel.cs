using App6.Model;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace App6.ViewModel
{
    public class BPageViewModel : BindableBase, INavigationAware
    {
        private string _messageText;
        private readonly INavigationService _navigationService;

        public BPageViewModel(INavigationService navigationService)
        {
            this._navigationService = navigationService;
        }
        public string MessageText
        {
            get { return _messageText; }
            set { SetProperty(ref _messageText, value); }
        }

        public ICommand SelectedItemCommand => new DelegateCommand<Client>(async (e) => { await SelectedItem(e); });

        private async Task SelectedItem(Client e)
        {
           await _navigationService.NavigateAsync("APage");
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            MessageText = parameters.GetValue<string>("Name");
        }
    }
}
