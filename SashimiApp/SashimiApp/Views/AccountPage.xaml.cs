using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SashimiApp.Repository;
using SashimiApp.Models;


namespace SashimiApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    
    public partial class AccountPage : ContentPage
    {
        UserRepository userRepository = new UserRepository();
        LibraryItemRepository libraryItemRepository = new LibraryItemRepository();

        public AccountPage()
        {
            InitializeComponent();
            GenerateUserInfo();

        }
        private async void GenerateUserInfo()
        {
            List<SashimiUser> Users = await userRepository.GetAllUserInfo();
            UserInfoCard.CardTitle = Users[0].Name;
            UserInfoCard.CardDescription = Users[0].Email;

            try
            {
                double task1_percent = (float)Users[0].Task1_correct / (float)Users[0].Task1_total * 100;
                CardExamTask1.CardTitle = Math.Round(task1_percent,1).ToString();
            }
            catch
            {
                CardExamTask1.CardTitle = "Chưa có thông tin";
            }
            try
            {
                double task2_percent = (float)Users[0].Task2_correct /  (float)Users[0].Task2_total  * 100;
                CardExamTask2.CardTitle = Math.Round(task2_percent,1).ToString();
            }
            catch
            {
                CardExamTask1.CardTitle = "Chưa có thông tin";
            }


            List<LibraryItem> libraryItems = await libraryItemRepository.GetLibraryItems();
            try
            {
                SoTuVungCard.CardDescription = "Bạn đang có " + libraryItems.Count.ToString() + " từ vựng";
            }
            catch
            {
                SoTuVungCard.CardDescription = "Chưa có thông tin";
            }


            int total_correct = Users[0].Task1_correct + Users[0].Task2_correct;
            try
            {
                SoCauDungCard.CardDescription = "Bạn đã làm đúng " + total_correct.ToString() + " câu";
            }
            catch
            {
                SoCauDungCard.CardDescription = "Chưa có thông tin";
            }

        }

        private async void OnItemSelected(Object sender, ItemTappedEventArgs e)
        {
            var mydetails = e.Item as Lesson;
            await Navigation.PushAsync(new LessonDetailPage(mydetails.Name));

        }
    }
}