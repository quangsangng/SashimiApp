using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace SashimiApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();
        }
        private async void NavigateToSashimiInfoPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SashimiAppInfoPage());
        }

            private async void NavigateToLoginPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
            Preferences.Set("email", "");
        }

    }
}