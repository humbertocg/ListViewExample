using System;
using Core.ServiceConsumer.Models;
using Xamarin.Forms;

namespace Ejemplo.ViewModels
{
    public class ItemVM : MvvmHelpers.BaseViewModel
    {
        private ItemModel _itemModel;

        public string ItemTitle
        {
            get => _itemModel.Title;
            set
            {
                _itemModel.Title = value;
                OnPropertyChanged(nameof(ItemTitle));
            }
        }
        public string Description
        {
            get => _itemModel.Description;
            set
            {
                _itemModel.Description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        private bool _isVisibleActions;
        public bool IsVisibleActions
        {
            get => _isVisibleActions;
            set
            {
                _isVisibleActions = value;
                OnPropertyChanged(nameof(IsVisibleActions));
            }
        }

        public Command<ItemVM> EditCommand { get; set; }
        public Command<ItemVM> DeleteCommand { get; set; }
        public Command<ItemVM> EnableActionsCommand { get; set; }

        public ItemVM(ItemModel itemModel)
        {
            _itemModel = itemModel;
        }
    }
}
