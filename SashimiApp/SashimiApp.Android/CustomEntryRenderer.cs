using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Text;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SashimiApp;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using CustomRenderer.Droid;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace CustomRenderer.Droid
{
    class CustomEntryRenderer: EntryRenderer
    {
        public CustomEntryRenderer(Context context) : base(context)
        {
          
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if(Control != null)
            {
                
                GradientStrokeDrawable gradientDrawable = new GradientStrokeDrawable();
                gradientDrawable.SetCornerRadius(10);
                gradientDrawable.SetStroke(2, Android.Graphics.Color.Rgb(210, 210, 210));
                gradientDrawable.SetColor(Android.Graphics.Color.Rgb(245, 245, 245));
                Control.SetBackground(gradientDrawable);
                Control.SetPadding(75, 12, 0, 12);
                
            }
        }
    }
}