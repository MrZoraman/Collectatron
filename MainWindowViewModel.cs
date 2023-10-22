using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media.Imaging;

namespace Collectatron
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel(Collection collection)
        {
            AddCommand = new AddCommand(collection, this);
            SaveCommand = new SaveCommand(collection);
            AddImageCommand = new AddImageCommand(this);
        }

        private CollectionListItemViewModel? _selectedItem;

        public string Title
        {
            get => SelectedItem?.Title ?? "No item selected.";
            set
            {
                if (SelectedItem != null)
                {
                    SelectedItem.Title = value;
                }
            }
        }

        public string? Brand
        {
            get => SelectedItem?.Brand;
            set
            {
                if (SelectedItem != null)
                {
                    SelectedItem.Brand = value;
                }
            }
        }

        public string? PricePaid
        {
            get => SelectedItem?.PricePaid;
            set
            {
                if (SelectedItem != null)
                {
                    SelectedItem.PricePaid = value;
                }
            }
        }

        public string? Year
        {
            get => SelectedItem?.Year;
            set
            {
                if (SelectedItem != null)
                {
                    SelectedItem.Year = value;
                }
            }
        }

        public string? EstimatedValue
        {
            get => SelectedItem?.EstimatedValue;
            set
            {
                if (SelectedItem != null)
                {
                    SelectedItem.EstimatedValue = value;
                }
            }
        }

        public string? Location
        {
            get => SelectedItem?.Location;
            set
            {
                if (SelectedItem != null)
                {
                    SelectedItem.Location = value;
                }
            }
        }

        public string? Comments
        {
            get => SelectedItem?.Comments;
            set
            {
                if (SelectedItem != null)
                {
                    SelectedItem.Comments = value;
                }
            }
        }

        public BitmapImage? Image => SelectedItem?.Image;

        public ObservableCollection<CollectionListItemViewModel> CollectionItems { get; set; } = new();

        public CollectionListItemViewModel? SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedItem)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Title)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Brand)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PricePaid)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Year)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EstimatedValue)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Location)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Comments)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Image)));
            }
        }

        public AddCommand AddCommand { get; }

        public SaveCommand SaveCommand { get; }

        public AddImageCommand AddImageCommand { get; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void UpdateImage()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Image)));
        }
    }
}
