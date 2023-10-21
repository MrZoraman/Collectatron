using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Collectatron
{
    internal class AddCommand : ICommand
    {
        private readonly Collection _collection;
        private readonly ObservableCollection<CollectionListItemViewModel> _itemList;

        public AddCommand(Collection collection, ObservableCollection<CollectionListItemViewModel> itemList)
        {
            _collection = collection;
            _itemList = itemList;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            var item = _collection.AddItem();
            _itemList.Add(new CollectionListItemViewModel(item));
        }

        public event EventHandler? CanExecuteChanged;
    }
}
