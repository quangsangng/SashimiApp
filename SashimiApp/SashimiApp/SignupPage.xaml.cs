using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SashimiApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignupPage : ContentPage
    {
        public SignupPage()
        {
            InitializeComponent();
        }

        //bool showPassword = true;
        //private void PasswordIcon_Clicked(object sender, EventArgs e)
        //{
        //    if (showPassword)
        //    {
        //        EntryPassword.IsPassword = false;
        //        EntryConfirmPassword.IsPassword = false;
        //        showPassword = false;
        //    }
        //    else
        //    {
        //        EntryPassword.IsPassword = true;
        //        EntryConfirmPassword.IsPassword = true;
        //        showPassword = true;
        //    }
        //}
    }
}