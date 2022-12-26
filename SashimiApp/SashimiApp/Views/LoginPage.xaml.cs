using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;



namespace SashimiApp.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        bool showPassword = true;
        private void ShowPassword(object sender, EventArgs e)
        {
            if (showPassword)
            {
                entryPassword.IsPassword = false;
                showPassword = false;
            }
            else
            {
                entryPassword.IsPassword = true;
                showPassword = true;
            }
        }
        private async void NavigateToSignup(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignupPage());
        }

        private async void NavigateToHomePage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HomePage());
        }

    }
}
