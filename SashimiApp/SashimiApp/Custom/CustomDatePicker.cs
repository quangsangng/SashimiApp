using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace SashimiApp.Custom
{
    public class CustomDatePicker : DatePicker
    {
        public ObservableCollection<object> SelectedItem { get; internal set; }
    }
}
