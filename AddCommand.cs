using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Collectatron
{
    public class AddCommand : ICommand
    {
        private readonly Collection _collection;
        private readonly MainWindowViewModel _mainWindowViewModel;

        public AddCommand(Collection collection, MainWindowViewModel mainWindowViewModel)
        {
            _collection = collection;
            _mainWindowViewModel = mainWindowViewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            var item = _collection.AddItem();
            var collectionItemViewModel = new CollectionListItemViewModel(item, _mainWindowViewModel.CollectionItems);
            _mainWindowViewModel.CollectionItems.Add(collectionItemViewModel);

            _mainWindowViewModel.SelectedItem = collectionItemViewModel;
        }

        public event EventHandler? CanExecuteChanged;
    }
}
