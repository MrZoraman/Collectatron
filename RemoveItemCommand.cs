using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Collectatron
{
    public class RemoveItemCommand : ICommand
    {
        private readonly CollectionListItemViewModel _item;
        private readonly ObservableCollection<CollectionListItemViewModel> _itemList;

        public RemoveItemCommand(CollectionListItemViewModel item, ObservableCollection<CollectionListItemViewModel> itemList)
        {
            _item = item;
            _itemList = itemList;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            var result = MessageBox.Show("Are you sure?", "Delete Item", MessageBoxButton.YesNo, MessageBoxImage.Warning,
                MessageBoxResult.No);
            if (result == MessageBoxResult.Yes)
            {
                _itemList.Remove(_item);
                _item.RemoveFromCollection();
            }
        }
    }
}
