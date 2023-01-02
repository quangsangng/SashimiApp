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
    public partial class LessonDetailPage : ContentPage
    {
        LibraryItemRepository libraryItemRepository = new LibraryItemRepository();
        QuizRepository quizRepository = new QuizRepository();

        public List<LibraryItem> Items;

        // Lưu true_index; ở ngoài xác định câu hỏi đúng
        int true_index;
        string type_of_lesson;


        public LessonDetailPage(string Name)
        {
            InitializeComponent();
            RandomRenderQuestionAnswer(Name);
            Title = Name;
            type_of_lesson = Name;
        }

        private async void RandomRenderQuestionAnswer(string Name)
        {
            Random random = new Random();
            Items = await libraryItemRepository.GetLibraryItems();
            true_index = random.Next(Items.Count);


            // Duyệt trên mảng tìm thêm 3 phần tử bị sai
            List<int> false_index = new List<int>();
            for (int i=0; false_index.Count < 3; i++)
            {
                int temp = random.Next(Items.Count);
                if (temp != true_index)
                {
                    false_index.Add(temp);
                }
            }

            // Thêm true_index để tạo ra mảng 4 phần từ (3 sai 1 đúng)
            false_index.Add(true_index);
            int[] answer_index_list = false_index.ToArray();
            int[] answer_index_list_shuffle = answer_index_list.OrderBy(x => random.Next()).ToArray();


            // Render các phần tử vào các button
            if (Name == "Nghĩa của từ")
            {
                labelTopic.Text = "Nghĩa của từ bên dưới là gì?";
                buttonAnswer1.Text = Items[answer_index_list_shuffle[0]].Explain;
                buttonAnswer2.Text = Items[answer_index_list_shuffle[1]].Explain;
                buttonAnswer3.Text = Items[answer_index_list_shuffle[2]].Explain;
                buttonAnswer4.Text = Items[answer_index_list_shuffle[3]].Explain;
                labelQuestion.Text = Items[true_index].Content;
            }
            if (Name == "Điền vào chỗ trống")
            {
                labelTopic.Text = "Từ nào thích hợp để điền vào chỗ trống bên dưới?";
                buttonAnswer1.Text = Items[answer_index_list_shuffle[0]].Content;
                buttonAnswer2.Text = Items[answer_index_list_shuffle[1]].Content;
                buttonAnswer3.Text = Items[answer_index_list_shuffle[2]].Content;
                buttonAnswer4.Text = Items[answer_index_list_shuffle[3]].Content;
                labelQuestion.Text = Items[true_index].Example_1.Replace(Items[true_index].Content, " ______ ");
            }
        }

        private async void CheckAnswer(string choice_text)
        {
            if (
                    Items[true_index].Content == choice_text && type_of_lesson == "Điền vào chỗ trống"
                    ||
                    Items[true_index].Explain == choice_text && type_of_lesson == "Nghĩa của từ"
               )

            {
                // Nếu trả lời đúng có thể lựa chọn tiếp tục và dừng lại
                bool next = await DisplayAlert("Thông báo", "Đáp án chính xác", "Tiếp tục", "Đóng");
                if (next) 
                {
                    await quizRepository.TrueAnswers(type_of_lesson);
                    RandomRenderQuestionAnswer(type_of_lesson);
                }
            }
            else
            {
                // Lựa chọn sai thì tự động next qua câu mới
                await DisplayAlert("Thông báo", "Đáp án sai", "Tiếp tục");
                RandomRenderQuestionAnswer(type_of_lesson);
            }
        }

        private async void ChosingAnswer1(object sender, EventArgs e)
        {
            string choice_text = buttonAnswer1.Text;
            CheckAnswer(choice_text);
        }
        private async void ChosingAnswer2(object sender, EventArgs e)
        {
            string choice_text = buttonAnswer2.Text;
            CheckAnswer(choice_text);
        }
        private async void ChosingAnswer3(object sender, EventArgs e)
        {
            string choice_text = buttonAnswer3.Text;
            CheckAnswer(choice_text);
        }
        private async void ChosingAnswer4(object sender, EventArgs e)
        {
            string choice_text = buttonAnswer4.Text;
            CheckAnswer(choice_text);
        }

    }
}