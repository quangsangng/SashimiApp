using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SashimiApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignupPage : ContentPage
    {
        public SignupPage()
        {
            InitializeComponent();
        }

        private void btnSignup_Clicked(object sender, EventArgs e)
        {
            var name = entryName.Text;
            var password = entryPassword.Text;

            DisplayAlert("a", 
                name +
                password +
                "", "c");
        }
    }
}