using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace SashimiApp.Controls
{
    [DesignTimeVisible(true)]
    public partial class CardExam : ContentView
    {
        public static readonly BindableProperty CardTitleProperty = BindableProperty.Create(nameof(CardTitle), typeof(string), typeof(CardExam), string.Empty);
        public static readonly BindableProperty CardDescriptionProperty = BindableProperty.Create(nameof(CardDescription), typeof(string), typeof(CardExam), string.Empty);
        public static readonly BindableProperty CardTimingProperty = BindableProperty.Create(nameof(CardTiming), typeof(string), typeof(CardExam), string.Empty);
        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(CardExam), Color.DarkGray);
        public static readonly BindableProperty CardColorProperty = BindableProperty.Create(nameof(CardColor), typeof(Color), typeof(CardExam), Color.White);

        public string CardTitle
        {
            get => (string)GetValue(CardExam.CardTitleProperty);
            set => SetValue(CardExam.CardTitleProperty, value);
        }

        public string CardDescription
        {
            get => (string)GetValue(CardExam.CardDescriptionProperty);
            set => SetValue(CardExam.CardDescriptionProperty, value);
        }
        public string CardTiming
        {
            get => (string)GetValue(CardExam.CardTimingProperty);
            set => SetValue(CardExam.CardTimingProperty, value);
        }

        public Color BorderColor
        {
            get => (Color)GetValue(CardExam.BorderColorProperty);
            set => SetValue(CardExam.BorderColorProperty, value);
        }

        public Color CardColor
        {
            get => (Color)GetValue(CardExam.CardColorProperty);
            set => SetValue(CardExam.CardColorProperty, value);
        }

        public CardExam()
        {
            InitializeComponent();
        }

    }
}