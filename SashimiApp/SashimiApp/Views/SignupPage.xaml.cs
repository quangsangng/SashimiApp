using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SashimiApp.Repository;


namespace SashimiApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignupPage : ContentPage
    {
        UserRepository userRepository = new UserRepository();

        public SignupPage()
        {
            InitializeComponent();
        }

        private async void btnSignup_Clicked(object sender, EventArgs e)
        {
            string name = entryName.Text;
            string password = entryPassword.Text;
            string confirmPassword = entryConfirmPassword.Text;
            string email = entryEmail.Text;
            string birth = dpDateOfBirth.Date.ToShortDateString();

            if (
                String.IsNullOrEmpty(name) ||
                String.IsNullOrEmpty(password) ||
                String.IsNullOrEmpty(confirmPassword) ||
                String.IsNullOrEmpty(birth)
                )
            {
                await DisplayAlert("Lỗi", "Thông tin bị thiếu", "Đóng");
                return;
            }

            if (password.Length <= 6 )
            {
                await DisplayAlert("Lỗi", "Mật khẩu quá ngắn", "Đóng");
                return;
            }

            if (password != confirmPassword)
            {
                await DisplayAlert("Lỗi", "Mật khẩu không chính xác", "Đóng");
                return;
            }
            try
            {
                bool isSave = await userRepository.Register(email, name, birth, password);
                if (isSave)
                {
                    await DisplayAlert("Thông báo", "Tạo tài khoản thành công", "Đóng");
                }
                else
                {
                    await DisplayAlert("Lỗi", "Tạo tài khoản thất bại", "Đóng");
                }
            }
            catch (Exception exception)
            {
                if (exception.Message.Contains("EMAIL_EXISTS"))
                {
                    await DisplayAlert("Lỗi", "Email đã tồn tại", "Đóng");
                }
            }
        }
    }
}