using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SashimiApp.Models;
using SashimiApp.Repository;
using Xamarin.Essentials;

namespace SashimiApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditUserInfo : ContentPage
    {
        UserRepository userRepository = new UserRepository();
        List<SashimiUser> sashimiUser = new List<SashimiUser>();
        public EditUserInfo()
        {
            InitializeComponent();
            generateUserInfo();
        }

        public async void generateUserInfo()
        {
            sashimiUser =  await userRepository.GetAllUserInfo();
            entryName.Text = sashimiUser[0].Name;
            entryAvatar.Text = userRepository.NormalizeImageUrl(sashimiUser[0].Avatar);
        }

        private async void SubmitUserInfo(object sender, EventArgs e)
        {
            string name = entryName.Text;
            string avt = entryAvatar.Text;

            sashimiUser[0].Name = name;
            sashimiUser[0].Avatar = userRepository.CleanImageUrl(avt);
     

            try
            {
                bool isSave = await userRepository.SaveUserInfor(sashimiUser[0]);
                if (isSave)
                {
                    await DisplayAlert("Thông báo", "Lưu thành công", "Đóng");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Lỗi", "Lưu thất bại", "Đóng");
                }
            }
            catch
            {
                await DisplayAlert("Lỗi", "Lưu thất bại", "Đóng");
            }
        }
    }
}