using System;
using System.Collections.Generic;
using SashimiApp.Models;

using Xamarin.Forms;

using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace SashimiApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlaygroundPage : ContentPage
    {
        public PlaygroundPage()
        {
            InitializeComponent();
            BindingContext = new LessonListViewModel();
        }
        private async void OnItemSelected(Object sender, ItemTappedEventArgs e)
        {
            var mydetails = e.Item as Lesson;
            await Navigation.PushAsync(new LessonDetail(mydetails.Name));

        }
    }
}