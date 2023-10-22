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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Collectatron
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(MainWindowViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void AddMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            TxtTitle.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
            TxtBrand.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
            TxtPrice.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
            TxtYear.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
            TxtEstValue.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
            TxtLocation.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
            TxtComments.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
        }
    }
}
