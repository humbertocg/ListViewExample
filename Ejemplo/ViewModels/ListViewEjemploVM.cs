using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Ejemplo.Resources.Languages;
using Ejemplo.Views;
using Xamarin.Forms;

namespace Ejemplo.ViewModels
{
    public class ListViewEjemploVM : BaseViewModel
    {
        private ObservableCollection<ItemVM> _itemList { get; set; }
        public ObservableCollection<ItemVM> ItemList { get; set; }

        private ItemVM _selectedItem;
        public ItemVM SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (value != null)
                {
                    SetProperty(ref _selectedItem, value);
                }
            }
        }

        public Command AddItemCommand { get; set; }

        public ListViewEjemploVM(INavigation navigation) : base(navigation)
        {
            ItemList = new ObservableCollection<ItemVM>();
            _itemList = new ObservableCollection<ItemVM>();
            AddItemCommand = new Command(async (x) => await AddItemAction());
            var items = ServiceConsumer.GetItems();
            foreach(var item in items)
            {
                var itemVM = new ItemVM(item);
                itemVM.EditCommand = new Command<ItemVM>(async (x) => await EditAction(x));
                itemVM.DeleteCommand = new Command<ItemVM>(async (x) => await DeleteAction(x));
                itemVM.EnableActionsCommand = new Command<ItemVM>(EnableActionsAction);
                ItemList.Add(itemVM);
                _itemList.Add(itemVM);
            }
        }

        private async Task AddItemAction()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                _editItemView = new EditItemView(null, false);
                await Navigation.PushAsync(_editItemView);
                IsBusy = false;
            }
        }

        private void EnableActionsAction(ItemVM itemVM)
        {
            if (!IsBusy)
            {
                IsBusy = true;
                var item = ItemList.FirstOrDefault(x => x.IsVisibleActions == true);
                if (item != null && itemVM != item)
                {
                    item.IsVisibleActions = false;
                }
                itemVM.IsVisibleActions = !itemVM.IsVisibleActions;
                IsBusy = false;
            }
        }

        private async Task EditAction(ItemVM itemVM)
        {
            if (!IsBusy)
            {
                IsBusy = true;
                _editItemView = new EditItemView(itemVM);
                await Navigation.PushAsync(_editItemView);
                IsBusy = false;
            }
        }

        private async Task DeleteAction(ItemVM itemVM)
        {
            if (!IsBusy)
            {
                IsBusy = true;
                var result = await CurrentPage.DisplayAlert(AppResources.DeleteItemTitle, AppResources.DeleteItemMessage, AppResources.YesDialog, AppResources.NoDialog);
                if (result)
                {
                    _itemList.Remove(itemVM);
                    ItemList.Clear();
                    foreach (var item in _itemList)
                    {
                        ItemList.Add(item);
                    }
                }
                IsBusy = false;
            }
        }

        EditItemView _editItemView;
        public override Task OnViewAppearing()
        {
            if(_editItemView != null)
            {
                var vm = _editItemView.BindingContext as EditItemVM;
                if(vm != null && !vm.IsEditing)
                {
                    vm.Item.EditCommand = new Command<ItemVM>(async (x) => await EditAction(x));
                    vm.Item.DeleteCommand = new Command<ItemVM>(async (x) => await DeleteAction(x));
                    vm.Item.EnableActionsCommand = new Command<ItemVM>(EnableActionsAction);
                    _itemList.Add(vm.Item);
                    ItemList.Clear();
                    foreach (var item in _itemList)
                    {
                        ItemList.Add(item);
                    }
                }
                _editItemView = null;
            }
            return base.OnViewAppearing();
        }

    }
}
