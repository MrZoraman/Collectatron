using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Collectatron
{
    public class AddImageCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private readonly MainWindowViewModel _viewModel;

        public AddImageCommand(MainWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter == null)
            {
                MessageBox.Show("No item selected!", "Select an item first...", MessageBoxButton.OK,
                    MessageBoxImage.Exclamation);
                return;
            }

            var item = (CollectionListItemViewModel)parameter;

            var dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == true)
            {
                try
                {
                    var path = item.GetImagePath();
                    var extension = Path.GetExtension(dialog.FileName);
                    var imagePath = Path.Combine(path, item.Id + extension);
                    File.Copy(dialog.FileName, imagePath);
                    item.SetExtension(extension);

                    item.Image = new BitmapImage(new Uri(imagePath));
                    _viewModel.UpdateImage();
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Unable to open image: {e.Message}", "Image error.", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
            }
            else
            {
                var result = MessageBox.Show("Remove image?", "Remove image?", MessageBoxButton.YesNo,
                    MessageBoxImage.Question, MessageBoxResult.No);
                if (result == MessageBoxResult.Yes)
                {
                    item.Image = null;
                    _viewModel.UpdateImage();
                }
            }
        }
    }
}
