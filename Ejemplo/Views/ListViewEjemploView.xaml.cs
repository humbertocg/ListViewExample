using System;
using System.Collections.Generic;
using Ejemplo.ViewModels;
using Xamarin.Forms;

namespace Ejemplo.Views
{
    public partial class ListViewEjemploView : BaseContentPage
    {
        public void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListItems.SelectedItem = null;
        }

        private ListViewEjemploVM _vm;
        public ListViewEjemploView()
        {
            InitializeComponent();
            _vm = new ListViewEjemploVM(Navigation);
            BindingContext = _vm;
        }
    }
}
