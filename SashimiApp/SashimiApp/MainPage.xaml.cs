using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SashimiApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        bool showPassword = true;
        private void ShowPassword(object sender, EventArgs e)
        {
            if (showPassword)
            {
                EntryPassword.IsPassword = false;
                showPassword = false;
            }
            else
            {
                EntryPassword.IsPassword = true;
                showPassword = true;
            }
        }
        private async void NavigateToSignup(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignupPage());
        }
    }
}
