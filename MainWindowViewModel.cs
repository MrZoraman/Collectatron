using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Collectatron
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel(Collection collection)
        {
            LoadCommand = new LoadCommand(collection);
            NewCommand = new NewCommand(collection);
            AddCommand = new AddCommand(collection, CollectionItems);
            SaveCommand = new SaveCommand(collection);
        }

        private CollectionListItemViewModel? _selectedItem;

        public string Title
        {
            get => SelectedItem?.Title ?? "??";
            set
            {
                if (SelectedItem != null)
                {
                    SelectedItem.Title = value;
                }
            }
        }

        public string Brand { get; set; } = string.Empty;

        public string PricePaid { get; set; } = string.Empty;

        public string EstimatedValue { get; set; } = string.Empty;

        public ObservableCollection<CollectionListItemViewModel> CollectionItems { get; set; } = new();

        public CollectionListItemViewModel? SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedItem)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Title)));
            }
        }

        public LoadCommand LoadCommand { get; }

        public NewCommand NewCommand { get; }

        public AddCommand AddCommand { get; }

        public SaveCommand SaveCommand { get; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
