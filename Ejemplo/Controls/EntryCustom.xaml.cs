using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Ejemplo.Controls
{
    public partial class EntryCustom : ContentView
    {
        public static readonly BindableProperty TitleProperty = BindableProperty.Create(
            nameof(Title),
            typeof(string),
            typeof(EntryCustom),
            string.Empty,
            BindingMode.TwoWay);

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly BindableProperty DataProperty = BindableProperty.Create(
            nameof(Data),
            typeof(string),
            typeof(EntryCustom),
            string.Empty,
            BindingMode.TwoWay);

        public string Data
        {
            get { return (string)GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }

        public EntryCustom()
        {
            InitializeComponent();
        }
    }
}
