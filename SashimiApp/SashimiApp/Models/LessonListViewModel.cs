using SashimiApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SashimiApp.Models
{
    public class LessonListViewModel
    {
        public ObservableCollection<Lesson> LessonList { get; set; }

        public LessonListViewModel()
        {
            LessonList = new ObservableCollection<Lesson>();
            LessonList.Add(new Lesson { Name = "Nghĩa của từ", Image = "books.png", BackgroundColor= "#fdf1f2", BorderColor= "#ec7482" });
            LessonList.Add(new Lesson { Name = "Điền vào chỗ trống", Image = "books.png", BackgroundColor = "#fdf1f2", BorderColor = "#ec7482" });
        }
    }
}
