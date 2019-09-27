using App6.Popup.View;
using App6.Popup.ViewModel;
using App6.View;
using App6.ViewModel;
using Prism.Ioc;
using Prism.Plugin.Popups;
using Prism.Unity;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App6
{
    public partial class App : PrismApplication
    {
        protected override void OnInitialized()
        {
            InitializeComponent();
            MainPage = new DashboardPage();
            //MainPage = new NavigationPage(new DashboardPage());
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterPopupNavigationService();
            containerRegistry.RegisterForNavigation<APage, APageViewModel>();
            containerRegistry.RegisterForNavigation<BPage, BPageViewModel>();
            containerRegistry.RegisterForNavigation<DashboardPage, DashboardPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPopupPage, LoginPopupPageViewModel>();
        }
    }
}
