using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SashimiApp.Models;
using SashimiApp.Repository;
using System.Collections.Generic;

namespace SashimiApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LibraryPage : ContentPage
    {
        public List<LibraryItem> Items;

        LibraryItemRepository libraryItemRepository = new LibraryItemRepository();
        public LibraryPage()
        {
            InitializeComponent();

            //Items = new ObservableCollection<LibraryItem>
            //{
            //    new LibraryItem {
            //        Content = "訪問",
            //        Explain = " Sự thăm hỏi; sự thăm viếng; sự viếng thăm; sự đến thăm",
            //        Example_1 = "訪問者は通常日本式の家に入る前に、靴を脱ぐようにと求められます。",
            //        Example_2 = "Du khách thường được yêu cầu cởi giày trước khi vào Nhật Bản nhà ở."
            //    },
            //    new LibraryItem {
            //        Content = "興味",
            //        Explain = "Hứng thú",
            //        Example_1 = "興味があるなんてものではなく、もう夢中なんです。",
            //        Example_2 = "Anh ấy không chỉ quan tâm, anh ấy còn phát cuồng vì nó."
            //    },
            //    new LibraryItem {
            //        Content = "応募",
            //        Explain = "Đăng ký; ứng tuyển",
            //        Example_1 = "この仕事に応募した理由は何ですか",
            //        Example_2 = "Tại sao bạn lại xin ứng tuyển công việc này?"
            //    }
            //};

            renderLibraryElements();
        }

        private async void renderLibraryElements()
        { 
            Items = await libraryItemRepository.GetLibraryItems();
            listOfLibrary.ItemsSource = Items;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //var itemSelected = e.SelectedItem as LibraryItem;
            if (e.Item == null)
            {
                return;
            }
            else
            {
                var item = e.Item as LibraryItem;
                await DisplayAlert(item.Content,
                                     "Nghĩa:" + item.Explain + "\n\n" +
                                     "Ví dụ: " + item.Example_1 + "\n\n" +
                                     "Giải nghĩa: " + item.Example_2
                                    , "Đóng");
            }


            //((ListView)sender).SelectedItem = null;
        }

        
        private void SearchLibraryItem(object sender, TextChangedEventArgs e)
        {
            listOfLibrary.ItemsSource = Items.Where(item => item.Content.StartsWith(e.NewTextValue));
        }

        private async void NavigateToAddLibraryPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddLibraryItemPage());
        }

        private void ReloadLibraryItems(object sender, EventArgs e)
        {
            renderLibraryElements();
        }

        private void EditLibraryItem(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var libraryItem = menuItem.CommandParameter as LibraryItem;
            Navigation.PushAsync(new AddLibraryItemPage(libraryItem));
        }

        private async void DeleteLibraryItem(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var libraryItem = menuItem.CommandParameter as LibraryItem;
            var response = await DisplayAlert("Xác nhận", "Bạn có muốn xóa " + libraryItem.Content + " ra khỏi thư viện ?", "Vâng", "Không");
            if (response)
            {
                try
                {
                    await libraryItemRepository.DeleteItem(libraryItem.Content);
                }
                catch
                {
                    await DisplayAlert("Lỗi", "Xóa thất bại", "Đóng");
                }
                // Render lại item sau khi xóa
                renderLibraryElements();
            }
            
        }
        private async void ViewAllLibraryItem(object sender, EventArgs e)
        {
            listOfLibrary.ItemsSource = Items;

        }
        private async void ViewForgotLibraryItem(object sender, EventArgs e)
        {
            listOfLibrary.ItemsSource = Items.Where(item => item.Status == false);
        }
    }
}
