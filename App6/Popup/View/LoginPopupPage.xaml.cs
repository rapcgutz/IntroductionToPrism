using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App6.Popup.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPopupPage : Rg.Plugins.Popup.Pages.PopupPage
    {
        public LoginPopupPage()
        {
            InitializeComponent();
        }
    }
}