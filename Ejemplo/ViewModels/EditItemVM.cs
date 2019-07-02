using System;
using System.Threading.Tasks;
using Ejemplo.Resources.Languages;
using Xamarin.Forms;

namespace Ejemplo.ViewModels
{
    public class EditItemVM : BaseViewModel
    {
        private bool _isEditing;
        public bool IsEditing
        {
            get => _isEditing;
            set
            {
                SetProperty(ref _isEditing, value);
                OnPropertyChanged(nameof(IsEditing));
            }
        }

        private ItemVM _item;
        public ItemVM Item
        {
            get => _item;
            set
            {
                SetProperty(ref _item, value);
                OnPropertyChanged(nameof(Item));
            }
        }

        public Command EditCommand { get; set; }
        public Command CancelCommand { get; set; }

        public EditItemVM(INavigation navigation, ItemVM editItemVM, bool isEditing) : base(navigation)
        {

            Item = editItemVM ?? new ItemVM(new Core.ServiceConsumer.Models.ItemModel());
            IsEditing = isEditing;
            EditCommand = new Command(async ()=> await EditAction());
            CancelCommand = new Command(async () => await CancelAction());
        }

        private async Task CancelAction()
        {
            var result = await CurrentPage.DisplayAlert(AppResources.CancelItemTitle, AppResources.CancelItemMessage, AppResources.YesDialog, AppResources.NoDialog);
            if(result)
            {
                await Navigation.PopAsync();
            }
        }

        private async Task EditAction()
        {
            if (IsEditing)
            {
                var result = await CurrentPage.DisplayAlert(AppResources.EditItemTitle, AppResources.EditItemMessage, AppResources.YesDialog, AppResources.NoDialog);
                if (result)
                {
                    await Navigation.PopAsync();
                }
            }
            else
            {
                var result = await CurrentPage.DisplayAlert(AppResources.AddItemTitle, AppResources.AddItemMessage, AppResources.YesDialog, AppResources.NoDialog);
                if (result)
                {
                    await Navigation.PopAsync();
                }
            }
        }
    }
}

