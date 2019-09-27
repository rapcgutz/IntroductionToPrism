using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace App6.ViewModel
{
    public class APageViewModel : BindableBase
    {
        private string _gotoNextPageText = "Goto next page";
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _pageDialogService;

        public ICommand GotoNextPageCommand => new DelegateCommand(async ()=> await GotoNextPage());

        public APageViewModel(INavigationService navigationService , IPageDialogService pageDialogService)
        {
            this._navigationService = navigationService;
            this._pageDialogService = pageDialogService;
        }

        private async Task GotoNextPage()
        {
            var canNavigate = await _pageDialogService.DisplayAlertAsync("Navigate", "Leave current screen?", "Ok", "Cancel");
            if (canNavigate)
            {
                var param = new NavigationParameters();
                param.Add("Name", Name);
                await _navigationService.NavigateAsync("BPage", param);
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string GotoNextPageText
        {
            get { return _gotoNextPageText; }
            set { SetProperty(ref _gotoNextPageText, value); }
        }
    }
}
