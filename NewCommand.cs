using System;
using System.Windows.Input;
using Microsoft.Win32;

namespace Collectatron
{
    internal class NewCommand : ICommand
    {
        public NewCommand(Collection collection)
        {
            _collection = collection;
        }

        private readonly Collection _collection;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            var dialog = new SaveFileDialog
            {
                Filter = "Collectatron Files (*.ctj)|*.ctj|All files (*.*)|*.*"
            };

            if (dialog.ShowDialog() == true)
            {
                _collection.FileLocation = dialog.FileName;
                _collection.Clear();
            }
        }

        public event EventHandler? CanExecuteChanged;
    }
}
