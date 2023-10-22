using System;
using System.Windows;
using System.Windows.Input;

namespace Collectatron
{
    internal class SaveCommand : ICommand
    {
        private readonly Collection _collection;

        public SaveCommand(Collection collection)
        {
            _collection = collection;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            try
            {
                _collection.SaveItems();

                MessageBox.Show("Saved to " + _collection.FileLocation, "Save success.", MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to save items: " + e.Message, "Save Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public event EventHandler? CanExecuteChanged;
    }
}
