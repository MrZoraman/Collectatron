using System;
using System.Windows.Input;
using Microsoft.Win32;

namespace Collectatron
{
    internal class LoadCommand : ICommand
    {
        private readonly Collection _collection;

        public LoadCommand(Collection collection)
        {
            _collection = collection;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Collectatron Files (*.ctj)|*.ctj|All files (*.*)|*.*"
            };

            if (dialog.ShowDialog() == true)
            {
                _collection.FileLocation = dialog.FileName;
                _collection.LoadItems();
            }
        }

        public event EventHandler? CanExecuteChanged;
    }
}
