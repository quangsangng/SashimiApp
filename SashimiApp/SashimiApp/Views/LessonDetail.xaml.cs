using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SashimiApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LessonDetail : ContentPage
    {
        public LessonDetail(string Name)
        {
            InitializeComponent();
        }
    }
}