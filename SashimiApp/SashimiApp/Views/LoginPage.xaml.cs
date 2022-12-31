using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SashimiApp.Repository;


namespace SashimiApp.Views
{
    public partial class LoginPage : ContentPage
    {
        UserRepository userRepository = new UserRepository();
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

        private async void NavigateToHomePage()
        {
            await Navigation.PushAsync(new HomePage());
        }

        private async void LoginToSashimi(object sender, EventArgs e)
        {
            string email = entryEmail.Text;
            string password = entryPassword.Text;

            try 
            {
                string token = await userRepository.Login(email, password);
                if (!string.IsNullOrEmpty(token))
                {
                    NavigateToHomePage();
                }
                else
                {
                    await DisplayAlert("Lỗi", "Tài khoản hoặc mật khẩu không chính xác", "Đóng");
                }
            }
            catch
            {
                await DisplayAlert("Lỗi", "Tài khoản hoặc mật khẩu không chính xác", "Đóng");
            }

        }

    }
}
