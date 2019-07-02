using System;
using System.Collections.Generic;
using Ejemplo.ViewModels;
using Xamarin.Forms;

namespace Ejemplo.Views
{
    public partial class EditItemView : BaseContentPage
    {
        private EditItemVM _vm;
        public EditItemView(ItemVM editItemVM, bool IsEditing = true)
        {
            InitializeComponent();
            _vm = new EditItemVM(Navigation, editItemVM, IsEditing);
            BindingContext = _vm;
        }
    }
}
