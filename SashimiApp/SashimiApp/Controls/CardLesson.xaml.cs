using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace SashimiApp.Controls
{
    [DesignTimeVisible(true)]
    public partial class CardLesson : ContentView
    {
        public static readonly BindableProperty CardTitleProperty = BindableProperty.Create(nameof(CardTitle), typeof(string), typeof(CardLesson), string.Empty);
        public static readonly BindableProperty CardDescriptionProperty = BindableProperty.Create(nameof(CardDescription), typeof(string), typeof(CardLesson), string.Empty);
        public static readonly BindableProperty CardProcessProperty = BindableProperty.Create(nameof(CardProcess), typeof(string), typeof(CardLesson), string.Empty);
        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(CardLesson), Color.DarkGray);
        public static readonly BindableProperty CardColorProperty = BindableProperty.Create(nameof(CardColor), typeof(Color), typeof(CardLesson), Color.White);
        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(CardLesson), Color.White);
        public static readonly BindableProperty IconImageSourceProperty = BindableProperty.Create(nameof(IconImageSource), typeof(ImageSource), typeof(CardLesson), default(ImageSource));
        public static readonly BindableProperty IconBackgroundColorProperty = BindableProperty.Create(nameof(IconBackgroundColor), typeof(Color), typeof(CardLesson), Color.LightGray);

        public string CardTitle
        {
            get => (string)GetValue(CardLesson.CardTitleProperty);
            set => SetValue(CardLesson.CardTitleProperty, value);
        }

        public string CardDescription
        {
            get => (string)GetValue(CardLesson.CardDescriptionProperty);
            set => SetValue(CardLesson.CardDescriptionProperty, value);
        }
        public string CardProcess
        {
            get => (string)GetValue(CardLesson.CardProcessProperty);
            set => SetValue(CardLesson.CardProcessProperty, value);
        }

        public Color BorderColor
        {
            get => (Color)GetValue(CardLesson.BorderColorProperty);
            set => SetValue(CardLesson.BorderColorProperty, value);
        }

        public Color CardColor
        {
            get => (Color)GetValue(CardLesson.CardColorProperty);
            set => SetValue(CardLesson.CardColorProperty, value);
        }

        public Color TextColor
        {
            get => (Color)GetValue(CardLesson.TextColorProperty);
            set => SetValue(CardLesson.TextColorProperty, value);
        }

        public ImageSource IconImageSource
        {
            get => (ImageSource)GetValue(CardLesson.IconImageSourceProperty);
            set => SetValue(CardLesson.IconImageSourceProperty, value);
        }

        public Color IconBackgroundColor
        {
            get => (Color)GetValue(CardLesson.IconBackgroundColorProperty);
            set => SetValue(CardLesson.IconBackgroundColorProperty, value);
        }
        public CardLesson()
        {
            InitializeComponent();
        }


    }
}