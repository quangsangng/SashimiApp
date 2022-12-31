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
    public partial class AddLibraryItemPage : ContentPage
    {

        LibraryItemRepository libraryItemRepository = new LibraryItemRepository();

        public AddLibraryItemPage()
        {
            // Hiển thị khi thực hiện thêm mới item
            InitializeComponent();
            
        }

        public AddLibraryItemPage(LibraryItem libraryItem)
        {
            // Hiển thị khi thực hiện sửa item
            InitializeComponent();
            entryContent.Text = libraryItem.Content;
            entryExplain.Text = libraryItem.Explain;
            entryExample_1.Text = libraryItem.Example_1;
            entryExample_2.Text = libraryItem.Example_2;
        }

        private async void SubmitLibraryItem(object sender, EventArgs e)
        {
            string content = entryContent.Text;
            string explain = entryExplain.Text;
            string example_1 = entryExample_1.Text;
            string example_2 = entryExample_2.Text;

            LibraryItem item = new LibraryItem();
            item.Content = content;
            item.Explain = explain;
            item.Example_1 = example_1;
            item.Example_2 = example_2;

            bool isSave = await libraryItemRepository.SaveItem(item);
            if (isSave)
            {
                await DisplayAlert("Thông báo", "Lưu thành công", "Đóng");
            }
            else
            {
                await DisplayAlert("Lỗi", "Lưu thất bại", "Đóng");
            }
        }
    }
}