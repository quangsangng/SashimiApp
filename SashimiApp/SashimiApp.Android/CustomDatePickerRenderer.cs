using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SashimiApp;
using SashimiApp.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using SashimiApp.Custom;

[assembly: ExportRenderer(typeof(CustomDatePicker), typeof(CustomDatePickerRenderer))]
namespace SashimiApp.Droid
{
    public class CustomDatePickerRenderer: DatePickerRenderer
    {
        public CustomDatePickerRenderer(Context context) : base(context)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.DatePicker> e)
        {
            base.OnElementChanged(e);

            if(Control != null)
            {
                Control.Text = "Ngày sinh";
                GradientStrokeDrawable gradientDrawable = new GradientStrokeDrawable();
                gradientDrawable.SetCornerRadius(10);
                gradientDrawable.SetStroke(2, Android.Graphics.Color.Rgb(210, 210, 210));
                gradientDrawable.SetColor(Android.Graphics.Color.Rgb(245, 245, 245));
                Control.SetBackground(gradientDrawable);
                Control.SetPadding(57, 12, 0, 12);
            }
        }
    }
}