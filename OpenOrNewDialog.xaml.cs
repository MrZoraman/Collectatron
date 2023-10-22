using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Collectatron
{
    /// <summary>
    /// Interaction logic for OpenOrNewDialog.xaml
    /// </summary>
    public partial class OpenOrNewDialog : Window
    {
        public OpenOrNewDialog()
        {
            InitializeComponent();
        }

        private void OpenButton_OnClick(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Collectatron Files (*.ctj)|*.ctj|All files (*.*)|*.*"
            };

            if (dialog.ShowDialog() == true)
            {
                var collection = new Collection(dialog.FileName);
                collection.LoadItems();
                var window = new MainWindow(new MainWindowViewModel(collection));
                window.Show();
                Close();
            }
        }

        private void NewButton_OnClick(object sender, RoutedEventArgs e)
        {
            var dialog = new SaveFileDialog
            {
                Filter = "Collectatron Files (*.ctj)|*.ctj|All files (*.*)|*.*"
            };

            if (dialog.ShowDialog() == true)
            {
                var collection = new Collection(dialog.FileName);
                var window = new MainWindow(new MainWindowViewModel(collection));
                window.Show();
                Close();
            }

        }
    }
}
